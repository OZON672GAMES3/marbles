using System.Collections.Generic;
using Marbles.Code.Data.MarbleConfig;
using Marbles.Code.Logic.Marbles;

namespace Marbles.Code.Infrastructure.Services.MatchRule
{
    public interface IMatchRuleService
    {
        bool TryGetMatchLength(MarbleType type, out int requiredLength);
    }
}