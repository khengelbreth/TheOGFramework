using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFramework.Model.Attack;
using TheFramework.Model.Creature;

namespace TheFramework.Interfaces
{
    public interface IAttackLibrary
    {
        public int Hit(AttackItem attackItem, Creature target, Creature creature);
    }
}
