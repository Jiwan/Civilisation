using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;


namespace Civilization.Utils.Drawing
{
    public class TileFlyWeight
    {
        #region fields
        /// <summary>
        /// The dictionnary of bitmapImage.
        /// </summary>
        private Dictionary<Uri, BitmapImage> dictionnary;

        /// <summary>
        /// The instance
        /// </summary>
        private static TileFlyWeight instance;
        #endregion

        #region properties
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static TileFlyWeight Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TileFlyWeight();
                }
                return instance;
            }
        }
        #endregion

        #region constructors
        /// <summary>
        /// Prevents a default instance of the <see cref="TileFlyWeight" /> class from being created.
        /// </summary>
        private TileFlyWeight()
        {
            dictionnary = new Dictionary<Uri, BitmapImage>();
        }
        #endregion


        #region methods
        /// <summary>
        /// Gets the bitmap image.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns></returns>
        public BitmapImage GetBitmapImage(Uri path)
        {
            if (!dictionnary.ContainsKey(path))
            {
                BitmapImage image = new BitmapImage(path);
                dictionnary.Add(path, image);

                return image;
            }
            else
            {
                return dictionnary[path]; 
            }
        }
        #endregion

    }
}
