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

        /// <summary>
        /// Nexts the turn.
        /// </summary>
        void NextTurn();

        /// <summary>
        /// Renders the specified map viewer.
        /// </summary>
        /// <param name="mapViewer">The map viewer.</param>
        /// <param name="drawingContext">The drawing context.</param>
        void Render(MapViewer mapViewer, DrawingContext drawingContext, List<Point> viewPoints);

        /// <summary>
        /// Gets all view point.
        /// </summary>
        /// <returns></returns>
        List<Point> GetAllViewPoint();

        /// <summary>
        /// Determines whether this instance has director.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance has director; otherwise, <c>false</c>.
        /// </returns>
        bool HasDirector();

        /// <summary>
        /// Determines whether this instance is dead.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is dead; otherwise, <c>false</c>.
        /// </returns>
        bool IsDead();
        #endregion
    }
}
