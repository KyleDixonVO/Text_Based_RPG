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
        public void Update(Player player, EnemyManager enemyManager, ItemManager itemManager, Door door, Camera camera, int inventoryX, int inventoryY)
        {
            DrawMap(player, enemyManager, camera, inventoryX, inventoryY);
            DrawEntities(player, enemyManager, itemManager, door, camera);
        }

        private void DrawEntities(Player player, EnemyManager enemyManager, ItemManager itemManager, Door door, Camera camera)
        {
            //drawing player
            Console.SetCursorPosition(player.x, player.y);
            Console.Write(player.avatar);

            if (itemManager.items[0].obtained == false)
            {
                if (camera.InCameraWindow(itemManager.items[0].x, itemManager.items[0].y))
                {
                    Console.SetCursorPosition(itemManager.items[0].x, itemManager.items[0].y);
                    SetItemColor(itemManager, 0);
                    Console.Write(itemManager.items[0].avatar);
                    Console.ResetColor();
                }
            }

            for (int i = 1; i < itemManager.items.Length; i++)
            {
                if (camera.InCameraWindow(itemManager.items[i].x, itemManager.items[i].y))
                {
                    Console.SetCursorPosition(itemManager.items[i].x, itemManager.items[i].y);
                    if (itemManager.items[i].used == false)
                    {
                        SetItemColor(itemManager, i);
                        Console.Write(itemManager.items[i].avatar);
                        Console.ResetColor();
                    }
                }
            }

            if (door.doorOpened == false)
            {
                if (camera.InCameraWindow(door.x, door.y))
                {
                    Console.SetCursorPosition(door.x, door.y);
                    Console.BackgroundColor = ConsoleColor.DarkYellow;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(door.avatar);
                    Console.ResetColor();
                }
            }

            //drawing enemy
            for (int k = 0; k < enemyManager.enemies.Length; k++)
            {
                if (enemyManager.enemies[k] != null)
                {
                    if (enemyManager.enemies[k].dead == false)
                    {
                        if (camera.InCameraWindow(enemyManager.enemies[k].x, enemyManager.enemies[k].y))
                        {
                            Console.SetCursorPosition(enemyManager.enemies[k].x, enemyManager.enemies[k].y);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(enemyManager.enemies[k].avatar);
                            Console.ResetColor();
                        }
                    }
                    else
                    {
                        if (camera.InCameraWindow(enemyManager.enemies[k].x, enemyManager.enemies[k].y))
                        {
                            enemyManager.enemies[k].avatar = ' ';
                            Console.SetCursorPosition(enemyManager.enemies[k].x, enemyManager.enemies[k].y);
                            Console.Write(enemyManager.enemies[k].avatar);
                            enemyManager.enemies[k] = null;
                        }
                    }
                }
            }
        }

        

        private void SetBounds()
        {
            //Console.SetWindowSize((columns * 2), (rows*2));
            //Console.SetBufferSize((columns * 2), (rows *2));
        }

        private void DrawMap(Player player, EnemyManager enemyManager, Camera camera, int inventoryX, int inventoryY)
        {
            //Console.SetCursorPosition(0, 0);
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
                    if (camera.InCameraWindow(enemyManager.enemies[k].lastX, enemyManager.enemies[k].lastY))
                    {
                        Console.SetCursorPosition(enemyManager.enemies[k].lastX, enemyManager.enemies[k].lastY);
                        Console.Write(mapTiles[enemyManager.enemies[k].lastY, enemyManager.enemies[k].lastX]);
                    }
                }
            }


            if (inventoryX - 1 <= columns && inventoryY < rows)
            {
                Console.SetCursorPosition(inventoryX, inventoryY);
                //SetTileColor(inventoryX, inventoryY);
                Console.Write(mapTiles[inventoryY, inventoryX - 1]);
                Console.ResetColor();
            }

            if (inventoryX + 9 < columns && inventoryY < rows)
            {
                Console.SetCursorPosition(inventoryX + 7, inventoryY);
                //SetTileColor(inventoryX + 7, inventoryY);
                Console.Write(mapTiles[inventoryY, inventoryX + 7]);
                Console.SetCursorPosition(inventoryX + 8, inventoryY);
                //SetTileColor(inventoryX + 8, inventoryY);
                Console.Write(mapTiles[inventoryY, inventoryX + 8]);
                Console.SetCursorPosition(inventoryX + 9, inventoryY);
                //SetTileColor(inventoryX + 9, inventoryY);
                Console.Write(mapTiles[inventoryY, inventoryX + 9]);
                Console.ResetColor();
            }
            else
            {
                Console.SetCursorPosition(inventoryX + 7, inventoryY);
                Console.Write(" ");
                Console.SetCursorPosition(inventoryX + 8, inventoryY);
                Console.Write(" ");
                Console.SetCursorPosition(inventoryX + 9, inventoryY);
                Console.Write(" ");
            }


            if (inventoryX - 1 <= columns && inventoryY + 1 < rows)
            {
                Console.SetCursorPosition(inventoryX, inventoryY + 1);
                //SetTileColor(inventoryX, inventoryY + 1);
                Console.Write(mapTiles[inventoryY + 1, inventoryX - 1]);
                Console.ResetColor();
            }

            if (inventoryX + 17 <= columns && inventoryY + 1 < rows)
            {
                Console.SetCursorPosition(inventoryX + 16, inventoryY + 1);
                //SetTileColor(inventoryX + 16, inventoryY + 1);
                Console.Write(mapTiles[inventoryY + 1, inventoryX + 16]);
                Console.ResetColor();
            }
            else
            {
                Console.SetCursorPosition(inventoryX + 16, inventoryY + 1);
                Console.Write(" ");
            }

            if (inventoryX + 9 <= columns && inventoryY - 1 <= rows)
            {
                Console.SetCursorPosition(inventoryX, inventoryY - 1);

                for (int z = 0; z < 9; z ++)
                {
                    Console.SetCursorPosition(inventoryX + z, inventoryY);
                    //SetTileColor(inventoryX + z, inventoryY);
                    Console.Write(mapTiles[inventoryY, inventoryX + z]);
                    Console.ResetColor();
                }
            }

            if (inventoryX + 16 <= columns && inventoryY <= rows)
            {
                Console.SetCursorPosition(inventoryX, inventoryY);

                for (int z = 0; z < 16; z++)
                {
                    Console.SetCursorPosition(inventoryX + z, inventoryY);
                    //SetTileColor(inventoryX + z, inventoryY);
                    Console.Write(mapTiles[inventoryY, inventoryX + z]);
                    Console.ResetColor();
                }
            }

            if (inventoryX  + 16 <= columns && inventoryY + 1 <= rows)
            {
                Console.SetCursorPosition(inventoryX, inventoryY + 1);

                for (int z = 0; z < 16; z++)
                {
                    Console.SetCursorPosition(inventoryX + z, inventoryY + 1);
                    //SetTileColor(inventoryX + z, inventoryY + 1);
                    Console.Write(mapTiles[inventoryY + 1, inventoryX + z]);
                    Console.ResetColor();
                }
            }

            //Console.SetCursorPosition(Console.WindowLeft + 1, Console.WindowTop + camera.windowHeight - 2);
            //int hudX = Console.CursorLeft;
            //int hudY = Console.CursorTop;

            //if (hudX - 1 <= columns && hudY < rows)
            //{
            //    Console.SetCursorPosition(hudX, hudY);
            //    Console.Write(mapTiles[hudY, hudX - 1]);
            //    Console.ResetColor();
            //}

            //if (hudX + 20 < columns && hudY < rows)
            //{
            //    Console.SetCursorPosition(hudX + 20, hudY);
            //    Console.Write(mapTiles[hudY, hudX + 18]);
            //    Console.SetCursorPosition(hudX + 19, hudY);
            //    Console.Write(mapTiles[hudY, hudX + 19]);
            //    Console.SetCursorPosition(hudX + 20, hudY);
            //    Console.Write(mapTiles[hudY, hudX + 20]);
            //    Console.ResetColor();
            //}
            //else
            //{
            //    Console.SetCursorPosition(hudX + 18, hudY);
            //    Console.Write(" ");
            //    Console.SetCursorPosition(hudX + 19, hudY);
            //    Console.Write(" ");
            //    Console.SetCursorPosition(hudX + 20, hudY);
            //    Console.Write(" ");
            //}


            //if (hudX - 1 <= columns && hudY + 1 < rows)
            //{
            //    Console.SetCursorPosition(hudX, hudY + 1);
            //    Console.Write(mapTiles[hudY + 1, hudX - 1]);
            //    Console.ResetColor();
            //}

            //if (hudX + 20 <= columns && hudY + 1 < rows)
            //{
            //    Console.SetCursorPosition(hudX + 20, hudY + 1);
            //    Console.Write(mapTiles[hudY + 1, hudX + 20]);
            //    Console.ResetColor();
            //}
            //else
            //{
            //    Console.SetCursorPosition(hudX + 20, hudY + 1);
            //    Console.Write(" ");
            //}

            //if (hudX + 20 <= columns && hudY - 1 <= rows)
            //{
            //    Console.SetCursorPosition(hudX, hudY - 1);

            //    for (int z = 0; z < 20; z++)
            //    {
            //        Console.SetCursorPosition(hudX + z, hudY);
            //        Console.Write(mapTiles[hudY, hudX + z]);
            //        Console.ResetColor();
            //    }
            //}

            //if (hudX + 20 <= columns && hudY <= rows)
            //{
            //    Console.SetCursorPosition(hudX, hudY);

            //    for (int z = 0; z < 20; z++)
            //    {
            //        Console.SetCursorPosition(hudX + z, hudY);
            //        Console.Write(mapTiles[hudY, hudX + z]);
            //        Console.ResetColor();
            //    }
            //}

            //if (hudX + 20 <= columns && hudY + 1 <= rows)
            //{
            //    Console.SetCursorPosition(hudX, hudY + 1);

            //    for (int z = 0; z < 20; z++)
            //    {
            //        Console.SetCursorPosition(hudX + z, hudY + 1);
            //        Console.Write(mapTiles[hudY + 1, hudX + z]);
            //        Console.ResetColor();
            //    }
            //}
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

        private void SetItemColor(ItemManager itemManager, int i)
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
