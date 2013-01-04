using System.Drawing;
using Civilization.World.Square;
using System;
using System.Xml.Serialization;

using Civilization.Utils.Serialization;


namespace Civilization.World.Map
{
    /// <summary>
    /// 
    /// </summary>
    public class Map : IXmlSerializable
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
            set { squareMatrix = value; }
        }

        public Point Size
        {
            get { return size; }
            set { size = value; }
        }
        #endregion

        #region constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Map" /> class.
        /// </summary>
        /// <param name="size">The size.</param>
        /// 
        public Map(Point size)
        {
            this.size = size;
            squareMatrix = new Square.Square[size.X, size.Y];           
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Map" /> class.
        /// </summary>
        public Map()
        {
            this.size = new Point(25, 25);
            squareMatrix = new Square.Square[25, 25];
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

        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(System.Xml.XmlReader reader)
        {            
            size.X = Convert.ToInt32(reader.GetAttribute("Width"));
            size.Y = Convert.ToInt32(reader.GetAttribute("Height"));
            
            reader.Read();

            squareMatrix = new Square.Square[size.X, size.Y];

            for (int i = 0; i < size.X; ++i)
            {
                for (int j = 0; j < size.Y; ++j)
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(XmlAnything<Square.Square>));
                    this.squareMatrix[i, j] = ((XmlAnything<Square.Square>)serializer.Deserialize(reader)).Value;
                }
            }
            reader.ReadEndElement();
        }

        public void WriteXml(System.Xml.XmlWriter writer)
        {                        
            writer.WriteAttributeString("Width", size.X.ToString());
            writer.WriteAttributeString("Height", size.Y.ToString());

            for (int i = 0; i < size.X; ++i)
            {
                for (int j = 0; j < size.Y; ++j)
                {
                    var container = new XmlAnything<Square.Square>(squareMatrix[i, j]);
                    XmlSerializer serializer = new XmlSerializer(container.GetType());
                    serializer.Serialize(writer, container);
                }
            }           
        }
        #endregion
    }
}
