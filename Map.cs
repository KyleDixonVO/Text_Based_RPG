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
        private int rows;
        private int columns;
        private bool hasMapInitialized = false;
        private char[,] mapTiles;

        private string[] dataFromFile;
        private char[] charsFromFile;
        public void Update(Player player, ref Tracker tracker, ref Spaz spaz, ref Sentinel sentinel)
        {
            DrawMap(player, tracker, spaz, sentinel);
            DrawEntities(player, ref tracker, ref spaz, ref sentinel);
        }

        private void DrawEntities(Player player, ref Tracker tracker, ref Spaz spaz, ref Sentinel sentinel)
        {
            //drawing player
            Console.SetCursorPosition(player.x, player.y);
            Console.Write(player.avatar);

            //drawing enemy
            if (tracker == null) { }
            else if (tracker.dead == false)
            {
                Console.SetCursorPosition(tracker.x, tracker.y);
                Console.Write(tracker.avatar);
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
                Console.Write(spaz.avatar);
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
                Console.Write(sentinel.avatar);
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
            //rows = mapTiles.GetUpperBound(0) + 1;
            //columns = mapTiles.GetUpperBound(1) + 1;
            Console.SetWindowSize((columns), (columns));
            Console.SetBufferSize((columns), (columns));
        }

        private void DrawMap(Player player, Tracker tracker, Spaz spaz, Sentinel sentinel)
        {
            Console.SetCursorPosition(0, 0);
            if (hasMapInitialized == false)
            {
                SetBounds();
                for (int i = 0; i < rows; i++)
                {
                    //Console.Write("\r");
                    for (int j = 0; j < columns; j++)
                    {
                        SetTileColor(i, j);
                        Console.Write(mapTiles[i, j]);
                        Console.ResetColor();
                    }
                }
                //Console.Write("\r");
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
            if (mapTiles[i,j] == '^')
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }
            else if (mapTiles[i,j] == '~')
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (mapTiles[i,j] == '*')
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
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
