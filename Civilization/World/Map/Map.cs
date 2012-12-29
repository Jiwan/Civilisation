using System.Drawing;
using Civilization.World.Square;
using System;

/*
 * TODO : + Map(SerializationInfo info), + Draw(), + GetObjectData(SerializationInfo info), + Update(float deltaTime)
 */

namespace Civilization.World.Map
{
    /// <summary>
    /// 
    /// </summary>
    public class Map
    {
        #region fields
        /// <summary>
        /// The size
        /// </summary>
        private Point size;
        /// <summary>
        /// The square matrix
        /// </summary>
        private Square.Square[,] squareMatrix;
        #endregion

        #region properties
        public Square.Square[,] SquareMatrix
        {
            get { return squareMatrix; }
        }
        #endregion

        #region constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Map" /> class.
        /// </summary>
        /// <param name="size">The size.</param>
        public Map(Point size)
        {
            this.size = size;
            squareMatrix = new Square.Square[size.X, size.Y];           
        }
        #endregion

        #region methods
        /// <summary>
        /// Gets the square.
        /// </summary>
        /// <param name="coord">The coord.</param>
        /// <returns></returns>
        public Square.Square GetSquare(Point coord)
        {
            return squareMatrix[coord.X, coord.Y];
        }

        /// <summary>
        /// Replaces the square.
        /// </summary>
        /// <param name="coord">The coord.</param>
        /// <param name="square">The square.</param>
        public void ReplaceSquare(Point coord, Square.Square square)
        {
            squareMatrix[coord.X, coord.Y] = square;
        }
        #endregion
    }
}
