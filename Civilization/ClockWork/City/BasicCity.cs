using System.Collections.Generic;
using System.Windows;
using Civilization.ClockWork.Unit;
using Civilization.World.Map;
using System;
using System.Windows.Media;
using System.Globalization;
using System.Windows.Media.Imaging;
using Civilization.Utils.Drawing;
using Civilization.Player;
using Civilization.Utils.Logs;

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

    [Serializable()]
    public class BasicCity : ICity
    {
        #region fields
        /// <summary>
        /// The controlled cases
        /// </summary>
        private List<Point> controlledCases;
        /// <summary>
        /// The in doors units
        /// </summary>
        private List<IUnit> inDoorsUnits;
        /// <summary>
        /// The position
        /// </summary>
        private Point position;
        /// <summary>
        /// The map
        /// </summary>
        private Map map;
        /// <summary>
        /// The player
        /// </summary>
        private Player.IPlayer player;
        /// <summary>
        /// The population
        /// </summary>
        private int population;
        /// <summary>
        /// The ore
        /// </summary>
        private uint ore;
        /// <summary>
        /// The food
        /// </summary>
        private uint food;
        // neededFood represents the food that was needed last time to have a population increase.
        private double neededFood;

        /// <summary>
        /// The tile
        /// </summary>
        private static readonly BitmapImage tile = TileFlyWeight.Instance.GetBitmapImage(new Uri(@"pack://application:,,,/Images/sprite_city.png", UriKind.Absolute));
        #endregion

        #region properties
        /// <summary>
        /// Gets the controlled cases.
        /// </summary>
        /// <value>
        /// The controlled cases.
        /// </value>
        public List<Point> ControlledCases 
        { 
            get 
            { 
                return controlledCases; 
            } 
        }
        /// <summary>
        /// Gets or sets the in doors units.
        /// </summary>
        /// <value>
        /// The in doors units.
        /// </value>
        public List<IUnit> InDoorsUnits 
        {
            get
            {
                return inDoorsUnits;
            }
            set
            {
                inDoorsUnits = value;
            }
        }
        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
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
        /// <summary>
        /// Gets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public int Size 
        {
            get
            {
                return controlledCases.Count;
            }
        }
        /// <summary>
        /// Gets or sets the food.
        /// </summary>
        /// <value>
        /// The food.
        /// </value>
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
        /// <summary>
        /// Gets or sets the ore.
        /// </summary>
        /// <value>
        /// The ore.
        /// </value>
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
        /// <summary>
        /// Gets or sets the extension point.
        /// </summary>
        /// <value>
        /// The extension point.
        /// </value>
        public Point? ExtensionPoint
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
        /// <summary>
        /// Initializes a new instance of the <see cref="BasicCity" /> class.
        /// </summary>
        /// <param name="location">The location.</param>
        /// <param name="map">The map.</param>
        /// <param name="player">The player.</param>
        public BasicCity(Point location, Map map, Player.IPlayer player)
        {
            this.map = map;
            position = location;
            this.player = player;
            population = 1;
            ore = 0;
            food = 0;

            inDoorsUnits = new List<IUnit>();
            controlledCases = new List<Point>();
            controlledCases.Add(position);
        }
        #endregion

        #region methods
        
        #region private
        /// <summary>
        /// Adds a citizen.
        /// </summary>
        private void AddCitizen()
        {
            // il faut respecter la formule suivante : nbResn = nbResn−1 + nbResn−1/2.
            if (population == 1)
            {
                population++;
                neededFood = 2;
            }
            else if (food >= (neededFood + neededFood / 2))
            {
                population++;
                neededFood += neededFood / 2;
            }
        }

        /// <summary>
        /// Collects the ore.
        /// </summary>
        private void CollectOre()
        {
            uint oldOre = Ore;
            controlledCases.ForEach(point => Ore += map.SquareMatrix[(int)point.X, (int)point.Y].AvailableOre);
            Ore += oldOre;
        }

        /// <summary>
        /// Collects the food.
        /// </summary>
        private void CollectFood()
        {
            controlledCases.ForEach(point => food += map.SquareMatrix[(int)point.X, (int)point.Y].AvailableFood);
        }
        #endregion

        #region public
        /// <summary>
        /// Determines whether [is at position] [the specified point].
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>
        ///   <c>true</c> if [is at position] [the specified point]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsAtPosition(Point point)
        {
            return controlledCases.Contains(point);
        }

        /// <summary>
        /// Creates the unit.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="player">The player.</param>
        /// <exception cref="System.Exception">Cannot create the unit, not enough resources.</exception>
        public void CreateUnit(UnitType type, IPlayer player)
        {
            switch (type)
            {
                case UnitType.U_DIRECTOR:
                        if (player.AvailableOre >= player.PlayedCivilization.Factory.DepartDirectorPrototype.Cost)
                        {
                            if (!player.HasDirector())
                            {
                                player.AvailableOre -= (uint)player.PlayedCivilization.Factory.DepartDirectorPrototype.Cost;
                                var unit = player.PlayedCivilization.Factory.CreateDepartDirector();
                                unit.Position = position;
                                player.AddUnit(unit);
                            }
                            else
                            {
                                Log.Instance.Write("Votre civilisation possède déjà un directeur.");
                            }
                        }
                        else
                        {
                            Log.Instance.Write("Vous n'avez pas assez de minerai dans cette ville pour pouvoir créer un nouveau directeur.");
                        }
                        break;
                case UnitType.U_STUDENT:
                        if (player.AvailableOre >= player.PlayedCivilization.Factory.StudentPrototype.Cost)
                        {
                            player.AvailableOre -= (uint)player.PlayedCivilization.Factory.StudentPrototype.Cost;
                            var unit = player.PlayedCivilization.Factory.CreateStudent();
                            unit.Position = position;
                            player.AddUnit(unit);
                        }
                        else
                        {
                            Log.Instance.Write("Vous n'avez pas assez de minerai dans cette ville pour pouvoir créer un nouvel étudiant.");
                        }
                        break;
                case UnitType.U_TEACHER:
                        if (player.AvailableOre >= player.PlayedCivilization.Factory.TeacherPrototype.Cost)
                        {
                            player.AvailableOre -= (uint)player.PlayedCivilization.Factory.TeacherPrototype.Cost;
                            var unit = player.PlayedCivilization.Factory.CreateTeacher();
                            unit.Position = position;
                            player.AddUnit(unit);
                        }
                        else
                        {
                            Log.Instance.Write("Vous n'avez pas assez de minerai dans cette ville pour pouvoir créer un nouvel enseignant.");
                        }
                        break;
                default:
                    throw new Exception("Cannot create the unit, not enough resources.");
            }
        }
        /// <summary>
        /// Finds the extension point.
        /// </summary>
        public void FindExtensionPoint()
        {
            if (controlledCases.Count >= 25)
            {
                ExtensionPoint = null;
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

            for (int i = (int)HG.X; i <= BD.X; i++)
            {
                for (int j = (int)HG.Y; j <= BD.Y; j++)
                {
                    listCases.Add(new Point(i, j));
                }
            }

            Point toBeAdded = new Point();
            if (listCases.Exists(point => map.SquareMatrix[(int)point.X, (int)point.Y] is World.Square.FruitSquareDecorator && !controlledCases.Contains(point)))
            {
                toBeAdded = listCases.Find(point => map.SquareMatrix[(int)point.X, (int)point.Y] is World.Square.FruitSquareDecorator && !controlledCases.Contains(point));
            }
            else if (listCases.Exists(point => map.SquareMatrix[(int)point.X, (int)point.Y] is World.Square.IronSquareDecorator && !controlledCases.Contains(point)))
            {
                toBeAdded = listCases.Find(point => map.SquareMatrix[(int)point.X, (int)point.Y] is World.Square.IronSquareDecorator && !controlledCases.Contains(point));
            }
            else if (listCases.Exists(point => map.SquareMatrix[(int)point.X, (int)point.Y] is World.Square.Field && !controlledCases.Contains(point)))
            {
                toBeAdded = listCases.Find(point => map.SquareMatrix[(int)point.X, (int)point.Y] is World.Square.Field && !controlledCases.Contains(point));
            }
            else if (listCases.Exists(point => map.SquareMatrix[(int)point.X, (int)point.Y] is World.Square.Desert && !controlledCases.Contains(point)))
            {
                toBeAdded = listCases.Find(point => map.SquareMatrix[(int)point.X, (int)point.Y] is World.Square.Desert && !controlledCases.Contains(point));
            }
            else if (listCases.Exists(point => map.SquareMatrix[(int)point.X, (int)point.Y] is World.Square.Mountain && !controlledCases.Contains(point)))
            {
                toBeAdded = listCases.Find(point => map.SquareMatrix[(int)point.X, (int)point.Y] is World.Square.Mountain && !controlledCases.Contains(point));
            }
            else if (listCases.Exists(point => map.SquareMatrix[(int)point.X, (int)point.Y] is World.Square.Water && !controlledCases.Contains(point)))
            {
                toBeAdded = listCases.Find(point => map.SquareMatrix[(int)point.X, (int)point.Y] is World.Square.Water && !controlledCases.Contains(point));
            }

            if (toBeAdded.Equals(new Point(0, 0)))
            {
                ExtensionPoint = null;
            }
            else
            {
                ExtensionPoint = toBeAdded;
                player.CitiesToBeExtended.Enqueue(this);
            }
        }

        /// <summary>
        /// Extends the point.
        /// </summary>
        public void ExtendPoint()
        {
            if (food > neededFood)
            {
                if (ExtensionPoint != null)
                {
                    ControlledCases.Add((Point)ExtensionPoint);
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
            AddCitizen();
        }

        /// <summary>
        /// Creates a new object that is a copy of the current instance.
        /// </summary>
        /// <returns>
        /// A new object that is a copy of this instance.
        /// </returns>
        public object Clone()
        {
            return MemberwiseClone();
        }

        /// <summary>
        /// Next turn.
        /// </summary>
        public void NextTurn()
        {
            // remet le compteur de food à 0
            food = 0;
            CollectFood();
            CollectOre();
        }

        /// <summary>
        /// Renders the specified map viewer.
        /// </summary>
        /// <param name="mapViewer">The map viewer.</param>
        /// <param name="drawingContext">The drawing context.</param>
        /// <param name="playerColor">Color of the player.</param>
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
