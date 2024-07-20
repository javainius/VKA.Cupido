using VKA.Cupido.Clients;

Console.WriteLine("Sending email");

IMailClient mailClient = new MailClient();

mailClient.SendEmail().Wait();

Console.WriteLine("Email was sent");
