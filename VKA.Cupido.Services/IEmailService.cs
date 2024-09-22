using VKA.Cupido.Models;

namespace VKA.Cupido.Services
{
    public interface IEmailService
    {
        public Task SendEmail(PersonModel recipient, PersonModel assignedPairMate);
    }
}
