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
        private int randomType;

        public void CreateEnemies()
        {
            enemies[0] = new Sentinel(3, 25);
            enemies[0].name = ("Sentinel0");
            enemies[1] = new Sentinel(22, 22);
            enemies[0].name = ("Sentinel1");
            for (int i = 2; i < maxEnemies; i++)
            {
                if (i < 28)
                {
                    enemies[i] = new Spaz(rd.Next(20, 40), rd.Next(19, 27));
                    enemies[i].name = ("spaz" + i.ToString());
                }
                else
                {
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
                if (enemies[j] != null)
                {
                    enemies[j].CalculateMovement(renderer, map, player, enemyManager, hud, door, camera);
                }
            }
        }

        public void CheckIfDead()
        {
            for (int i = 0; i < maxEnemies; i++)
            {   if (enemies[i] == null) { return; }
                if (enemies[i].dead == true)
                {
                    NullEnemy(enemies[i]);
                }
            }
        }

        public void NullEnemy(Enemy enemy)
        {
            enemy = null;
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
                renderer.Draw(enemies[i].x, enemies[i].y, enemies[i].avatar, camera);
            }
        }
    }
}
