using System;

namespace Civilization.World.Square
{
    public class Mountain : Square
    {
        #region fields
        private static readonly Uri tileUri = new Uri(@"pack://application:,,,/Images/mountain.png", UriKind.Absolute);
        #endregion

        #region properties
        public override Uri Tile
        {
            get { return tileUri; }
        }
        #endregion

        #region constructor
        public Mountain() : base(0, 3)
        {
        }
        #endregion
    }
}
