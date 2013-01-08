using System;
using Civilization.ClockWork.City;
using System.Windows;
using Civilization.ClockWork.Unit;
using System.Collections;
using System.Collections.Generic;
using Civilization.Player.Actions;
using System.Windows.Media;
using Civilization.CustomControls;

namespace Civilization.Player
{
    public interface IPlayer
    {
        #region properties

        List<ICity> Cities { get; }
        List<IUnit> Units { get; }
        Game.Game Game { get; set; }
        string Name { get; set; }
        Civilization.ClockWork.Civilization PlayedCivilization { get; set; }
        System.Windows.Media.Color Color { get; set; }
        uint AvailableFood { get; set; }
        uint AvailableOre { get; set; }
        bool Alive { get; set; }
        Queue<ICity> CitiesToBeExtended { get; set; }

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
        /// Gets the units.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        List<IUnit> GetUnits(Point point);

        /// <summary>
        /// Gets the city.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        ICity GetCity(Point point);

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

        void NextTurn();

        void Render(MapViewer mapViewer, DrawingContext drawingContext);
        #endregion
    }
}
