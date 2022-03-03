using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class Item : GameObject
    {
        public bool IsItemHere(Player player)
        {
            if (player.futureX == this.x && player.futureY == this.y)
            {
                return true;
            }

            return false;
        }
    }
}
