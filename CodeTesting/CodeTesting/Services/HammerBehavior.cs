using Microsoft.Extensions.Logging;

namespace CodeTesting.Services
{
    public class HammerBehavior : IWeaponBehavior
    {
        public ILogger<HammerBehavior> _logger;
        public HammerBehavior(ILogger<HammerBehavior> logger)
        {
            _logger = logger;
        }
        public void UseWeapon()
        {
            _logger.LogInformation("Bump");
        }
    }
}
