using System.Collections.Generic;
using System.Windows;
using Civilization.ClockWork.Unit;
using Civilization.World.Map;
using System;
using System.Windows.Media;
using System.Globalization;
using System.Windows.Media.Imaging;
using Civilization.Utils.Drawing;

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

        /// <summary>
        /// The tile
        /// </summary>
        private static readonly BitmapImage tile = TileFlyWeight.Instance.GetBitmapImage(new Uri(@"pack://application:,,,/Images/sprite_city.png", UriKind.Absolute));
        #endregion

        #region properties
        public List<Point> ControlledCases 
        { 
            get 
            { 
                return controlledCases; 
            } 
        }
        public List<IUnit> InDoorsUnits 
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
            set
            {
                position = value;
            }
        }
        public int Size 
        {
            get
            {
                return controlledCases.Count;
            }
        }
        public uint Food 
        { 
            get 
            { 
                return food; 
            }
            set
            {
                food = value;
            }
        }
        public uint Ore
        {
            get
            {
                return ore;
            }
            set
            {
                ore = value;
            }
        }
        public Point ExtensionPoint
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the tile.
        /// </summary>
        /// <value>
        /// The tile.
        /// </value>
        public BitmapImage Tile { get { return tile; } }

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
        }
        #endregion

        #region methods
        
        #region private
        private void AddCitizen()
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
        private void CollectOre()
        {
            uint oldOre = Ore;
            controlledCases.ForEach(point => Ore += map.SquareMatrix[(int)point.X, (int)point.Y].AvailableOre);
            Ore += oldOre;
        }
        private void CollectFood()
        {
            controlledCases.ForEach(point => food += map.SquareMatrix[(int)point.X, (int)point.Y].AvailableFood);
        }
        #endregion

        #region public
        public bool IsAtPosition(Point point)
        {
            return controlledCases.Contains(point);
        }

        public void CreateUnit(UnitType type)
        {
            switch (type)
            {
                case UnitType.U_DIRECTOR:
                    if (player.AvailableOre >= player.PlayedCivilization.Factory.DepartDirectorPrototype.Cost)
                        player.AvailableOre -= (uint) player.PlayedCivilization.Factory.DepartDirectorPrototype.Cost;
                        InDoorsUnits.Add((Unit.Unit)player.PlayedCivilization.Factory.CreateDepartDirector());
                        break;
                case UnitType.U_STUDENT:
                    if (player.AvailableOre >= player.PlayedCivilization.Factory.StudentPrototype.Cost)
                        player.AvailableOre -= (uint) player.PlayedCivilization.Factory.StudentPrototype.Cost;
                        InDoorsUnits.Add((Unit.Unit)player.PlayedCivilization.Factory.CreateStudent());
                        break;
                case UnitType.U_TEACHER:
                    if (player.AvailableOre >= player.PlayedCivilization.Factory.TeacherPrototype.Cost)
                        player.AvailableOre -= (uint) player.PlayedCivilization.Factory.TeacherPrototype.Cost;
                        InDoorsUnits.Add((Unit.Unit)player.PlayedCivilization.Factory.CreateTeacher());
                        break;
                default:
                    throw new Exception("Cannot create the unit, not enough resources.");
            }
        }
        public void FindExtensionPoint()
        {
            if (controlledCases.Count >= 25)
            {                
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

            for (int i = (int)HG.X; i < BD.X; i++)
            {
                for (int j = (int)HG.X; i < BD.Y; j++)
                {
                    listCases.Add(new Point(i, j));
                }
            }

            Point toBeAdded = new Point();
            if (listCases.Exists(point => map.SquareMatrix[(int)point.X, (int)point.Y] is World.Square.Desert && !controlledCases.Contains(point)))
            {
                toBeAdded = listCases.Find(point => map.SquareMatrix[(int)point.X, (int)point.Y] is World.Square.Desert);
            }
            else if (listCases.Exists(point => map.SquareMatrix[(int)point.X, (int)point.Y] is World.Square.Field && !controlledCases.Contains(point)))
            {
                toBeAdded = listCases.Find(point => map.SquareMatrix[(int)point.X, (int)point.Y] is World.Square.Field);
            }
            else if (listCases.Exists(point => map.SquareMatrix[(int)point.X, (int)point.Y] is World.Square.Mountain && !controlledCases.Contains(point)))
            {
                toBeAdded = listCases.Find(point => map.SquareMatrix[(int)point.X, (int)point.Y] is World.Square.Mountain);
            }
            else if (listCases.Exists(point => map.SquareMatrix[(int)point.X, (int)point.Y] is World.Square.Water && !controlledCases.Contains(point)))
            {
                toBeAdded = listCases.Find(point => map.SquareMatrix[(int)point.X, (int)point.Y] is World.Square.Water);
            }

            ExtensionPoint = toBeAdded;
            player.CitiesToBeExtended.Enqueue(this);
        }
        public void ExtendPoint()
        {
            if (food > neededFood)
            {
                if (ExtensionPoint != null)
                {
                    ControlledCases.Add(ExtensionPoint);
                    AddCitizen();
                    Console.WriteLine("Ville étendue et population incrémentée.");
                }
                else
                {
                    Console.WriteLine("Aucune case d'extension désignée. La ville ne peut s'étendre.");
                }
            }
            else
            {
                Console.WriteLine("Pas assez de nourriture pour s'étendre et créer un nouvel habitant.");
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
            CollectFood();
            CollectOre();
        }

        public void Render(CustomControls.MapViewer mapViewer, System.Windows.Media.DrawingContext drawingContext, System.Windows.Media.Color playerColor)
        {
            if (mapViewer.IsInView(position))
            {
                Rect rect = mapViewer.GetRectangle((int)position.X, (int)position.Y);

                drawingContext.DrawImage(Tile, rect);
            }

            foreach (Point point in controlledCases)
            {
                if (mapViewer.IsInView(point))
                {
                    Rect rect = mapViewer.GetRectangle((int)point.X, (int)point.Y);

                    SolidColorBrush myBrush = new SolidColorBrush(playerColor);
                    myBrush.Opacity = 0.3;
                    drawingContext.DrawRectangle(myBrush, null, rect);
                }
            }
        }
        #endregion
        #endregion
    }
}
