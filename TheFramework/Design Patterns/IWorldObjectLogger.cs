using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFramework.Worlds;

namespace TheFramework.Design_Patterns
{
    public interface IWorldObjectObserver
    {
        void OnWorldObjectCreated(WorldObject worldObject);
    }
}
