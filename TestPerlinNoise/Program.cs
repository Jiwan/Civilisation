using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CivilizationAlgorithms;

namespace TestPerlinNoise
{
    class Program
    {
        static void Main(string[] args)
        {
            CivilizationAlgorithms.PerlinNoise.GenerateHeightMap(100, 25, 25);

            for (int i = 0; i < 25; ++i)
            {
                for (int j = 0; j < 25; ++j)
                {
                    Console.Write(CivilizationAlgorithms.PerlinNoise.GetTileType(i, j));
                }
                Console.Write("\n");
            }

            Console.Read();
        }
    }
}
