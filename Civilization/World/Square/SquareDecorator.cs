
namespace Civilization.World.Square
{
    class SquareDecorator : Square
    {
        #region
        protected Square square;
        #endregion

        public SquareDecorator(Square square) : base(0, 0)
        {
            this.square = square;
        }
    }
}
