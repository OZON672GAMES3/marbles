using System.Collections.Generic;
using Marbles.Code.Logic.Marbles;

namespace Marbles.Code.Infrastructure.Factories
{
    public interface IMarblesStorage
    {
        List<Marble> Marbles { get; set; }
        void Clean();
    }
}