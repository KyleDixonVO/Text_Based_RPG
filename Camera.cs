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

        public void Update(Player player, Map map)
        {

            if (player.x < ((cameraWidth/2)) || player.x > map.columns - cameraHeight)
            {

            }
            else
            {
                camOriginX = player.x;
            }

            if (player.y < 3 || player.y > map.rows - 5)
            {

            }
            else
            {
                camOriginY = player.y;
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
