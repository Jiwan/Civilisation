﻿using System;
using System.Collections.Generic;
using System.Drawing;
using Civilization.ClockWork.Unit;

namespace Civilization.ClockWork.City
{
   public interface ICity : ICloneable
   {
       #region properties
       IList<Point> ControlledCases { get; }
       IList<IUnit> InDoorsUnits { get; }
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
       void CreateUnit(UnitType type);
       void NextTurn();
       void FindExtensionPoint();
       void ExtendPoint();
       #endregion
   }
}
