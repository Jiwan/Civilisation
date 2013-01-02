using System;
using System.Drawing;
using CivilizationAlgorithms;
using Civilization.World.Square;

namespace Civilization.World.Map
{
    public class MediumMap : IMapCreate
    {
        #region fields
        /// <summary>
        /// The singleton instance of this class
        /// </summary>
        static MediumMap instance;
        #endregion

        #region properties
        /// <summary>
        /// Gets the singleton instance of this class.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static MediumMap Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MediumMap();
                }

                return instance;
            }
        }
        #endregion
        
        #region constructors
        /// <summary>
        /// Prevents a default instance of the <see cref="MediumMap" /> class from being created.
        /// </summary>
        private MediumMap()
        {

        }
        #endregion

        #region methods
        /// <summary>
        /// Creates the map.
        /// </summary>
        /// <param name="randomizer">The randomizer.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Unknow tile type</exception>
        public Map CreateMap(ISquareRandomizer randomizer)
        {
            Map map = new Map(new Point(100, 100));

            CivilizationAlgorithms.PerlinNoise.GenerateHeightMap(100, 100, 100);

            for (int i = 0; i < 100; ++i)
            {
                for (int j = 0; j < 100; ++j)
                {
                    switch (CivilizationAlgorithms.PerlinNoise.GetTileType(i, j))
                    {
                        case ManagedTileType.Desert:
                            map.ReplaceSquare(new Point(i, j), new Desert());
                            break;
                        case ManagedTileType.Water:
                            map.ReplaceSquare(new Point(i, j), new Water());
                            break;
                        case ManagedTileType.Mountain:
                            map.ReplaceSquare(new Point(i, j), new Mountain());
                            break;
                        case ManagedTileType.Field:
                            map.ReplaceSquare(new Point(i, j), new Field());
                            break;
                        default:
                            throw new System.Exception("Unknow tile type");
                            break;
                    }
                    map.GetSquare(new Point(i, j)).Position = new Point(i, j);
                }
            }
            return map;
        }
        #endregion
    }
}
