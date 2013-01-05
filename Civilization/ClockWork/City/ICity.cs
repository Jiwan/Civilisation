using System;
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
       int Food { get; }
       int Ore { get; }
       #endregion

       #region methods
       void AddCitizen();
       void CollectOre();
       void CollectFood();
       Unit.IUnit CreateUnit(UnitType type);
       void NextTurn();
       void Extend();
       #endregion
   }
}
