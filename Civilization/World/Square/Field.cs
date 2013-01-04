using System;

namespace Civilization.World.Square
{
    public class Field : Square
    {
        #region fields
        private static readonly Uri tileUri = new Uri(@"pack://application:,,,/Images/field.png", UriKind.Absolute);
        #endregion

        #region properties
        public override Uri Tile
        {
            get { return tileUri; }
        }
        #endregion

        #region constructor
        public Field()
            : base(3, 1)
        {
        }
        #endregion
    }
}
