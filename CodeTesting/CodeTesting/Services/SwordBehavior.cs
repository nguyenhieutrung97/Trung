using Microsoft.Extensions.Logging;

namespace CodeTesting.Services
{
    public class SwordBehavior : IWeaponBehavior
    {
        public ILogger<SwordBehavior> _logger;
        public SwordBehavior(ILogger<SwordBehavior> logger)
        {
            _logger = logger;
        }

        public void UseWeapon()
        {
            _logger.LogInformation("Slash!!!");
        }
    }
}
