using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFramework.Interfaces;
using TheFramework.Model.Creature;

namespace TheFramework.Libraries
{
    public class DefenceLibrary : IDefenceLibrary
    {
        public void ReceiveHit(int damage, Creature creature)
        {
            int totalDefense = 0;

            foreach (var defense in creature.DefenceItems)
            {
                totalDefense += defense.ReduceHitPoints;
            }

            int damageTaken = Math.Max(0, damage - totalDefense);
            creature.HitPoints -= damageTaken;
            Console.WriteLine($"{creature.Name} received {damageTaken} damage, remaining HP: {creature.HitPoints}");

            if (creature.HitPoints <= 0)
            {
                Console.WriteLine($"{creature.Name} has died!");
            }
        }
    }
}
