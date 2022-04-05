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
        public bool obtained = false;
        public bool IsItemHere(GameCharacter gameCharacter)
        {
            if (gameCharacter.futureX == this.x && gameCharacter.futureY == this.y)
            {
                return true;
            }

            return false;
        }

        public virtual void OnContact(Player player, Key key, Inventory inventory)
        {

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

        public override void OnContact(Player player, Key key, Inventory inventory)
        {
            if (IsItemHere(player) == true && used == false)
            {
                inventory.money++;
                Console.Beep(900, 80);
                used = true;
            }
        }
    }


    class Medkit : Item
    {
        private Random rd = new Random();
        private int healingAmount;

        public Medkit(int posX, int PosY)
        {
            used = false;
            avatar = 'H';
            x = posX;
            y = PosY;
            colorID = "medkit";
        }

        public override void OnContact(Player player, Key key, Inventory inventory)
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
        public PowerUp(int posX, int posY)
        {
            avatar = 'P';
            x = posX;
            y = posY;
            damageMultiplier = 2;
            used = false;
            colorID = "powerup";
        }

        public override void OnContact(Player player, Key key, Inventory inventory)
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
        public Key(int PosX, int PosY)
        {
            avatar = 'K';
            x = PosX;
            y = PosY;
            used = false;
            obtained = false;
            colorID = "key";
        }

        public override void OnContact(Player player, Key key, Inventory inventory)
        {
            if (IsItemHere(player) == true && obtained == false)
            {
                inventory.PlayerInventory.Add(key);
                obtained = true;
                colorID = "";
            }
        }
    }

}
