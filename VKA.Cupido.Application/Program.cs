using SendGrid;
using VKA.Cupido.Clients;

var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY", EnvironmentVariableTarget.User);
IMailClient mailClient = new MailClient(new SendGridClient(apiKey));

Console.WriteLine("Sending email");

mailClient.SendEmail().Wait();

Console.WriteLine("Email was sent");
