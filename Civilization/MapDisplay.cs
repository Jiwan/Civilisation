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
        private DynamicGrid grid;

        public MapDisplay(uint size)
        {
            mapSize = size;
            CivilizationAlgorithms.PerlinNoise.GenerateHeightMap(100, size, size);
            grid = new DynamicGrid();

            for (int i = 0; i < mapSize; ++i)
            {
                grid.addRow();

                for (int j = 0; j < mapSize; ++j)
                {
                    grid.addColomn();
                    grid.addTile(CivilizationAlgorithms.PerlinNoise.GetTileType(i, j));
                }
            }

        }
    }
}
