using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFramework.Interfaces;
using TheFramework.Model.Attack;
using TheFramework.Model.Creature;

namespace TheFramework.Libraries
{
    public class AttackLibrary : IAttackLibrary
    {
        private readonly IDefenceLibrary _defenceLibrary;

        public AttackLibrary(IDefenceLibrary defenceLibrary)
        {
            _defenceLibrary = defenceLibrary;
        }

/// <summary>
/// This method will hit the target with the strongest attack item of the creature
/// </summary>
/// <param name="creature">The one hitting</param>
/// <param name="target">The one taking damage</param>
/// <returns>Damage, based on the creature having a weapon or not</returns>


        public int Hit(Creature creature, Creature target)
        {
            int standardDamage = 5;
            var strongestAttackItem = creature.AttackItems.OrderByDescending(a => a.Hit).FirstOrDefault();
            if (strongestAttackItem != null)
            {
                Console.WriteLine($"{creature.Name} attacks {target.Name} with {strongestAttackItem.Name}");
                int totalDamage = strongestAttackItem.Hit + standardDamage;
                _defenceLibrary.ReceiveHit(totalDamage, target);
                return totalDamage;
            }
            else
            {
                Console.WriteLine($"{creature.Name} attacks {target.Name} with no item");
                _defenceLibrary.ReceiveHit(standardDamage, target);
                return standardDamage;
            }
        }
    }
}
