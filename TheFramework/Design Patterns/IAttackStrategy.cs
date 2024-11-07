using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFramework.Model.Creature;

namespace TheFramework.Design_Patterns
{
    public interface IAttackStrategy
    {
        void Attack(Creature creature, Creature target);
    }

    public class MeleeAttack : IAttackStrategy
    {
        public void Attack(Creature creature, Creature target)
        {
            Console.WriteLine($"{creature.Name} angriber {target.Name} på nært hold.");
            target.HitPoints -= 10;  // Eksempel på skade ved nærkamp
        }
    }

    public class RangedAttack : IAttackStrategy
    {
        public void Attack(Creature creature, Creature target)
        {
            Console.WriteLine($"{creature.Name} angriber {target.Name} på afstand.");
            target.HitPoints -= 7;  // Eksempel på skade ved afstandsangreb
        }
    }
}
