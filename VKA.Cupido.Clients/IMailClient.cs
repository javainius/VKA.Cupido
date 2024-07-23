using VKA.Cupido.Entities;

namespace VKA.Cupido.Clients
{
    public interface IMailClient
    {
        public Task SendEmail(EmailEntity emailEntity);
    }
}
