
using System.Drawing;
namespace Civilization.World.Map
{
    class SmallMap : IMapCreate
    {

        public Map CreateMap(ISquareRandomizer randomizer)
        {
            Map map = new Map(new Point(25, 25));
            for (int i = 0; i < 25; ++i)
            {
                for (int j = 0; j < 25; ++j)
                {
                    Point point = new Point(i, j);
                    map.ReplaceSquare(point, randomizer.CreateSquare());
                }
            }
            return map;
        }
    }
}
