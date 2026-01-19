using System.Collections.Generic;
using System.Linq;
using Marbles.Code.Logic.Marbles;
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
    }
}