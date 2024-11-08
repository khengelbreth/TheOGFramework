using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFramework.Design_Patterns;
using TheFramework.Interfaces;
using TheFramework.Model.Attack;
using TheFramework.Model.Defence;
using TheFramework.Worlds;

namespace TheFramework.Model.Creature
{
    /// <summary>
    /// Represents a creature in the world
    /// </summary>
    public class Creature
    {
        /// <summary>
        /// The name of the creature
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The hit points of the creature
        /// </summary>
        public int HitPoints { get; set; }

        private readonly IAttackLibrary _attackLibrary;
        private readonly IDefenceLibrary _defenceLibrary;
        private readonly ILootLibrary _lootLibrary;
        private IAttackStrategy _attackStrategy;

        /// <summary>
        /// List of attack items owned by the creature
        /// </summary>
        public List<AttackItem> AttackItems { get; private set; }

        /// <summary>
        /// List of defense items owned by the creature
        /// </summary>
        public List<DefenceItem> DefenceItems { get; private set; }

        /// <summary>
        /// Constructor to initialize a Creature with dependencies for attack, defense, and loot
        /// </summary>
        public Creature(IAttackLibrary attackLibrary, IDefenceLibrary defenceLibrary, ILootLibrary lootLibrary)
        {
            _attackLibrary = attackLibrary;
            _defenceLibrary = defenceLibrary;
            _lootLibrary = lootLibrary;

            Name = string.Empty;
            HitPoints = 100;
            AttackItems = new List<AttackItem>();
            DefenceItems = new List<DefenceItem>();
        }

        /// <summary>
        /// Sets the attack strategy for the creature
        /// </summary>
        public void SetAttackStrategy(IAttackStrategy attackStrategy)
        {
            _attackStrategy = attackStrategy;
        }

        /// <summary>
        /// Performs an attack on a target using the selected strategy
        /// </summary>
        public void PerformAttack(Creature target)
        {
            if (_attackStrategy != null)
            {
                _attackStrategy.Attack(this, target);
            }
            else
            {
                Console.WriteLine($"{Name} has no attack strategy selected!");
            }
        }

        /// <summary>
        /// Performs a library-based attack on a target
        /// </summary>
        public void LibraryAttack(Creature target)
        {
            _attackLibrary.Hit(this, target);
        }

        /// <summary>
        /// Loots an object in the world if possible
        /// </summary>
        public void Loot(WorldObject worldObject)
        {
            _lootLibrary.Loot(this, worldObject);
        }

        /// <summary>
        /// Adds an attack item to the creature's inventory
        /// </summary>
        public void AddAttackItem(AttackItem attackItem)
        {
            AttackItems.Add(attackItem);
        }

        /// <summary>
        /// Adds a defense item to the creature's inventory
        /// </summary>
        public void AddDefenceItem(DefenceItem defenceItem)
        {
            DefenceItems.Add(defenceItem);
        }
    }
}
