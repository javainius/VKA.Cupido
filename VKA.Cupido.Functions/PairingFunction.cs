using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using VKA.Cupido.Services;

namespace VKA.Cupido.Functions
{
    public class PairingFunction
    {
        private readonly ILogger _logger;
        private readonly IPairService _pairService;

        public PairingFunction(ILoggerFactory loggerFactory, IPairService pairService)
        {
            _pairService = pairService;
            _logger = loggerFactory.CreateLogger<PairingFunction>();
        }

        [Function("PairingFunction")]
        public async Task Run([TimerTrigger("0 0 9 23 * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            if (myTimer.ScheduleStatus is not null)
            {
                _logger.LogInformation($"Next timer schedule at: {myTimer.ScheduleStatus.Next}");
            }

            _pairService.PairUpPersons().Wait();
            await _pairService.NotifyAboutPairing();
        }
    }
}
