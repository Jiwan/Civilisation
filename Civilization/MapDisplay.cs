using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CivilizationAlgorithms;

namespace Civilization
{
    class MapDisplay
    {
        private uint mapSize;

        public MapDisplay(uint size)
        {
            mapSize = size;
            CivilizationAlgorithms.PerlinNoise.GenerateHeightMap(100, size, size);

            for (int i = 0; i < mapSize; ++i)
            {
                MainWindow.addRow();

                for (int j = 0; j < mapSize; ++j)
                {
                    MainWindow.addColomn();
                    MainWindow.addTile(CivilizationAlgorithms.PerlinNoise.GetTileType(i, j));
                }
                Console.Write("\n");
            }

        }
    }
}
