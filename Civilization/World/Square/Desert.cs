using System;

namespace Civilization.World.Square
{
   public class Desert : Square
   {
       #region fields
       private static readonly Uri tileUri = new Uri(@"pack://application:,,,/Images/desert.png", UriKind.Absolute);
       #endregion

       #region properties
       public override Uri Tile
       {
           get { return tileUri; }
       }
       #endregion

       #region constructor
       public Desert()
            : base(0, 2)
        {
        }
        #endregion
    }
}
