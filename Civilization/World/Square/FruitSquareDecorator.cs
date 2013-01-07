using System.Windows.Media.Imaging;
using Civilization.Utils.Drawing;
using System;

namespace Civilization.World.Square
{
    class FruitSquareDecorator : SquareDecorator
    {
        #region fields
        /// <summary>
        /// The tile decorator
        /// </summary>
        private static readonly BitmapImage tileDecorator = TileFlyWeight.Instance.GetBitmapImage(new Uri(@"pack://application:,,,/Images/food.png", UriKind.Absolute));
        #endregion

        #region properties

        /// <summary>
        /// Gets the available food.
        /// </summary>
        /// <value>
        /// The available food.
        /// </value>
        public override uint AvailableFood
        {
            get { return EncapsulatedSquare.Value.AvailableFood + 2; }
        }

        /// <summary>
        /// Gets the available ore.
        /// </summary>
        /// <value>
        /// The available ore.
        /// </value>
        public override uint AvailableOre
        {
            get { return EncapsulatedSquare.Value.AvailableOre; }
        }

        /// <summary>
        /// Gets the tile decorator.
        /// </summary>
        /// <value>
        /// The tile decorator.
        /// </value>
        public override BitmapImage TileDecorator
        {
            get
            {
                return tileDecorator;
            }
        }
        #endregion

        #region constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="FruitSquareDecorator" /> class.
        /// </summary>
        /// <param name="square">The square.</param>
        public FruitSquareDecorator(Square square) : base(square)
        {
        }
        #endregion
    }
}
