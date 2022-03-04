using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class Door : GameObject
    {
        public bool doorOpened;
        public Door()
        {
            x = 3;
            y = 2;
            avatar = 'D';
            doorOpened = false;
        }

        public void OpenOnContact(Player player, Key key)
        {
            if (WillPlayerCollide(player) == true && player.Inventory.Contains(key) == true && doorOpened == false)
            {
                doorOpened = true;
                player.Inventory.Remove(key);
            }
        }

        public bool WillPlayerCollide(Player player)
        {
            if (player.futureX == this.x && player.futureY == this.y)
            {
                player.canMoveThere = false;
                return true;
            }

            return false;
        }
    }
}
