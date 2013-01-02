using System.Drawing;

namespace Civilization.ClockWork.City
{
    public interface ICityExtender
    {
        #region methods
        Point Extends(ICity city);
        #endregion
    }
}
