
namespace Civilization.World.Square
{
    public abstract class Square// : IDrawable
    {
        #region fields
        private uint availableFood;
        private uint availableOre;

      
        // private Tile tile;
        #endregion

        #region properties
        public virtual uint AvailableFood
        {
            get { return availableFood; }
        }

        public virtual uint AvailableOre
        {
            get { return availableOre; }
        }

        #endregion

        #region constructors
        public Square(uint availableFood, uint availableOre)
        {
            this.availableFood = availableFood;
            this.availableOre = availableOre;
        }
        #endregion
        
        /*
        public Draw()
        {
        }
        */

        /*
        public Update(float deltatime)
        {
        }
        */

    }



}
