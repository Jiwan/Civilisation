using System.Windows;

namespace Civilization.ClockWork.City
{
    public interface ICityExtender
    {
        #region methods
        /// <summary>
        /// Extendses the specified city.
        /// </summary>
        /// <param name="city">The city.</param>
        /// <returns></returns>
        Point Extends(ICity city);
        #endregion
    }
}
