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
        public void Update(Player player, EnemyManager enemyManager, ItemManager itemManager, Door door)
        {
            DrawMap(player, enemyManager);
            DrawEntities(player, enemyManager, itemManager, door);
        }

        private void DrawEntities(Player player, EnemyManager enemyManager, ItemManager itemManager, Door door)
        {
            //drawing player
            Console.SetCursorPosition(player.x, player.y);
            Console.Write(player.avatar);

            for (int i = 0; i < itemManager.items.Length; i++)
            {
                Console.SetCursorPosition(itemManager.items[i].x, itemManager.items[i].y);
                if (itemManager.items[i].used == false)
                {
                    Console.Write(itemManager.items[i].avatar);
                }
                else
                {
                    Console.Write(' ');
                }
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
            for (int k = 0; k < enemyManager.enemies.Length; k++)
            {
                if (enemyManager.enemies[k] != null)
                {
                    if (enemyManager.enemies[k].dead == false)
                    {
                        Console.SetCursorPosition(enemyManager.enemies[k].x, enemyManager.enemies[k].y);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(enemyManager.enemies[k].avatar);
                        Console.ResetColor();
                    }
                    else
                    {
                        enemyManager.enemies[k].avatar = ' ';
                        Console.SetCursorPosition(enemyManager.enemies[k].x, enemyManager.enemies[k].y);
                        Console.Write(enemyManager.enemies[k].avatar);
                        enemyManager.enemies[k] = null;
                    }
                }
            }
        }

        

        private void SetBounds()
        {
            Console.SetWindowSize((columns * 2), (rows*2));
            Console.SetBufferSize((columns * 2), (rows *2));
        }

        private void DrawMap(Player player, EnemyManager enemyManager)
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
            
            for (int k = 0; k < enemyManager.enemies.Length; k++)
            {
                if (enemyManager.enemies[k] != null)
                {
                    Console.SetCursorPosition(enemyManager.enemies[k].lastX, enemyManager.enemies[k].lastY);
                    Console.Write(mapTiles[enemyManager.enemies[k].lastY, enemyManager.enemies[k].lastX]);
                }  
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
