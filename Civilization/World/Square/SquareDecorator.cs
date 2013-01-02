
namespace Civilization.World.Square
{
    class SquareDecorator : Square
    {
        #region fields
        /// <summary>
        /// The square
        /// </summary>
        protected Square square;
        #endregion

        #region properties
        /// <summary>
        /// Gets the tile.
        /// </summary>
        /// <value>
        /// The tile.
        /// </value>
        public override System.Uri Tile
        {
            get { return square.Tile; }
        }
        #endregion

        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="SquareDecorator" /> class.
        /// </summary>
        /// <param name="square">The square.</param>
        public SquareDecorator(Square square) : base(0, 0)
        {
            this.square = square;
        }
        #endregion
    }
}
