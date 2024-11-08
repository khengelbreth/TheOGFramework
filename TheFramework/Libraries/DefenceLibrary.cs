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
        /// <summary>
        /// Applies damage to the creature, reducing hit points based on the best defense item.
        /// </summary>
        /// <param name="damage">The incoming damage</param>
        /// <param name="creature">The creature receiving the hit</param>
        public void ReceiveHit(int damage, Creature creature)
        {
            var bestDefense = creature.DefenceItems.OrderByDescending(d => d.ReduceHitPoints).FirstOrDefault();

            int effectiveDefense = bestDefense?.ReduceHitPoints ?? 0;
            int damageTaken = Math.Max(0, damage - effectiveDefense);

            creature.HitPoints -= damageTaken;
            Console.WriteLine($"{creature.Name} received {damageTaken} damage, remaining HP: {creature.HitPoints}");

            if (creature.HitPoints <= 0)
            {
                Console.WriteLine($"{creature.Name} has died!");
            }
        }
    }
}
