using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Test_Based_RPG
{
    class Renderer
    {
        public void Draw(int worldX, int worldY, char Avatar, Camera camera)
        {
            int screenX = worldX - camera.camOriginX;
            int screenY = worldY - camera.camOriginY;

            screenX += camera.cameraWidth/2;
            screenY += camera.cameraHeight/2;

            if (screenX < camera.worldCamX || screenX > camera.worldCamX + camera.cameraWidth || screenY < camera.worldCamY || screenY > camera.worldCamY + camera.cameraHeight) return;

            Console.SetCursorPosition(screenX, screenY);

            if (screenX < 0 || screenY < 0)
            {
                Console.Write(" ");
            }
            else
            {
                Console.Write(Avatar);
            }
            
        }

        public bool IsObjectSolid(int testX, int testY, Map map)
        {
            if (map.mapTiles[testY, testX] == '^' || map.mapTiles [testY,testX] == '~' || map.mapTiles[testY, testX] == '║' || map.mapTiles[testY,testX] == '═' || map.mapTiles[testY, testX] == '*')
            {
                return true;
            }
            return false;
        }

        public void SetTileColor(char tile)
        {
            if (tile == '^')
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
            else if (tile == '~')
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (tile == '*')
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            else if (tile == ',')
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void SetItemColor(ItemManager itemManager, int i)
        {
            if (itemManager.items[i].colorID == "money")
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.BackgroundColor = ConsoleColor.Green;
            }
            else if (itemManager.items[i].colorID == "medkit")
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Red;
            }
            else if (itemManager.items[i].colorID == "powerup")
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Blue;
            }
            else if (itemManager.items[i].colorID == "key")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.DarkYellow;
            }
        }
    }
}
