using System.Windows;
using Civilization.World.Map;
using Civilization.Player;

namespace Civilization.ClockWork.Unit
{
    public interface ITeacher : IUnit
    {
        #region methods
        /// <summary>
        /// Creates a new city.
        /// </summary>
        City.ICity CreateCity(Point constructionPoint, Map map, IPlayer player);
        #endregion
    }
}
