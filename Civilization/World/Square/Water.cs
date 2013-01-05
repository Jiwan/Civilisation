using System;
using System.Windows.Media.Imaging;
using Civilization.Utils.Drawing;

namespace Civilization.World.Square
{
    public class Water : Square
    {
        #region fields
        private static readonly BitmapImage tile = TileFlyWeight.Instance.GetBitmapImage(new Uri(@"pack://application:,,,/Images/water.png", UriKind.Absolute));
        #endregion

        #region properties
        public override BitmapImage Tile
        {
            get { return tile; }
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
