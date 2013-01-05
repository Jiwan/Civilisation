using System.Drawing;
using System;
using System.Windows.Media.Imaging;

namespace Civilization.World.Square
{
    public abstract class Square// : IDrawable
    {
        #region fields
        private uint availableFood;
        private uint availableOre;

        private Point position;

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

        public virtual Point Position
        {
            get { return position; }
            set { position = value; }
        }

        public abstract BitmapImage Tile { get; }
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
