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
        /// This will hit and damage a creature
        /// </summary>
        /// <param name="attackItem">This is an item, that the creature uses to attack</param>
        /// <param name="target">This is the target that is getting damaged</param>
        /// <param name="creature">This is the creature that is supposed to hit the target</param>
        /// <returns>Returns 5 as damage, if the creature has no attacking item</returns>
        public int Hit(AttackItem attackItem, Creature target, Creature creature)
        {
            int standartDamage = 5;
            if (creature.AttackItems.Contains(attackItem))
            {
                Console.WriteLine($"{creature.Name} attacks {target.Name} with {attackItem.Name}");
                _defenceLibrary.ReceiveHit(attackItem.Hit + standartDamage, target);
            }
            Console.WriteLine($"{creature.Name} attacks {target.Name} with no item");
            _defenceLibrary.ReceiveHit(standartDamage, target);
            return standartDamage;
        }

        public int Hit2(Creature creature, Creature target)
        {
            int standardDamage = 5;
            var strongestAttackItem = creature.AttackItems.OrderByDescending(a => a.Hit).FirstOrDefault();
            if (strongestAttackItem != null)
            {
                Console.WriteLine($"{creature.Name} attacks {target.Name} with {strongestAttackItem.Name}");
                _defenceLibrary.ReceiveHit(strongestAttackItem.Hit + standardDamage, target);
            }
            Console.WriteLine($"{creature.Name} attacks {target.Name} with no item");
            _defenceLibrary.ReceiveHit(standardDamage, target);
            return standardDamage;
        }
    }
}
