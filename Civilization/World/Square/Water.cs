using System;

namespace Civilization.World.Square
{
    public class Water : Square
    {
        #region fields
        private static readonly Uri tileUri = new Uri(@"pack://application:,,,/Images/water.png", UriKind.Absolute);
        #endregion

        #region properties
        public override Uri Tile
        {
            get { return tileUri; }
        }
        #endregion

        #region constructor
        public Water()
            : base(0, 0)
        {
        }

        #endregion
    }
}
