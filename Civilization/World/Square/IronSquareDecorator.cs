
namespace Civilization.World.Square
{
    class IronSquareDecorator : SquareDecorator
    {
        #region properties

        public override uint AvailableFood
        {
            get { return square.AvailableFood; }
        }

        public override uint AvailableOre
        {
            get { return square.AvailableOre + 2; }
        }

        #endregion

        public IronSquareDecorator(Square square) : base(square)
        {
        }
    }
}
