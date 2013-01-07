using System.Windows;

namespace Civilization.ClockWork.City
{
    public interface ICityExtender
    {
        #region methods
        Point Extends(ICity city);
        #endregion
    }
}
