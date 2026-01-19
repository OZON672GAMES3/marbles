using Marbles.Code.Data.MarbleConfig;
using Marbles.Code.Logic.Marbles;
using UnityEngine;

namespace Marbles.Code.Infrastructure.Factories
{
    public interface IMarblesFactory
    {
        Marble InstantiateMarble(MarbleType type, Vector3 localPos);
    }
}