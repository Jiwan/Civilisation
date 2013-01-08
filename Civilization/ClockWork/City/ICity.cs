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
       List<Point> ControlledCases { get; }

       Point Position
       {
           get;
           set;
       }
       int Size { get; }
       uint Food { get; }
       uint Ore { get; }
       #endregion

       #region methods
       bool IsAtPosition(Point point);

       void CreateUnit(UnitType type, IPlayer player);

       void NextTurn();

       void FindExtensionPoint();

       void ExtendPoint();

       void Render(CustomControls.MapViewer mapViewer, System.Windows.Media.DrawingContext drawingContext, System.Windows.Media.Color playerColor);
       #endregion
   }
}
