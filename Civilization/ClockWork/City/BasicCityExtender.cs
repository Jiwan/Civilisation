using System;
using System.Windows;

namespace Civilization.ClockWork.City
{
    public class BasicCityExtender : ICityExtender
    {
        #region fields

        #region statics
        /// <summary>
        /// The sync root
        /// </summary>
        private static object syncRoot = new Object();
        /// <summary>
        /// The instance
        /// </summary>
        private static volatile BasicCityExtender instance;
        #endregion
        #endregion

        #region properties
        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static BasicCityExtender Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (instance == null)
                    {
                        instance = new BasicCityExtender();
                    }

                    return instance;
                }
            }
        }
        #endregion

        #region constructors
        /// <summary>
        /// Prevents a default instance of the <see cref="BasicCityExtender" /> class from being created.
        /// </summary>
        private BasicCityExtender()
        {
            // Private mouhahaha
        }
        #endregion
        
        #region methods
        /// <summary>
        /// Extendses the specified city.
        /// </summary>
        /// <param name="city">The city.</param>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public Point Extends(ICity city)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
