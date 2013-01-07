using System;
using System.Collections.Generic;
using System.Windows;
using Civilization.ClockWork.Unit;

namespace Civilization.ClockWork.City
{
   public interface ICity : ICloneable
   {
       #region properties
       List<Point> ControlledCases { get; }
       List<IUnit> InDoorsUnits { get; }
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
       bool isAtPosition(Point point);

       void CreateUnit(UnitType type);

       void NextTurn();

       void FindExtensionPoint();

       void ExtendPoint();

       void Render(CustomControls.MapViewer mapViewer, System.Windows.Media.DrawingContext drawingContext);
       #endregion
   }
}
