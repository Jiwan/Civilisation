using System.Drawing;

namespace Civilization.Civilization.City
{
    public interface ICityExtender
    {
        #region methods
        Point Extends(ICity city);
        #endregion
    }
}
