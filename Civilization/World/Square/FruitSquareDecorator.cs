
namespace Civilization.World.Square
{
    class FruitSquareDecorator : SquareDecorator
    {
        #region properties

        public override uint AvailableFood
        {
            get { return EncapsulatedSquare.Value.AvailableFood + 2; }
        }

        public override uint AvailableOre
        {
            get { return EncapsulatedSquare.Value.AvailableOre; }
        }

        #endregion

        #region constructor
        public FruitSquareDecorator(Square square) : base(square)
        {
        }
        #endregion
    }
}
