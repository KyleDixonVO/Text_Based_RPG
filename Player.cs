using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class Player: GameCharacter
    {
        private ConsoleKey input;
        private readonly ConsoleKey UP = ConsoleKey.W;
        private readonly ConsoleKey DOWN = ConsoleKey.S;
        private readonly ConsoleKey LEFT = ConsoleKey.A;
        private readonly ConsoleKey RIGHT = ConsoleKey.D;
        public List<Item> Inventory;
        public int money;
        public Player()
        {
            damage = 1;
            health = 15;
            maxHealth = health;
            x = 10;
            y = 10;
            avatar = '@';
            money = 0;
            Inventory = new List<Item>();
        }
        public void CalculateMovement(Map map, EnemyManager enemyManager, HUD hud)
        {

            SaveLastPosition();
            canMoveThere = true;
            input = Console.ReadKey(true).Key;
            if (input == UP || input == ConsoleKey.UpArrow)
            {
                deltaY = -1;
            }
            else if (input == DOWN || input == ConsoleKey.DownArrow)
            {
                deltaY = 1;
            }
            else if (input == LEFT || input == ConsoleKey.LeftArrow)
            {
                deltaX = -1;
            }
            else if (input == RIGHT || input == ConsoleKey.RightArrow)
            {
                deltaX = +1;
            }

            GetFuturePosition();

            if (map.IsObjectSolid(futureX, futureY) == true)
            {
                Console.Beep(250, 33);
                canMoveThere = false;
            }

            for (int i = 0; i < enemyManager.enemies.Length; i ++)
            {
                if (enemyManager.enemies[i] != null)
                {
                    if (IsGameCharacter(this, enemyManager.enemies[i], hud))
                    {
                        enemyManager.enemies[i].TakeDamage(damage);
                        hud.ShowEnemyStats(enemyManager.enemies[i]);
                        Console.Beep(300, 33);
                        Console.Beep(400, 33);
                        canMoveThere = false;
                    }
                }
            }
            
            Move();
        }

        public void ShowInventory(Map map)
        {
            Console.SetCursorPosition(map.columns + 5, 0);
            Console.Write("Money: " + money);
            Console.SetCursorPosition(map.columns + 5, 1);
            Console.Write("Player Inventory: ");
            int i = 2;
            foreach (Item item in Inventory)
            {
                Console.SetCursorPosition(map.columns + 5, i);
                Console.Write(item.name);
                i++;
            }
        }

       
    }
}
