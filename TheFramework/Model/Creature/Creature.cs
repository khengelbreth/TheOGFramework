using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFramework.Design_Patterns;
using TheFramework.Model.Attack;
using TheFramework.Model.Defence;

namespace TheFramework.Model.Creature
{
    /// <summary>
    /// Represents a creature in the world
    /// </summary>
    public class Creature
    {
        /// <summary>
        /// This will be the name of the creature
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// This will be the amount of hitpoints a creature has
        /// </summary>
        public int HitPoints { get; set; }


        // Todo consider how many attack / defence weapons are allowed
        public List<AttackItem> AttackItems { get; private set; }
        public List<DefenceItem> DefenceItems { get; private set; }

        public Creature()
        {
            Name = string.Empty;
            HitPoints = 100;

            AttackItems = new List<AttackItem>();
            DefenceItems = new List<DefenceItem>();

        }

        public void AddAttackItem(AttackItem attackItem)
        {
            AttackItems.Add(attackItem);
        }

        public void AddDefenceItem(DefenceItem defenceItem)
        {
            DefenceItems.Add(defenceItem);
        }

        private IAttackStrategy _attackStrategy;

        public void SetAttackStrategy(IAttackStrategy attackStrategy)
        {
            _attackStrategy = attackStrategy;
        }

        public void PerformAttack(Creature target)
        {
            if (_attackStrategy != null)
            {
                _attackStrategy.Attack(this, target);
            }
            else
            {
                Console.WriteLine($"{Name} har ingen angrebsstrategi valgt!");
            }
        }

    }
}
