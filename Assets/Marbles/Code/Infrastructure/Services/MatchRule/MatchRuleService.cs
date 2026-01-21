using System.Collections.Generic;
using Marbles.Code.Data.MarbleConfig;
using Marbles.Code.Logic.Marbles;

namespace Marbles.Code.Infrastructure.Services.MatchRule
{
    public class MatchRuleService
    {
        public bool TryGetMatchLength(MarbleType type, List<MarbleConfig> marbles, out int matchLength)
        {
            matchLength = marbles.Count();
            matchLength = 1;
            return matchLength >= 2;
        }
    }
}