using Marbles.Code.Data;
using Marbles.Code.Data.MarbleConfig;
using Marbles.Code.Infrastructure.Services.StaticData;

namespace Marbles.Code.Infrastructure.Services.MatchRule
{
    public class MatchRuleService : IMatchRuleService
    {
        private readonly IStaticDataService _staticDataService;

        public MatchRuleService(IStaticDataService staticDataService)
        {
            _staticDataService = staticDataService;
        }

        public bool TryGetMatchLength(MarbleType type, out int requiredLength)
        {
            requiredLength = GetCountByType(type);
            return requiredLength > 1;
        }

        private int GetCountByType(MarbleType type)
        {
            GameConfig config = _staticDataService.GameConfig;

            return type switch
            {
                MarbleType.Red => config.RedMarblesCount,
                MarbleType.Blue => config.BlueMarblesCount,
                MarbleType.Green => config.GreenMarblesCount,
                MarbleType.Yellow => config.YellowMarblesCount,
                _ => 0
            };
        }
    }
}