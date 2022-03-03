using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class Money : Item
    {
        public bool obtained;
        public Money()
        {
            x = 8;
            y = 2;
            avatar = '$';
            obtained = false;
        }

        public void PickUpOnContact(Player player)
        {
            if (IsItemHere(player) == true && obtained == false)
            {
                player.money++;
                Console.Beep(900, 80);
                obtained = true;
            }
        }
    }
}
