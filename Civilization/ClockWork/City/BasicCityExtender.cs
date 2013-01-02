using System;

namespace Civilization.ClockWork.City
{
    public class BasicCityExtender : ICityExtender
    {
        #region fields

        #region statics
        private static object syncRoot = new Object();
        private static volatile BasicCityExtender instance;
        #endregion
        #endregion

        #region properties
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
        private BasicCityExtender()
        {
            // Private mouhahaha
        }
        #endregion
        
        #region methods
        public System.Drawing.Point Extends(ICity city)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
