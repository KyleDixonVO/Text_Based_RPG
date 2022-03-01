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
        private readonly ConsoleKey UP = ConsoleKey.W;
        private readonly ConsoleKey DOWN = ConsoleKey.S;
        private readonly ConsoleKey LEFT = ConsoleKey.A;
        private readonly ConsoleKey RIGHT = ConsoleKey.D;
        public new char avatar = '@';

        public void CalculateMovement(Map map, Enemy enemy)
        {
            SaveLastPosition();
            canMoveThere = true;
            input = Console.ReadKey(true).Key;
            if (input == UP || input == ConsoleKey.UpArrow)
            {
                deltaY = -1;
            }
            else if (input == DOWN || input == ConsoleKey.DownArrow)
            {
                deltaY = 1;
            }
            else if (input == LEFT || input == ConsoleKey.LeftArrow)
            {
                deltaX = -1;
            }
            else if (input == RIGHT || input == ConsoleKey.RightArrow)
            {
                deltaX = +1;
            }

            GetFuturePosition();

            if (map.IsObjectSolid(futureX, futureY) == true)
            {
                Console.Beep(250, 33);
                canMoveThere = false;
            }

            if (IsGameCharacter(this, enemy))
            {
                Console.Beep(400, 33);
                Console.Beep(500, 33);
                enemy.TakeDamage();
                canMoveThere = false;
            }

            Move();
        }

       
    }
}
