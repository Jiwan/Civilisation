using System.Collections.Generic;
using System.Drawing;
using Civilization.ClockWork.Unit;
using Civilization.World.Map;
using System;

namespace Civilization.ClockWork.City
{
    #region enumerates
    public enum UnitType
    {
        U_DIRECTOR,
        U_STUDENT,
        U_TEACHER,
    };
    #endregion

    public class BasicCity : ICity
    {
        #region fields

        private List<Point> controlledCases;
        private List<IUnit> inDoorsUnits;
        private Point position;
        private Map map;

        private int population;
        private uint food;
        // neededFood represents the food that was needed last time to have a population increase.
        private double neededFood;
        private uint ore;
        
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

        public Point Position
        {
            get
            {
                return position;
            }
        }

        public int Size 
        {
            get
            {
                return 0;
                // return age;
            }
        }

        public int TotalAvailableFood 
        { 
            get 
            { 
                return 0; 
            } 
        }

        public int TotalAvailableOre
        {
            get
            {
                return 0;
            }
        }
        #endregion

        #region constructors
        public BasicCity(Point location, Map map)
        {
            this.map = map;
            position = location;
            
            controlledCases = new List<Point>();
            inDoorsUnits = new List<IUnit>();

            /*
             * A placer autre part
             
            Point HG = new Point(position.X, position.Y);
            Point BD = new Point(position.X, position.Y);


            for (int i = 0; i < 5; i++)
            {
                if (HG.X > 0)
                {
                    HG.X--;
                }

                if (HG.Y > 0)
                {
                    HG.Y--;
                }

                if (BD.X < map.Size.X)
                {
                    BD.X++;
                }

                if (BD.Y < map.Size.Y)
                {
                    BD.Y++;
                }
            }

            controlledCases.Add(HG);
            controlledCases.Add(BD);

            */
        }
        #endregion

        #region methods

        public void AddCitizen()
        {
            // il faut respecter la formule suivante : nbResn = nbResn−1 + nbResn−1/2.
            if (population == 1 && food == 10)
            {
                population++;
                neededFood = 10;
            }
            else if (food >= (neededFood + neededFood / 2))
            {
                population++;
                neededFood += neededFood / 2;
            }
        }

        public Unit.Unit CreateUnit(UnitType type)
        {
            switch (type)
            {
                case UnitType.U_DIRECTOR:
                    //if assez de ressources
                    return new BasicDepartDirector();
                    break;
                case UnitType.U_STUDENT:
                    //if assez de ressources
                    return new BasicStudent(0, 0, 0, 0);
                    break;
                case UnitType.U_TEACHER:
                    //if assez de ressources
                    return new BasicTeacher(0, 0, 0, 0);
                    break;
                default:
                    throw new Exception("Cannot create the unit");
            }
        }

        public void Extend()
        {
            throw new System.NotImplementedException();
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public void NextTurn()
        {

        }

        public void CollectOre()
        {
            controlledCases.ForEach(point => ore += map.SquareMatrix[point.X, point.Y].AvailableOre);
        }

        public void CollectFood()
        {
            controlledCases.ForEach(point => food += map.SquareMatrix[point.X, point.Y].AvailableFood);
        }
        #endregion


        Point ICity.Position
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
                throw new System.NotImplementedException();
            }
        }
    }
}
