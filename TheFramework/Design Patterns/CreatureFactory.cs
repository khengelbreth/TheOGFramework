using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFramework.Interfaces;
using TheFramework.Model.Attack;
using TheFramework.Model.Creature;
using TheFramework.Model.Defence;

namespace TheFramework.Design_Patterns
{
    public class CreatureFactory : ICreatureFactory
    {
        private readonly IAttackLibrary _attackLibrary;
        private readonly IDefenceLibrary _defenceLibrary;
        private readonly ILootLibrary _lootLibrary;

        public CreatureFactory(IAttackLibrary attackLibrary, IDefenceLibrary defenceLibrary, ILootLibrary lootLibrary)
        {
            _attackLibrary = attackLibrary;
            _defenceLibrary = defenceLibrary;
            _lootLibrary = lootLibrary;
        }
        public Creature CreateCreature(string type, string name)
        {
            var creature = new Creature(_attackLibrary, _defenceLibrary, _lootLibrary) { Name = name };

            switch (type.ToLower())
            {
                case "warrior":
                    creature.HitPoints = 150;
                    creature.AddAttackItem(new AttackItem("Sword", 15, 1));
                    creature.AddDefenceItem(new DefenceItem("Shield", 5));
                    break;

                case "mage":
                    creature.HitPoints = 80;
                    creature.AddAttackItem(new AttackItem("Wand", 10, 5));
                    creature.AddDefenceItem(new DefenceItem("Shieldpotion", 10));
                    break;

                case "archer":
                    creature.HitPoints = 100;
                    creature.AddAttackItem(new AttackItem("Bow", 12, 8));
                    creature.AddDefenceItem(new DefenceItem("Shield", 5));
                    break;

                default:
                    throw new ArgumentException($"\nCreature type '{type}' is not recognized.");
            }

            return creature;
        }
    }
}
