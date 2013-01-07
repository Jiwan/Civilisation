﻿using System.Windows.Media.Imaging;
using Civilization.Utils.Serialization;

namespace Civilization.World.Square
{
    public class SquareDecorator : Square
    {

        #region properties
        /// <summary>
        /// Gets the tile.
        /// </summary>
        /// <value>
        /// The tile.
        /// </value>
        public override BitmapImage Tile
        {
            get { return EncapsulatedSquare.Value.Tile; }
        }

        /// <summary>
        /// Gets or sets the square.
        /// </summary>
        /// <value>
        /// The square.
        /// </value>
        public XmlAnything<Square> EncapsulatedSquare
        {
            get;
            set;
        }
        #endregion

        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="SquareDecorator" /> class.
        /// </summary>
        /// <param name="square">The square.</param>
        public SquareDecorator(Square square) : base(0, 0)
        {
            EncapsulatedSquare = new XmlAnything<Square>();
            this.EncapsulatedSquare.Value = square;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SquareDecorator" /> class.
        /// </summary>
        public SquareDecorator() : base(0, 0)
        {
            
        }
        #endregion
    }
}
