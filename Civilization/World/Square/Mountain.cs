using System;
using System.Windows.Media.Imaging;
using Civilization.Utils.Drawing;

namespace Civilization.World.Square
{
    public class Mountain : Square
    {
        #region fields
        private static readonly BitmapImage tile = TileFlyWeight.Instance.GetBitmapImage(new Uri(@"pack://application:,,,/Images/mountain.png", UriKind.Absolute));
        #endregion

        #region properties
        public override BitmapImage Tile
        {
            get { return tile; }
        }
        #endregion

        #region constructor
        public Mountain() : base(0, 3)
        {
        }
        #endregion
    }
}
