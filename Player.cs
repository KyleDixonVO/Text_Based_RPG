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
        public int direction;
        public Player()
        {
            damage = 1;
            health = 15;
            maxHealth = health;
            x = 10;
            y = 10;
            avatar = '@';
           
        }
        public void CalculateMovement(Map map, EnemyManager enemyManager, HUD hud, Door door, Camera camera)
        {

            SaveLastPosition();
            canMoveThere = true;
            input = Console.ReadKey(true).Key;
            if (input == UP || input == ConsoleKey.UpArrow)
            {
                deltaY = -1;
                direction = 1;
            }
            else if (input == DOWN || input == ConsoleKey.DownArrow)
            {
                deltaY = 1;
                direction = 2;
            }
            else if (input == LEFT || input == ConsoleKey.LeftArrow)
            {
                deltaX = -1;
                direction = 3;
            }
            else if (input == RIGHT || input == ConsoleKey.RightArrow)
            {
                deltaX = +1;
                direction = 4;
            }

            GetFuturePosition();

            if (map.IsObjectSolid(futureX, futureY) == true)
            {
                Console.Beep(250, 33);
                canMoveThere = false;
                direction = 0;
            }

            for (int i = 0; i < enemyManager.enemies.Length; i ++)
            {
                if (enemyManager.enemies[i] != null)
                {
                    if (IsGameCharacter(this, enemyManager.enemies[i]))
                    {
                        enemyManager.enemies[i].TakeDamage(damage);
                        hud.ShowEnemyStats(enemyManager.enemies[i], map, camera);
                        Console.Beep(300, 33);
                        Console.Beep(400, 33);
                        canMoveThere = false;
                        direction = 0;
                    }
                }
            }

            if (door.WillEntityCollide(this))
            {
                Console.Beep(250, 33);
                canMoveThere = false;
                direction = 0;
            }
            
            Move();
        } 
    }
}
