using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheFramework.Worlds
{
    /// <summary>
    /// This is supposed to represent objects inside the world
    /// </summary>
    public class WorldObject
    {
        /// <summary>
        /// This will be the name of the world object
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// This will represent if the object can be looted (picked up and used)
        /// </summary>
        public bool Lootable { get; set; }
        /// <summary>
        /// This will represent if the object can be removed from the world map
        /// </summary>
        public bool Removeable { get; set; }

        public WorldObject(string name, bool lootable, bool removeable)
        {
            Name = name;
            Lootable = lootable;
            Removeable = removeable;
        }
    }
}
