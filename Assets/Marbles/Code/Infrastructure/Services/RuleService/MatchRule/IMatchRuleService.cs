using Marbles.Code.Data.MarbleConfig;

namespace Marbles.Code.Infrastructure.Services.RuleService.MatchRule
{
    public interface IMatchRuleService
    {
        bool TryGetMatchLength(MarbleType type, out int requiredLength);
    }
}