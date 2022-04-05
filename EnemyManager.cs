using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class EnemyManager
    {
        //handles creating and nulling of enemies
        const int maxEnemies = 32;
        public Enemy[] enemies = new Enemy[maxEnemies];
        private Random rd = new Random();
        private int nextX;
        private int nextY;

        public void CreateEnemies(Map map, Renderer renderer)
        {
            enemies[0] = new Sentinel(3, 25);
            enemies[0].name = ("Sentinel0");
            enemies[1] = new Sentinel(22, 22);
            enemies[0].name = ("Sentinel1");
            for (int i = 2; i < maxEnemies; i++)
            {
                if (i < 28)
                {
                    IsSpawnValid(20, 40, 19, 27, renderer, map);
                    enemies[i] = new Spaz(nextX, nextY);
                    enemies[i].name = ("spaz" + i.ToString());
                }
                else
                {
                    IsSpawnValid(33, 40, 2, 6, renderer, map);
                    enemies[i] = new Tracker(rd.Next(33, 40), rd.Next(2, 6));
                    enemies[i].name = ("tracker" + i.ToString());
                }
                Console.WriteLine(enemies[i].GetName());
            }
            Console.ReadKey(true);
            Console.Clear();
        }

        public void MoveEnemies(Renderer renderer, Map map, Player player, EnemyManager enemyManager, HUD hud, Door door, Camera camera)
        {
            for (int j = 0; j < enemies.Length; j++)
            {
                if (enemies[j].dead == false)
                {
                    enemies[j].CalculateMovement(renderer, map, player, enemyManager, hud, door, camera);
                }
            }
        }

        public void CheckIfDead()
        {
            for (int i = 0; i < maxEnemies; i++)
            {   
                if (enemies[i] == null) { return; }
                if (enemies[i].dead == true)
                {
                    enemies[i].y = Console.WindowHeight + Console.CursorTop;
                    enemies[i].x = Console.WindowWidth + Console.WindowLeft;
                    enemies[i].futureX = Console.WindowHeight + Console.CursorTop;
                    enemies[i].futureY = Console.WindowWidth + Console.WindowLeft;
                }
            }
        }

        public void NullEnemy(Enemy[] enemies, int i)
        {
            Console.SetCursorPosition(Console.WindowLeft + 1, Console.WindowTop + 18);
            Console.Write("                            ");
            Console.Write("Enemy: " + enemies[i].name + " is about to be nulled");
            enemies[i] = null;
        }

        public void Update(Renderer renderer, Map map, Player player, EnemyManager enemyManager, HUD hud, Door door, Camera camera)
        {
            CheckIfDead();
            MoveEnemies(renderer, map, player, enemyManager, hud, door, camera);
        }

        public void Draw(Renderer renderer, Camera camera)
        {
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i] == null) return;
                if (enemies[i].dead == true)
                {
                    renderer.Draw(enemies[i].x, enemies[i].y, '\0', camera);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    renderer.Draw(enemies[i].x, enemies[i].y, enemies[i].avatar, camera);
                    Console.ResetColor();
                }
                
            }
        }

        public void IsSpawnValid(int MinX, int MaxX, int MinY, int MaxY, Renderer renderer, Map map)
        {
            int valueX = rd.Next(MinX, MaxX);
            int valueY = rd.Next(MinY, MaxY);
            if (renderer.IsObjectSolid(valueX, valueY, map) == true)
            {
                IsSpawnValid(MinX, MaxX, MinY, MaxY, renderer, map);
            }
            else
            {
                nextX = valueX;
                nextY = valueY;
            }
        }
    }
}
