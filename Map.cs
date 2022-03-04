using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Test_Based_RPG
{
    class Map
    {
        public int rows;
        public int columns;
        private bool hasMapInitialized = false;
        private char[,] mapTiles;

        private string[] dataFromFile;
        private char[] charsFromFile;
        public void Update(Player player, ref Tracker tracker, ref Spaz spaz, ref Sentinel sentinel, Medkit medkit, PowerUp powerUp, Money money, Key key, Door door)
        {
            DrawMap(player, tracker, spaz, sentinel);
            DrawEntities(player, ref tracker, ref spaz, ref sentinel, medkit, powerUp, money, key, door);
        }

        private void DrawEntities(Player player, ref Tracker tracker, ref Spaz spaz, ref Sentinel sentinel, Medkit medkit, PowerUp powerUp, Money money, Key key, Door door)
        {
            //drawing player
            Console.SetCursorPosition(player.x, player.y);
            Console.Write(player.avatar);

            if (medkit.usedPack == false)
            {
                
                Console.SetCursorPosition(medkit.x, medkit.y);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.Write(medkit.avatar);
                Console.ResetColor();
            }   

            if (powerUp.usedPowerUp == false)
            {
                Console.SetCursorPosition(powerUp.x, powerUp.y);
                Console.BackgroundColor = ConsoleColor.Blue;
                Console.Write(powerUp.avatar);
                Console.ResetColor();
            }

            if (money.obtained == false)
            {
                Console.SetCursorPosition(money.x, money.y);
                Console.BackgroundColor = ConsoleColor.DarkGreen;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(money.avatar);
                Console.ResetColor();
            }

            if (key.obtained == false)
            {
                Console.SetCursorPosition(key.x, key.y);
                Console.BackgroundColor = ConsoleColor.Yellow;
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write(key.avatar);
                Console.ResetColor();
            }

            if (door.doorOpened == false)
            {
                Console.SetCursorPosition(door.x, door.y);
                Console.BackgroundColor = ConsoleColor.DarkYellow;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(door.avatar);
                Console.ResetColor();
            }

            //drawing enemy
            if (tracker == null) { }
            else if (tracker.dead == false)
            {
                Console.SetCursorPosition(tracker.x, tracker.y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(tracker.avatar);
                Console.ResetColor();
            }
            else
            {
                tracker.avatar = ' ';
                Console.SetCursorPosition(tracker.x, tracker.y);
                Console.Write(tracker.avatar);
                tracker = null;
            }

            //drawing enemy
            if (spaz == null) { }
            else if (spaz.dead == false)
            {
                Console.SetCursorPosition(spaz.x, spaz.y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(spaz.avatar);
                Console.ResetColor();
            }
            else
            {
                spaz.avatar = ' ';
                Console.SetCursorPosition(spaz.x, spaz.y);
                Console.Write(spaz.avatar);
                spaz = null;
            }

            //drawing enemy
            if (sentinel == null) { }
            else if (sentinel.dead == false)
            {
                Console.SetCursorPosition(sentinel.x, sentinel.y);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(sentinel.avatar);
                Console.ResetColor();
            }
            else
            {
                sentinel.avatar = ' ';
                Console.SetCursorPosition(sentinel.x, sentinel.y);
                Console.Write(sentinel.avatar);
                sentinel = null;
            }
        }

        

        private void SetBounds()
        {
            Console.SetWindowSize((columns * 2), (rows*2));
            Console.SetBufferSize((columns * 2), (rows *2));
        }

        private void DrawMap(Player player, Tracker tracker, Spaz spaz, Sentinel sentinel)
        {
            Console.SetCursorPosition(0, 0);
            if (hasMapInitialized == false)
            {
                Console.SetCursorPosition(0, 0);
                SetBounds();
                for (int i = 0; i < rows; i++)
                {
                    if (i != 0) { Console.Write("\r\n"); }
                    for (int j = 0; j < columns; j++)
                    {
                        SetTileColor(i, j);
                        Console.Write(mapTiles[i, j]);
                        Console.ResetColor();
                    }
                }
                Console.Write("\r\n");
            }
            hasMapInitialized = true;

            Console.SetCursorPosition(player.lastX, player.lastY);
            Console.Write(mapTiles[player.lastY, player.lastX]);
            if (tracker!= null)
            {
                Console.SetCursorPosition(tracker.lastX, tracker.lastY);
                Console.Write(mapTiles[tracker.lastY, tracker.lastX]);
            }

            if (spaz != null)
            {
                Console.SetCursorPosition(spaz.lastX, spaz.lastY);
                Console.Write(mapTiles[spaz.lastY, spaz.lastX]);
            }

            if (sentinel != null)
            {
                Console.SetCursorPosition(sentinel.lastX, sentinel.lastY);
                Console.Write(mapTiles[sentinel.lastY, sentinel.lastX]);
            }
        }

        public bool IsObjectSolid(int testX, int testY)
        {
            if (mapTiles[testY, testX] == '^' || mapTiles [testY,testX] == '~' || mapTiles[testY, testX] == '║' || mapTiles[testY,testX] == '═' || mapTiles[testY, testX] == '*')
            {
                return true;
            }
            return false;
        }

        private void SetTileColor(int i, int j)
        {
            if (mapTiles[i, j] == '^')
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
            else if (mapTiles[i, j] == '~')
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (mapTiles[i, j] == '*')
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            }
            else if (mapTiles[i, j] == ',')
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void GetMapData()
        {
            if(!File.Exists("mapData.txt"))
            {
                Console.WriteLine("mapData.txt cannot be found. Ensure mapData has not been moved or renamed.");
                Console.ReadKey(true);
            }
            else
            {
                dataFromFile = File.ReadLines("mapData.txt").ToArray();
                mapTiles = new char[dataFromFile.Length, dataFromFile[0].Length];
                for (int i = 0; i < dataFromFile.Length; i++)
                {
                    charsFromFile = dataFromFile[i].ToCharArray();
                    for (int j = 0; j < charsFromFile.Length; j++)
                    {
                        mapTiles[i,j] = charsFromFile[j];  
                    }  
                }
            }

            rows = mapTiles.GetLength(0);
            columns = mapTiles.GetLength(1);
        }
    }
}
