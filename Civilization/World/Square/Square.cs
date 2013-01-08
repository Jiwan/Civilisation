using System.Windows;
using System;
using System.Windows.Media.Imaging;

namespace Civilization.World.Square
{
    [Serializable()]
    public abstract class Square// : IDrawable
    {
        #region fields
        /// <summary>
        /// The available food
        /// </summary>
        private uint availableFood;

        /// <summary>
        /// The available ore
        /// </summary>
        private uint availableOre;

        /// <summary>
        /// The position
        /// </summary>
        private Point position;
        #endregion

        #region properties
        /// <summary>
        /// Gets the available food.
        /// </summary>
        /// <value>
        /// The available food.
        /// </value>
        public virtual uint AvailableFood
        {
            get { return availableFood; }
        }

        /// <summary>
        /// Gets the available ore.
        /// </summary>
        /// <value>
        /// The available ore.
        /// </value>
        public virtual uint AvailableOre
        {
            get { return availableOre; }
        }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public virtual Point Position
        {
            get { return position; }
            set { position = value; }
        }

        /// <summary>
        /// Gets the tile.
        /// </summary>
        /// <value>
        /// The tile.
        /// </value>
        public abstract BitmapImage Tile { get; }

        /// <summary>
        /// Gets the tile decorator.
        /// </summary>
        /// <value>
        /// The tile decorator.
        /// </value>
        public virtual BitmapImage TileDecorator 
        {
            get
            {
                return null;
            }
        }

        /// <summary>
        /// Gets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public abstract string Name
        {
            get;
        }
        #endregion

        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Square" /> class.
        /// </summary>
        /// <param name="availableFood">The available food.</param>
        /// <param name="availableOre">The available ore.</param>
        public Square(uint availableFood, uint availableOre)
        {
            this.availableFood = availableFood;
            this.availableOre = availableOre;
        }
        #endregion
    }
}
