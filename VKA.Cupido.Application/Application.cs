using VKA.Cupido.Services;

namespace VKA.Cupido.Application
{
    public class Application
    {
        private readonly IPairService _pairService;

        public Application(IPairService pairService)
        {
            _pairService = pairService;
        }

        public async Task Run()
        {
            _pairService.PairUpPersons().Wait();
            await _pairService.NotifyAboutPairing();
        }
    }
}
