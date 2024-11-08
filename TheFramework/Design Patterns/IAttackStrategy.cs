using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFramework.Model.Creature;

namespace TheFramework.Design_Patterns
{
    /// <summary>
    /// Using this interface, we can create different attack strategies for creatures.
    /// When using the interface, you must implement a text describing,
    /// who attacks who and with what kind of attack.
    /// Each attack strategy should implement different damage.
    /// </summary>
    public interface IAttackStrategy
    {
        void Attack(Creature creature, Creature target);
    }

    public class MeleeAttack : IAttackStrategy
    {
        public void Attack(Creature creature, Creature target)
        {
            Console.WriteLine($"{creature.Name} angriber {target.Name} på nært hold.");
            target.HitPoints -= 10;  
            Console.WriteLine($"{target.Name} tog skade og har nu {target.HitPoints} HP tilbage.");
        }
    }

    public class RangedAttack : IAttackStrategy
    {
        public void Attack(Creature creature, Creature target)
        {
            Console.WriteLine($"{creature.Name} angriber {target.Name} på afstand.");
            target.HitPoints -= 7; 
            Console.WriteLine($"{target.Name} tog skade og har nu {target.HitPoints} HP tilbage.");
        }
    }
}
