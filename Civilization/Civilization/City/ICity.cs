using System;
using System.Collections.Generic;
using System.Drawing;
using Civilization.Civilization.Unit;

namespace Civilization.Civilization.City
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

       int TotalAvailableFood { get; }

       int TotalAvailableOre { get; }
       #endregion

       #region methods
       bool AddCitizen();

       void CollectRessouces();

       void CreateUnit(IUnit unit);

       void Extend();
       #endregion
   }
}
