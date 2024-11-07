using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFramework.Model.Creature;

namespace TheFramework.Design_Patterns
{
    public interface ICreatureFactory
    {
        public Creature CreateCreature(string type, string name);
    }
}
