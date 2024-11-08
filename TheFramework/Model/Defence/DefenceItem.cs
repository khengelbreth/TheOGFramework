using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TheFramework.Worlds;

namespace TheFramework.Model.Defence
{
    public class DefenceItem : WorldObject
    {
        public int ReduceHitPoints { get; private set; }

        public DefenceItem(string name, int reduceHitPoints) : base(name, true, false)
        {
            ReduceHitPoints = reduceHitPoints;
        }

    }
}
