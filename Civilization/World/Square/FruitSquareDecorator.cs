
namespace Civilization.World.Square
{
    class FruitSquareDecorator : SquareDecorator
    {
        #region properties

        public override uint AvailableFood
        {
            get { return square.AvailableFood + 2; }
        }

        public override uint AvailableOre
        {
            get { return square.AvailableOre; }
        }

        #endregion

        #region constructor
        public FruitSquareDecorator(Square square) : base(square)
        {
        }
        #endregion
    }
}
