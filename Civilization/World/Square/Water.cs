using System;
using System.Windows.Media.Imaging;
using Civilization.Utils.Drawing;

namespace Civilization.World.Square
{
    public class Water : Square
    {
        #region fields
        /// <summary>
        /// The tile
        /// </summary>
        private static readonly BitmapImage tile = TileFlyWeight.Instance.GetBitmapImage(new Uri(@"pack://application:,,,/Images/water.png", UriKind.Absolute));
        #endregion

        #region properties
        /// <summary>
        /// Gets the tile.
        /// </summary>
        /// <value>
        /// The tile.
        /// </value>
        public override BitmapImage Tile
        {
            get { return tile; }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public override string Name
        {
            get { return "Water"; }
        }
        #endregion

        #region constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Water" /> class.
        /// </summary>
        public Water()
            : base(0, 0)
        {
        }

        #endregion
    }
}
