using System.Drawing;

namespace Civilization.World.Map
{
    class MediumMap : IMapCreate
    {
        public Map CreateMap(ISquareRandomizer randomizer)
        {
            Map map = new Map(new Point(100, 100));
            for (int i = 0; i < 100; ++i)
            {
                for (int j = 0; j < 100; ++j)
                {
                    Point point = new Point(i, j);
                    map.ReplaceSquare(point, randomizer.CreateSquare());
                }
            }
            return map;
        }
    }
}
