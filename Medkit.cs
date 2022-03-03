using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class Medkit : Item
    {
        private Random rd = new Random();
        private int healingAmount;
        public bool usedPack;

        public Medkit()
        {
            usedPack = false;
            avatar = 'H';
            x = 12;
            y = 8;
        }
       public void HealOnContact(Player player)
       {
            if (IsItemHere(player) && usedPack == false)
            {
                healingAmount = rd.Next(3, 12);
                player.health += healingAmount;
                if (player.health > player.maxHealth) { player.health = player.maxHealth; }
                Console.Beep(400, 50);
                Console.Beep(600, 75);
                usedPack = true;
            }

       }

    }
}
