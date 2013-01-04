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
        private Player.IPlayer player;

        private int population;
        private uint ore;
        private uint food;
        // neededFood represents the food that was needed last time to have a population increase.
        private double neededFood;
        
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

        public Point ICity.Position
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
        public BasicCity(Point location, Map map, Player.IPlayer player)
        {
            this.map = map;
            position = location;
            this.player = player;
            population = 1;
            ore = 0;
            food = 0;
            
            controlledCases = new List<Point>();
            controlledCases.Add(position);
            inDoorsUnits = new List<IUnit>();

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

        public Unit.IUnit ICity.CreateUnit(UnitType type)
        {
            switch (type)
            {
                case UnitType.U_DIRECTOR:
                    if (player.AvailableOre >= player.PlayedCivilization.Factory.DepartDirectorPrototype.Cost)
                        player.AvailableOre -= player.PlayedCivilization.Factory.DepartDirectorPrototype.Cost;
                        return player.PlayedCivilization.Factory.CreateDepartDirector();
                case UnitType.U_STUDENT:
                    if (player.AvailableOre >= player.PlayedCivilization.Factory.StudentPrototype.Cost)
                        player.AvailableOre -= player.PlayedCivilization.Factory.StudentPrototype.Cost;
                        return player.PlayedCivilization.Factory.CreateStudent();
                case UnitType.U_TEACHER:
                    if (player.AvailableOre >= player.PlayedCivilization.Factory.TeacherPrototype.Cost)
                        player.AvailableOre -= player.PlayedCivilization.Factory.TeacherPrototype.Cost;
                        return player.PlayedCivilization.Factory.CreateTeacher();
                default:
                    throw new Exception("Cannot create the unit, not enough resources.");
            }
        }

        public void Extend()
        {
            if (controlledCases.Count >= 25)
            {
                Console.WriteLine("The city has reached its maximum capacity. It can no longer be extended.");
                return;
            }

            // Etendre à la case ayant le plus de minerai (i.e une case de desert)
            Point HG = new Point (position.X, position.Y);
            Point BD = new Point (position.X, position.Y);
            
            int portee = 0;
            // premier carré (3x3)
            if (controlledCases.Count < 9)
            {
                portee = 1;
            }
            // deuxième carré (4x4)
            else if (controlledCases.Count < 16)
            {
                portee = 2;
            }
            // troisième carré (5x5)
            else if (controlledCases.Count < 25)
            {
                portee = 3;
            }

            if (position.X - portee > 0)
                HG.X -= portee;
            if (position.Y - portee > 0)
                HG.Y -= portee;
            if (position.X + portee < map.Size.X)
                BD.X += portee;
            if (position.Y + portee < map.Size.Y)
                BD.Y += portee;

            // Trouver le point idéal
            List<Point> listCases = new List<Point>();
            
            for (int i = HG.X; i < BD.X; i++)
            {
                for (int j = HG.X; i < BD.Y; j++)
                {
                    listCases.Add(new Point(i, j));
                }
            }

            if (listCases.Exists(point => map.SquareMatrix[point.X, point.Y] is World.Square.Desert && !controlledCases.Contains(point)))
            {
                Point toBeAdded = listCases.Find(point => map.SquareMatrix[point.X, point.Y] is World.Square.Desert);
                controlledCases.Add(toBeAdded);
                return;
            }
            else if (listCases.Exists(point => map.SquareMatrix[point.X, point.Y] is World.Square.Field && !controlledCases.Contains(point)))
            {
                Point toBeAdded = listCases.Find(point => map.SquareMatrix[point.X, point.Y] is World.Square.Field);
                controlledCases.Add(toBeAdded);
                return;
            }
            else if (listCases.Exists(point => map.SquareMatrix[point.X, point.Y] is World.Square.Mountain && !controlledCases.Contains(point)))
            {
                Point toBeAdded = listCases.Find(point => map.SquareMatrix[point.X, point.Y] is World.Square.Mountain);
                controlledCases.Add(toBeAdded);
                return;
            }
            else if (listCases.Exists(point => map.SquareMatrix[point.X, point.Y] is World.Square.Water && !controlledCases.Contains(point)))
            {
                Point toBeAdded = listCases.Find(point => map.SquareMatrix[point.X, point.Y] is World.Square.Water);
                controlledCases.Add(toBeAdded);
                return;
            }
         }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public void NextTurn()
        {
            // remet le compteur de food à 0
            food = 0;
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
    }
}
