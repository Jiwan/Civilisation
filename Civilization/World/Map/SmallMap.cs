using System.Drawing;
using CivilizationAlgorithms;
using Civilization.World.Square;

namespace Civilization.World.Map
{
    public class SmallMap : IMapCreate
    {
        #region fields
        /// <summary>
        /// The singleton instance of this class
        /// </summary>
        static SmallMap instance;
        #endregion

        #region properties
        /// <summary>
        /// Gets the singleton instance of this class.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static SmallMap Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SmallMap();
                }

                return instance;
            }
        }
        #endregion

        #region constructors
        /// <summary>
        /// Prevents a default instance of the <see cref="SmallMap" /> class from being created.
        /// </summary>
        private SmallMap()
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
            Map map = new Map(new Point(25, 25));

            CivilizationAlgorithms.PerlinNoise.GenerateHeightMap(100, 25, 25);

            for (int i = 0; i < 25; ++i)
            {
                for (int j = 0; j < 25; ++j)
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
