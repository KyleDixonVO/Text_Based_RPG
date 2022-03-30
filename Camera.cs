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
        public int camOriginX;
        public int camOriginY;
        public int cameraWidth;
        public int cameraHeight;
        public int bufferX;
        public int bufferY;
        public int worldCamX;
        public int worldCamY;

        public Camera()
        {
            windowHeight = 40;
            windowWidth = 40;
            cameraHeight = 7;
            cameraWidth = 11;
            bufferX = 50;
            bufferY = 50;
            camOriginX = 1;
            camOriginY = 1;
            worldCamX = 0;
            worldCamY = 0;

            Console.SetWindowSize(1, 1);
            Console.SetBufferSize(bufferX, bufferY);
            Console.SetWindowSize(windowWidth, windowHeight);
        }

        public bool InCameraWindow(int x, int y)
        {
            if (x < camOriginX || x > camOriginX + windowWidth || y < camOriginY || y > camOriginY + windowHeight)
            {
                return false;
            }

            return true;
        }

        public void Update(Player player)
        {
            camOriginX = player.x;
            camOriginY = player.y;
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
