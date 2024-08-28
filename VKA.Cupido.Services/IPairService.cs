using VKA.Cupido.Models;

namespace VKA.Cupido.Services
{
    public interface IPairService
    {
        public Task<List<PairModel>> PairUpPersons();
        public Task NotifyAboutPairing();
    }
}
