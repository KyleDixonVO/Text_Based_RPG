using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class Tracker : Enemy
    {
        private int trackingY;
        private int trackingX;

        public Tracker(int posX, int posY)
        {
            damage = 1;
            avatar = 'T';
            health = 5;
            maxHealth = health;
            x = posX;
            y = posY;
        }

        public override void Draw(Renderer renderer, Camera camera)
        {
            renderer.Draw(x, y, avatar, camera);
        }

        public override void CalculateMovement(Renderer renderer, Map map, Player player, EnemyManager enemyManager, HUD hud, Door door, Camera camera)
        {

            
            if (turnCount == 2)
            {
                SaveLastPosition();
                playerHit = false;
                canMoveThere = true;

                //logic used to move toward the player
                if (trackingX > x && blockedX == false)
                {
                    deltaX = 1;
                    GetFuturePosition();
                    CheckBlockedX();
                }
                else if (trackingX < x && blockedX == false)
                {
                    deltaX = -1;
                    GetFuturePosition();
                    CheckBlockedX();
                }
                else if (trackingY > y && blockedY == false)
                {
                    deltaY = 1;
                    GetFuturePosition();
                    CheckBlockedY();
                }
                else if (trackingY < y && blockedY == false)
                {
                    deltaY = -1;
                    GetFuturePosition();
                    CheckBlockedY();
                }

                //detecting collision with solid objects
                if (renderer.IsObjectSolid(futureX, futureY, map))
                {
                    canMoveThere = false;
                }

                //detecting collision with player
                if (IsGameCharacter(this, player))
                {
                    Console.Beep(200, 33);
                    Console.Beep(100, 33);
                    player.TakeDamage(damage);
                    this.canMoveThere = false;
                    playerHit = true;
                    hud.ShowPlayerStats(ref player);
                    hud.ShowEnemyStats(this);
                }

                for (int i = 0; i < enemyManager.enemies.Length; i++)
                {
                    if (IsGameCharacter(this, enemyManager.enemies[i]) == true)
                    {
                        canMoveThere = false;
                    }
                }

                if (door.WillEntityCollide(this))
                {
                    canMoveThere = false;
                }


                Move();
                turnCount = 0;
            }

            //updating turn count and tracking info
            turnCount++;
            trackingY = player.y;
            trackingX = player.x;
        }
    }
}
