using System;
using System.Collections.Generic;
using System.Windows;
using Civilization.ClockWork.Unit;
using Civilization.Player;

namespace Civilization.ClockWork.City
{
   public interface ICity : ICloneable
   {
       #region properties
       /// <summary>
       /// Gets the controlled cases.
       /// </summary>
       /// <value>
       /// The controlled cases.
       /// </value>
       List<Point> ControlledCases { get; }

       /// <summary>
       /// Gets or sets the position.
       /// </summary>
       /// <value>
       /// The position.
       /// </value>
       Point Position
       {
           get;
           set;
       }
       /// <summary>
       /// Gets the size.
       /// </summary>
       /// <value>
       /// The size.
       /// </value>
       int Size { get; }
       /// <summary>
       /// Gets the food.
       /// </summary>
       /// <value>
       /// The food.
       /// </value>
       uint Food { get; }
       /// <summary>
       /// Gets the ore.
       /// </summary>
       /// <value>
       /// The ore.
       /// </value>
       uint Ore { get; }
       #endregion

       #region methods
       /// <summary>
       /// Determines whether [is at position] [the specified point].
       /// </summary>
       /// <param name="point">The point.</param>
       /// <returns>
       ///   <c>true</c> if [is at position] [the specified point]; otherwise, <c>false</c>.
       /// </returns>
       bool IsAtPosition(Point point);

       /// <summary>
       /// Creates the unit.
       /// </summary>
       /// <param name="type">The type.</param>
       /// <param name="player">The player.</param>
       void CreateUnit(UnitType type, IPlayer player);

       /// <summary>
       /// Nexts the turn.
       /// </summary>
       void NextTurn();

       /// <summary>
       /// Finds the extension point.
       /// </summary>
       void FindExtensionPoint();

       /// <summary>
       /// Extends the point.
       /// </summary>
       void ExtendPoint();

       /// <summary>
       /// Renders the specified map viewer.
       /// </summary>
       /// <param name="mapViewer">The map viewer.</param>
       /// <param name="drawingContext">The drawing context.</param>
       /// <param name="playerColor">Color of the player.</param>
       void Render(CustomControls.MapViewer mapViewer, System.Windows.Media.DrawingContext drawingContext, System.Windows.Media.Color playerColor);
       #endregion
   }
}
