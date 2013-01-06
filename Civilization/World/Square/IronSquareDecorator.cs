
namespace Civilization.World.Square
{
    class IronSquareDecorator : SquareDecorator
    {
        #region properties

        public override uint AvailableFood
        {
            get { return EncapsulatedSquare.Value.AvailableFood; }
        }

        public override uint AvailableOre
        {
            get { return EncapsulatedSquare.Value.AvailableOre + 2; }
        }

        #endregion

        #region constructor
        public IronSquareDecorator(Square square) : base(square)
        {
        }
        #endregion
    }
}
