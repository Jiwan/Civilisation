using System;
using Civilization.Civilization.City;
using System.Drawing;
using Civilization.Civilization.Unit;
using System.Collections;
using System.Collections.Generic;

namespace Civilization.Player
{
    interface IPlayer
    {
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
        /// Returns true if one of the player's cities is at the point coordinates.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        Boolean AsCity(Point point);

        /// <summary>
        /// Returns true if one of the player's units is at the point coordinates.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        Boolean AsUnit(Point point);

        /// <summary>
        /// Gets all cities.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        IList<ICity> GetAllCities(Point point);

        /// <summary>
        /// Gets all units.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        IList<IUnit> GetAllUnits(Point point);

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

        /// <summary>
        /// Sets the game.
        /// </summary>
        /// <param name="game">The game.</param>
        void SetGame(Game.Game game);

        #endregion
    }
}
