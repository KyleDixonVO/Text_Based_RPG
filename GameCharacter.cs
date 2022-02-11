using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    abstract class GameCharacter
    {
        public int LastX;
        public int LastY;
        public int health = 5;
        public int maxHealth = 5;
        public int x = 10;
        public int y = 10;
        public char avatar = '@';
        public bool dead = false;

        public void Initialize(int setHealth, int setX, int setY, char setAvatar)
        {
            maxHealth = setHealth;
            health = maxHealth;
            x = setX;
            y = setY;
            avatar = setAvatar;
        }

        public void TakeDamage()
        {
            health--;

            if (health <= 0)
            {
                health = 0;
                dead = true;
            }
        }

        public void ShowStats()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.BackgroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(1, 13);
            Console.Write(avatar + " health: " + health + "/" + maxHealth + " ");
            Console.ResetColor();
        }

        protected bool IsGameCharacter(Player player, Enemy enemy)
        {
            if (enemy != null)
            {
                if (player.x == enemy.x && player.y == enemy.y)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        protected void SaveLastPosition()
        {
            LastX = x;
            LastY = y;
        }

        protected void RecallLastPosition()
        {
            x = LastX;
            y = LastY;
        }
    }
}
