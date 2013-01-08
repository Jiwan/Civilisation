using System;
using System.Windows.Media.Imaging;
using Civilization.Utils.Drawing;

namespace Civilization.World.Square
{
   [Serializable()]
   public class Desert : Square
   {
       #region fields
       /// <summary>
       /// The tile
       /// </summary>
       private static readonly BitmapImage tile = TileFlyWeight.Instance.GetBitmapImage(new Uri(@"pack://application:,,,/Images/desert.png", UriKind.Absolute));
       #endregion

       #region properties
       /// <summary>
       /// Gets the tile.
       /// </summary>
       /// <value>
       /// The tile.
       /// </value>
       public override BitmapImage Tile
       {
           get { return tile; }
       }

       /// <summary>
       /// Gets the name.
       /// </summary>
       /// <value>
       /// The name.
       /// </value>
       public override string Name
       {
           get { return "Désert"; }
       }
       #endregion

       #region constructor
       /// <summary>
       /// Initializes a new instance of the <see cref="Desert" /> class.
       /// </summary>
       public Desert()
            : base(0, 2)
        {
        }
        #endregion
    }
}
