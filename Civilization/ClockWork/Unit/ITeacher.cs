using System.Windows;
using Civilization.World.Map;

namespace Civilization.ClockWork.Unit
{
    public interface ITeacher : IUnit
    {
        #region methods
        /// <summary>
        /// Creates a new city.
        /// </summary>
        City.ICity CreateCity(Point constructionPoint, Map map);
        #endregion
    }
}
