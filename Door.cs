using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class Door : GameObject
    {
        public bool doorOpened;
        public bool playerCollision;
        public Door()
        {
            x = 3;
            y = 2;
            avatar = 'D';
            doorOpened = false;
            playerCollision = false;
        }

        public void OpenWithKey(Inventory inventory, Key key)
        {
            if (key.obtained == true && doorOpened == false)
            {
                doorOpened = true;
                inventory.PlayerInventory.Remove(key);
            }
        }

        public bool WillEntityCollide(GameCharacter gameCharacter)
        {
            if (gameCharacter.futureX == x && gameCharacter.futureY == y && doorOpened == false)
            {
                gameCharacter.canMoveThere = false;
                return true;
            }

            return false;
        }

        public void Update(Player player, EnemyManager enemyManager, Key key, Inventory inventory)
        {
            OpenWithKey(inventory, key);
        }

        public void Draw(Renderer renderer, Camera camera)
        {
            if (doorOpened == false)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                renderer.Draw(x, y, avatar, camera);
                Console.ResetColor();
            }
        }
    }
}
