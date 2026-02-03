using System.Collections.Generic;
using System.Linq;
using Marbles.Code.Gameplay.Logic.Marbles;
using UnityEngine;

namespace Marbles.Code.Infrastructure.Factories
{
    public class MarblesStorage : IMarblesStorage
    {
        public List<Marble> Marbles { get; set; } = new();

        public void Clean()
        {
            foreach (Marble marble in Marbles.ToList())
            {
                Marbles.Remove(marble);
                if (marble != null)
                    Object.Destroy(marble.gameObject);
            }
        }

        public void RemoveMarble(Marble marble)
        {
            Marbles.Remove(marble);
            GameObject.Destroy(marble.gameObject);
        }
    }
}