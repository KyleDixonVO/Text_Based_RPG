using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{

    class PowerUp : Item
    {
        private int damageMultiplier;
        public bool usedPowerUp;
        public PowerUp()
        {
            avatar = 'P';
            x = 8;
            y = 8;
            damageMultiplier = 2;
            usedPowerUp = false;
        }

        public void PowerUpOnContact(Player player)
        {
            if (IsItemHere(player) == true && usedPowerUp == false)
            {
                player.damage = player.damage * damageMultiplier;
                usedPowerUp = true;
                Console.Beep(200, 80);
                Console.Beep(300, 80);
                Console.Beep(400, 80);
            }
        }
    }
}
