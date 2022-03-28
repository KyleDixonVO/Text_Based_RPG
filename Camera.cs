using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Based_RPG
{
    class Camera
    {
        public int windowHeight;
        public int windowWidth;
        public int deltaX;
        public int deltaY;
        public int bufferX;
        public int bufferY;

        public Camera()
        {
            windowHeight = 20;
            windowWidth = 40;
            bufferX = 120;
            bufferY = 120;
            deltaX = 0;
            deltaY = 0;
            
            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(bufferX, bufferY);
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(windowWidth, windowHeight);
        }

        public bool InCameraWindow(int x, int y)
        {
            if (x < Console.WindowLeft || x > Console.WindowLeft + windowWidth || y < Console.WindowTop || y > Console.WindowTop + windowHeight)
            {
                return false;
            }

            return true;
        }

        public void Update(Player player)
        {
            if (player.direction == 1 && player.movedLastTurn == true)
            {
                deltaX = 0;
                deltaY = 1;
            }
            else if (player.direction == 2 && player.movedLastTurn == true)
            {
                deltaX = 0;
                deltaY = -1;
            }
            else if (player.direction == 3 && player.movedLastTurn == true)
            {
                deltaX = -1;
                deltaY = 0;
            }
            else if (player.direction == 4 && player.movedLastTurn == true)
            {
                deltaX = 1;
                deltaY = 0;
            }
            else
            {
                deltaX = 0;
                deltaY = 0;
            }

            if (0 <= Console.WindowLeft + deltaX && Console.WindowLeft + deltaX <= bufferX && 0 <= Console.WindowTop + deltaY && Console.WindowTop + deltaY <= bufferY)
            {
                //Console.SetWindowPosition(Console.WindowLeft + deltaX, Console.WindowTop + deltaY);
                Console.SetWindowPosition(Clamp(player.x - 20, 0, player.x - 20), Clamp(player.y - 10, 0, player.y -10));
                //Console.Write(Console.WindowTop + " " + Console.WindowLeft + " " + deltaX + " " + deltaY + " " + player.direction.ToString());
            }
        }

        protected int Clamp(int value, int MinOffset, int MaxOffset)
        {
            if (value > MaxOffset)
            {
                value = MaxOffset;
            }
            else if (value < MinOffset)
            {
                value = MinOffset;
            }
            return value;
        }
    }
}
