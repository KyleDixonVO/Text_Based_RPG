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
        //= new char[,]
        //{
        //    {'╔','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','╗'},
        //    {'║','^',' ',' ',' ',' ','*','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','~','~','~',' ',' ','║'},
        //    {'║','^',' ',' ',' ','*','*',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ','~','~','~',' ',' ',' ',' ','║'},
        //    {'║',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','║'},
        //    {'║',' ',' ',' ','~','~','~',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','║'},
        //    {'║',' ',' ',' ','~','~','~','~','~',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','^',' ',' ',' ',' ',' ',' ','║'},
        //    {'║',' ',' ','~','~','~','~','~','~','~','~','~','~',' ',' ',' ',' ',' ',' ',' ',' ','^','^','^',' ',' ',' ',' ',' ','║'},
        //    {'║',' ',' ',' ','~','~','~','~','~','~',' ',' ',' ','~','~','~',' ',' ',' ','^','^','^','^','^','^',' ',' ',' ',' ','║'},
        //    {'║',' ',' ','*',' ','~','~','~','~',' ',' ',' ',' ',' ',' ',' ',' ',' ','^','^','^','^','^','^','^','^','^',' ',' ','║'},
        //    {'║',' ',' ',' ',' ',' ',' ','~','~',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*','║'},
        //    {'║',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ',' ','*','*','║'},
        //    {'╚','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','═','╝'},
        //};

        private string[] dataFromFile;
        private char[] charsFromFile;
        public char[][] tilesFromFile;
        public void Update(Player player, ref Tracker tracker)
        {
            DrawMap(player, tracker);
            DrawEntities(player, ref tracker);
        }

        private void DrawEntities(Player player, ref Tracker tracker)
        {
            //drawing player
            Console.SetCursorPosition(player.x, player.y);
            Console.Write(player.avatar);

            //drawing enemy
            if (tracker == null)return;
            
            if (tracker.dead == false)
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
            
        }

        

        private void SetBounds()
        {
            //rows = mapTiles.GetUpperBound(0) + 1;
            //columns = mapTiles.GetUpperBound(1) + 1;
            Console.SetWindowSize((columns), (columns));
            Console.SetBufferSize((columns), (columns));
        }

        private void DrawMap(Player player, Tracker tracker)
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
        }
    }
}
