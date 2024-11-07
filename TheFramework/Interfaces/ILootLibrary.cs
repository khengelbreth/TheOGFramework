using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFramework.Model.Creature;
using TheFramework.Worlds;

namespace TheFramework.Interfaces
{
    public interface ILootLibrary
    {
        public void Loot(Creature creature, WorldObject worldObject);
    }
}
