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
        public Door()
        {
            x = 3;
            y = 2;
            avatar = 'D';
            doorOpened = false;
        }

        public void OpenWithKey(Player player, Key key)
        {
            if (key.obtained == true && doorOpened == false)
            {
                doorOpened = true;
                player.Inventory.Remove(key);
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

        public void Update(Player player, EnemyManager enemyManager, Key key)
        {
            OpenWithKey(player, key);
        }
    }
}
