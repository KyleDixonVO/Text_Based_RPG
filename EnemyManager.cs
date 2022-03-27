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
        const int maxEnemies = 75;
        public Enemy[] enemies = new Enemy[maxEnemies];
        private Random rd = new Random();
        private int randomType;

        public void CreateEnemies()
        {
            enemies[0] = new Sentinel();
            enemies[0].name = ("Sentinel0");
            enemies[1] = new Sentinel();
            enemies[0].name = ("Sentinel1");
            for (int i = 2; i < maxEnemies; i++)
            {
                randomType = rd.Next(0, 2);
                if (randomType == 0)
                {
                    enemies[i] = new Tracker();
                    enemies[i].name = ("tracker" + i.ToString());
                }
                else if (randomType == 1)
                {
                    enemies[i] = new Spaz();
                    enemies[i].name = ("spaz" + i.ToString());
                }
                Console.WriteLine(enemies[i].GetName());
            }
            Console.ReadKey(true);
            Console.Clear();
        }

        public void MoveEnemies(Map map, Player player, EnemyManager enemyManager, HUD hud, Door door)
        {
            for (int j = 0; j < enemies.Length; j++)
            {
                if (enemies[j] != null)
                {
                    enemies[j].CalculateMovement(map, player, enemyManager, hud, door);
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

        public void Update(Map map, Player player, EnemyManager enemyManager, HUD hud, Door door)
        {
            CheckIfDead();
            MoveEnemies(map, player, enemyManager, hud, door);
        }
    }
}
