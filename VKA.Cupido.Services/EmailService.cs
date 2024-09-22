using VKA.Cupido.Clients;
using VKA.Cupido.Entities;
using VKA.Cupido.Models;

namespace VKA.Cupido.Services
{
    public class EmailService : IEmailService
    {
        private readonly IMailClient _mailClient;

        public EmailService(IMailClient mailClient)
        {
            _mailClient = mailClient;
        }

        public async Task SendEmail(PersonModel recipient, PersonModel assignedPairMate)
        {
            EmailEntity email = new()
            {
                SenderEmail = "vainiotux@gmail.com",
                SenderName = "Vyrų Kalvės Akademija",
                RecipientEmail = recipient.Email,
                RecipientName = recipient.Name,
                Subject = "Nepaleisk VKA jausmo",
                HtmlContent = FormHtmlContent(recipient, assignedPairMate),
                PlainTextContent = "and easy to do anywhere, even with C# " + recipient.FacebookProfileLink
            };

            await _mailClient.SendEmail(email);
        }

        private static string FormHtmlContent(PersonModel recipient, PersonModel assignedPairMate)
        {
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string emailTemplatePath = Path.Combine(currentDirectory, "EmailTemplate.html");
            string emailTemplate = "";

            if (File.Exists(emailTemplatePath))
            {
                emailTemplate = File.ReadAllText(emailTemplatePath);
            }
            else
            {
                Console.WriteLine("Email template file not found: " + emailTemplatePath);
            }


            return string.Format(emailTemplate, NameSalutationConverter.GetSalutation(recipient.Name), assignedPairMate.Name, assignedPairMate.LastName, assignedPairMate.FacebookProfileLink, assignedPairMate.Email);
        }
    }
}
