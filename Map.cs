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
        public char[,] mapTiles;
        private string[] dataFromFile;
        private char[] charsFromFile;

        public void GetMapData()
        {
            if (!File.Exists("mapData.txt"))
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
                        mapTiles[i, j] = charsFromFile[j];
                    }
                }
            }

            rows = mapTiles.GetLength(0);
            columns = mapTiles.GetLength(1);
        }

        public void Draw(Renderer renderer, Camera camera)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    renderer.SetTileColor(mapTiles[i, j]);
                    renderer.Draw(j,i, mapTiles[i,j], camera);
                }
            }
        }
    }
}
