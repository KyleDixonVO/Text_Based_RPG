using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class Spaz : Enemy
    {

        public Spaz()
        {
            damage = 3;
            avatar = 'Z';
            health = 2;
            maxHealth = health;
            x = 5;
            y = 7;
        }

        public override void CalculateMovement(Map map, Player player, EnemyManager enemyManager, HUD hud, Door door)
        {
            SaveLastPosition();
            canMoveThere = true;
            int moveDirection = rd.Next(0,4);
            if (moveDirection == 0)
            {
                deltaX = 1;
            }
            else if (moveDirection == 1)
            {
                deltaX = -1;
            }
            else if (moveDirection == 2)
            {
                deltaY = 1;
            }
            else if (moveDirection == 3)
            {
                deltaY = -1;
            }

            GetFuturePosition();

            if (map.IsObjectSolid(futureX, futureY) == true)
            {
                canMoveThere = false;
            }

            if (IsGameCharacter(this, player) == true)
            {
                Console.Beep(200, 33);
                Console.Beep(100, 33);
                player.TakeDamage(damage);
                canMoveThere = false;
                hud.ShowPlayerStats(player, map);
            }

            for (int i = 0; i < enemyManager.enemies.Length; i++)
            {
                if (enemyManager.enemies[i] != null)
                {
                    if (IsGameCharacter(this, enemyManager.enemies[i]) == true && (this != enemyManager.enemies[i]))
                    {
                        canMoveThere = false;
                    }
                }
            }

            if (door.WillEntityCollide(this))
            {
                canMoveThere = false;
            }

            Move();
            
        }
    }
}
