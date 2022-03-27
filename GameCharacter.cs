using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    abstract class GameCharacter : GameObject
    {
        public int deltaX;
        public int deltaY;
        public int futureX;
        public int futureY;
        public int lastX;
        public int lastY;
        public int health = 5;
        public int maxHealth = 5;
        public int damage = 1;
        public bool dead = false;
        public bool canMoveThere;
        public static Random rd = new Random();
        public void Initialize(int setHealth, int setX, int setY, char setAvatar)
        {
            maxHealth = setHealth;
            health = maxHealth;
            x = setX;
            y = setY;
            avatar = setAvatar;
        }

        public void TakeDamage(int damage)
        {
            health -= damage;

            if (health <= 0)
            {
                health = 0;
                dead = true;
            }
        }

        

        protected bool IsGameCharacter(GameCharacter gameCharacter, GameCharacter gameCharacter1)
        {
            if (gameCharacter == null || gameCharacter1 == null) return false; 
            
            if ((gameCharacter.futureX == gameCharacter1.x && gameCharacter.futureY == gameCharacter1.y)) //|| (gameCharacter.x == gameCharacter1.futureX && gameCharacter.y == gameCharacter1.futureY))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void GetFuturePosition()
        {
            futureX = x + deltaX;
            futureY = y + deltaY;
        }

        protected void SaveLastPosition()
        {
            lastX = x;
            lastY = y;
        }

        public void Move()
        {
            if (canMoveThere == true)
            {
                y = futureY;
                x = futureX;
            }

            deltaX = 0;
            deltaY = 0;
        }
    }
}
