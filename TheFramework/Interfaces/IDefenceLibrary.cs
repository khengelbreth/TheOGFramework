using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheFramework.Model.Creature;

namespace TheFramework.Interfaces
{
    public interface IDefenceLibrary
    {
        public void ReceiveHit(int damage, Creature creature);
    }
}
