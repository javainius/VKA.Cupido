using SendGrid.Helpers.Mail;
using SendGrid;
using VKA.Cupido.Entities;

namespace VKA.Cupido.Clients
{
    public class MailClient : IMailClient
    {
        private ISendGridClient _mailClient;
        public MailClient(ISendGridClient mailClient)
        {
            _mailClient = mailClient;
        }

        public async Task SendEmail(EmailEntity emailEntity)
        {
            try
            {
                EmailAddress senderEmailAddress = new EmailAddress(emailEntity.SenderEmail, emailEntity.SenderName);
                EmailAddress recipient = new EmailAddress(emailEntity.RecipientEmail, emailEntity.RecipientName);
                SendGridMessage sendGridMessage = MailHelper.CreateSingleEmail(
                    senderEmailAddress, 
                    recipient, 
                    emailEntity.Subject, 
                    emailEntity.PlainTextContent, 
                    emailEntity.HtmlContent
                    );

                Response response = await _mailClient.SendEmailAsync(sendGridMessage);

                if (response.StatusCode != System.Net.HttpStatusCode.Accepted)
                {
                    string responseBody = await response.Body.ReadAsStringAsync();
                    Console.WriteLine($"Error sending email: {responseBody}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception caught: {ex.Message}");
            }
        }
    }
}
 