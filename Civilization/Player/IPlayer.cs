using System;
using Civilization.Civilization.City;
using System.Drawing;
using Civilization.Civilization.Unit;
using System.Collections;
using System.Collections.Generic;
using Civilization.Player.Actions;

namespace Civilization.Player
{
    public interface IPlayer
    {
        #region properties

        IList<ICity> Cities { get; }

        IList<IUnit> Units { get; }

        string Name { get; set; }

        System.Windows.Media.Color Color { get; set; }

        #endregion


        #region methods

        /// <summary>
        /// Adds the city.
        /// </summary>
        /// <param name="city">The city.</param>
        void AddCity(ICity city);

        /// <summary>
        /// Adds the unit.
        /// </summary>
        /// <param name="unit">The unit.</param>
        void AddUnit(IUnit unit);

        /// <summary>
        /// Determines whether the specified point has a city.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>
        ///   <c>true</c> if the specified point has city; otherwise, <c>false</c>.
        /// </returns>
        bool HasCity(Point point);

        /// <summary>
        /// Determines whether the specified point has a unit.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>
        ///   <c>true</c> if the specified point has unit; otherwise, <c>false</c>.
        /// </returns>
        bool HasUnit(Point point);

        /// <summary>
        /// Gets the commands.
        /// </summary>
        /// <returns></returns>
        IPlayerAction GetCommands();

        /// <summary>
        /// Determines whether this instance is dead.
        /// </summary>
        /// <returns></returns>
        Boolean IsDead();

        /// <summary>
        /// Removes the city.
        /// </summary>
        /// <param name="city">The city.</param>
        void RemoveCity(ICity city);

        /// <summary>
        /// Removes the unit.
        /// </summary>
        /// <param name="unit">The unit.</param>
        void RemoveUnit(IUnit unit);

        #endregion
    }
}
