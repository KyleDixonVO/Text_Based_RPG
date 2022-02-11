using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class Player: GameCharacter
    {
        private ConsoleKey input;
        private ConsoleKey UP = ConsoleKey.W;
        private ConsoleKey DOWN = ConsoleKey.S;
        private ConsoleKey LEFT = ConsoleKey.A;
        private ConsoleKey RIGHT = ConsoleKey.D;

        public void Move(Map map, Enemy enemy)
        {

            SaveLastPosition();
            input = Console.ReadKey(true).Key;
            if (input == UP)
            {
                y--;
            }
            else if (input == DOWN)
            {
                y++;
            }
            else if (input == LEFT)
            {
                x--;
            }
            else if (input == RIGHT)
            {
                x++;
            }

            if (map.isObjectSolid(x, y) == true)
            {
                RecallLastPosition();
            }

            if (IsGameCharacter(this, enemy))
            {
                enemy.TakeDamage();
                RecallLastPosition();
            }
        }

       
    }
}
