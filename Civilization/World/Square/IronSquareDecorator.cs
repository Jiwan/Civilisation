using System.Windows.Media.Imaging;
using Civilization.Utils.Drawing;
using System;

namespace Civilization.World.Square
{
    [Serializable()]
    public class IronSquareDecorator : SquareDecorator
    {
        #region fields
        /// <summary>
        /// The tile decorator
        /// </summary>
        private static readonly BitmapImage tileDecorator = TileFlyWeight.Instance.GetBitmapImage(new Uri(@"pack://application:,,,/Images/iron.png", UriKind.Absolute));
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
            get { return EncapsulatedSquare.Value.AvailableFood; }
        }

        /// <summary>
        /// Gets the available ore.
        /// </summary>
        /// <value>
        /// The available ore.
        /// </value>
        public override uint AvailableOre
        {
            get { return EncapsulatedSquare.Value.AvailableOre + 2; }
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

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public override string Name
        {
            get { return EncapsulatedSquare.Value.Name + " avec bonus de minerai"; }
        }
        #endregion

        #region constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="IronSquareDecorator" /> class.
        /// </summary>
        /// <param name="square">The square.</param>
        public IronSquareDecorator(Square square) : base(square)
        {
        }
        #endregion
    }
}
