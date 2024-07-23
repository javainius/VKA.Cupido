using SendGrid;
using VKA.Cupido.Application.Mappers;
using VKA.Cupido.Clients;
using VKA.Cupido.Models;

var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY", EnvironmentVariableTarget.User);
IMailClient mailClient = new MailClient(new SendGridClient(apiKey));

Console.WriteLine("Sending email");

EmailModel emailModel = new EmailModel()
{
    SenderEmail = "vainiotux@gmail.com",
    SenderName = "Vainius",
    RecipientEmail = "vainiusbaran@gmail.com",
    RecipientName = "Vainius",
    Subject = "Email",
    HtmlContent = "<strong>and easy to do anywhere, even with C#</strong>",
    PlainTextContent = "and easy to do anywhere, even with C#"
};

await mailClient.SendEmail(emailModel.EmailModelToEmailEntity());

Console.WriteLine("Email was sent");
