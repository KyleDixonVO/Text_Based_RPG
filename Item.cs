using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class Item : GameObject
    {
        public bool used = false;
        public string colorID;
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
        public Money()
        {
            x = 3;
            y = 1;
            avatar = '$';
            used = false;
            colorID = "money";
        }

        public void PickUpOnContact(Player player)
        {
            if (IsItemHere(player) == true && used == false)
            {
                player.money++;
                Console.Beep(900, 80);
                used = true;
            }
        }
    }


    class Medkit : Item
    {
        private Random rd = new Random();
        private int healingAmount;

        public Medkit()
        {
            used = false;
            avatar = 'H';
            x = 12;
            y = 8;
            colorID = "medkit";
        }

        public void HealOnContact(Player player)
        {
            if (IsItemHere(player) && used == false)
            {
                healingAmount = rd.Next(3, 12);
                player.health += healingAmount;
                if (player.health > player.maxHealth) { player.health = player.maxHealth; }
                Console.Beep(400, 50);
                Console.Beep(600, 75);
                used = true;
            }

        }
    }


    class PowerUp : Item
    {
        private int damageMultiplier;
        public PowerUp()
        {
            avatar = 'P';
            x = 27;
            y = 3;
            damageMultiplier = 2;
            used = false;
            colorID = "powerup";
        }

        public void PowerUpOnContact(Player player)
        {
            if (IsItemHere(player) == true && used == false)
            {
                player.damage = player.damage * damageMultiplier;
                used = true;
                Console.Beep(200, 80);
                Console.Beep(300, 80);
                Console.Beep(400, 80);
            }
        }
    }

    class Key : Item
    {
        public bool obtained;
        public Key()
        {
            avatar = 'K';
            x = 16;
            y = 7;
            used = false;
            obtained = false;
            name = "Key";
            colorID = "key";
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
