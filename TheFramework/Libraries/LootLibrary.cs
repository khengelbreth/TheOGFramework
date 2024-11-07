using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFramework.Interfaces;
using TheFramework.Model.Attack;
using TheFramework.Model.Creature;
using TheFramework.Model.Defence;
using TheFramework.Worlds;

namespace TheFramework.Libraries
{
    public class LootLibrary : ILootLibrary
    {
        public void Loot(Creature creature, WorldObject worldObject)
        {

            if (worldObject.Lootable)
            {
                Console.WriteLine($"{creature.Name} attempts to loot {worldObject.Name}.");

                switch (worldObject)
                {
                    case DefenceItem defence:
                        creature.DefenceItems.Add(defence);
                        Console.WriteLine($"The {worldObject.Name} gives {defence.ReduceHitPoints} defense.");
                        break;

                    case AttackItem attack:
                        creature.AttackItems.Add(attack);
                        Console.WriteLine($"The {worldObject.Name} gives {attack.Hit} damage with a range of {attack.Range}.");
                        break;

                    default:
                        Console.WriteLine($"{creature.Name} cannot loot {worldObject.Name} as it is of unknown type.");
                        break;
                }
            }
            else
            {
                Console.WriteLine($"{creature.Name} cannot loot {worldObject.Name} as it is not lootable.");
            }
        }
    }
}
