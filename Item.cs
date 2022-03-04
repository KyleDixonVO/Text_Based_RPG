using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class Item : GameObject
    {
        public string name;
        public bool IsItemHere(Player player)
        {
            if (player.futureX == this.x && player.futureY == this.y)
            {
                return true;
            }

            return false;
        }

    }


    class Money : Item
    {
        public bool obtained;
        public Money()
        {
            x = 3;
            y = 1;
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


    class PowerUp : Item
    {
        private int damageMultiplier;
        public bool usedPowerUp;
        public PowerUp()
        {
            avatar = 'P';
            x = 27;
            y = 3;
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

    class Key : Item
    {
        public bool usedKey;
        public bool obtained;
        public Key()
        {
            avatar = 'K';
            x = 16;
            y = 7;
            usedKey = false;
            obtained = false;
            name = "Key";
        }

        public void PickUpOnContact(Player player, Key key)
        {
            if (IsItemHere(player) == true && obtained == false)
            {
                player.Inventory.Add(key);
                obtained = true;
            }
        }
    }

}
