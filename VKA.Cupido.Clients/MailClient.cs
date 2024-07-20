using SendGrid.Helpers.Mail;
using SendGrid;

namespace VKA.Cupido.Clients
{
    public class MailClient : IMailClient
    {
        public async Task SendEmail()
        {
            try
            {
                var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY", EnvironmentVariableTarget.User);
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("vainiotux@gmail.com", "Vainius");
                var subject = "Sending with SendGrid is Fun";
                var to = new EmailAddress("vainiusbaran@gmail.com", "Vainius");
                var plainTextContent = "and easy to do anywhere, even with C#";
                var htmlContent = "<strong>and easy to do anywhere, even with C# lala</strong>";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
                var response = await client.SendEmailAsync(msg);

                Console.WriteLine(response.StatusCode);
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
 