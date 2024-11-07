using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using TheFramework.Worlds;

namespace TheFramework.Model.Attack
{
    public class AttackItem : WorldObject
    {
        public int Hit { get; private set; }
        public int Range { get; private set; }

        public AttackItem(string name, int hit, int range) : base(name, true, false)
        {
            Hit = hit;
            Range = range;
        }

        public override string ToString()
        {
            return $"{{{nameof(Name)}={Name}, {nameof(Hit)}={Hit.ToString()}, {nameof(Range)}={Range.ToString()}}}";
        }
    }
}
