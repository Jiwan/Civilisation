using System.Collections.Generic;
using System.Drawing;
using Civilization.Civilization.Unit;

namespace Civilization.Civilization.City
{
    public class BasicCity : ICity
    {
        #region fields
        private IList<Point> controlledCases;

        private int population;

        private int size;

        private IList<IUnit> inDoorsUnits;
        #endregion

        #region properties
        public IList<Point> ControlledCases 
        { 
            get 
            { 
                return controlledCases; 
            } 
        }

        public IList<IUnit> InDoorsUnits 
        {
            get
            {
                return inDoorsUnits;
            }
        }

        public Point Position { get; set; }

        public int Size 
        {
            get
            {
                return size;
            }
        }

        public int TotalAvailableFood { get; }

        public int TotalAvailableOre { get; }
        #endregion

        #region constructors
        public BasicCity(Point position)
        {
            Position = position;
            
            controlledCases = new List<Point>();
            inDoorsUnits = new List<IUnit>();

            // A city controls its own case.
            controlledCases.Add(position);
        }
        #endregion
        
        #region methods
        #region public
        public bool AddCitizen()
        {
            throw new System.NotImplementedException();
        }

        public void CollectRessouces()
        {
            throw new System.NotImplementedException();
        }

        public void CreateUnit(Unit.IUnit unit)
        {
            throw new System.NotImplementedException();
        }

        public void Extend()
        {
            throw new System.NotImplementedException();
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
        #endregion

        #region protected
        protected int CollectOre()
        {
            // Faire le putain de calcul.
            return 0;
        }

        protected int CollectFood()
        {
            // Faire le putain de calcul.
            return 0;
        }
        #endregion
        #endregion
    }
}
