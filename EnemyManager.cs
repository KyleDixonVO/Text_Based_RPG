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
        public int maxEnemies = 10;
        public List<Enemy> enemies = new List<Enemy>();
        public int[] enemyTypes = new int[3];

        public void CreateEnemies()
        {
            for (int i = 0; i < maxEnemies; i++)
            {
                Random rd = new Random();
                int randomType = rd.Next(0, 2);
                if (randomType == 0)
                {
                    Tracker tracker = new Tracker();
                    enemies.Add(tracker);
                }
                else if (randomType == 1)
                {
                    Spaz spaz = new Spaz();
                    enemies.Add(spaz);
                }
                else if (randomType == 2)
                {
                    Sentinel sentinel = new Sentinel();
                    enemies.Add(sentinel);
                }

            }
        }

        public void CheckIfDead()
        {
            foreach (Enemy enemy in enemies)
            {
                if (enemy.dead == true)
                {
                    NullEnemy(enemy);
                }
            }
        }

        public void NullEnemy(Enemy enemy)
        {
            enemy = null;
        }
    }
}
