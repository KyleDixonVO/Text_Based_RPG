using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class Enemy : GameCharacter
    {
        protected int turnCount;
        protected bool blockedX = false;
        protected bool blockedY = false;
        protected bool playerHit = false;



        protected void CheckBlockedX()
        {
            if (futureX == lastX && playerHit == false)
            {
                blockedX = true;
            }
            else
            {
                blockedX = false;
            }
        }

        protected void CheckBlockedY()
        {
            if (futureY == lastY && playerHit == false)
            {
                blockedY = true;
            }
            else
            {
                blockedY = false;
            }
        }

        public virtual void CalculateMovement(Renderer renderer, Map map, Player player, EnemyManager enemyManager, HUD hud, Door door, Camera camera)
        {

        }

        public virtual void Draw(Renderer renderer, Camera camera)
        {

        }
    }
}
