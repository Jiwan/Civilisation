using System.Collections.Generic;
using System.Windows;
using System.Windows.Media;
using Civilization.ClockWork.City;
using Civilization.ClockWork.Unit;
using Civilization.CustomControls;
using Civilization.Utils.Logs;

namespace Civilization.Player
{
    public class HumanPlayer : IPlayer
    {
        #region Attributes
        private bool alive;
        private List<ICity> cities;
        private List<IUnit> units;
        private Game.Game game;
        private string name;
        private Civilization.ClockWork.Civilization playedCivilization;
        private System.Windows.Media.Color color;
        private uint availableFood;
        private uint availableOre;
        #endregion

        #region Constructeur
        public HumanPlayer(string name, System.Windows.Media.Color color)
        {
            this.name = name;
            Color = color;
            alive = true;
            cities = new List<ICity>();
            units = new List<IUnit>();
            CitiesToBeExtended = new Queue<ICity>();
        }
        #endregion

        #region properties
        public bool Alive
        {
            get
            {
                return alive;
            }
            set
            {
                alive = value;
            }
        }
        public List<ICity> Cities
        {
            get
            {
                return cities;
            }
        }
        public List<IUnit> Units
        {
            get
            {
                return units;
            }
        }
        public Game.Game Game
        {
            get
            {
                return game;
            }

            set
            {
                game = value;
            }
        }
        public string Name 
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }
        public Civilization.ClockWork.Civilization PlayedCivilization
        {
            get
            {
                return playedCivilization;
            }
            set
            {
                playedCivilization = value;
            }
        }
        public System.Windows.Media.Color Color
        {
            get
            {
                return color;
            }
            set
            {
                color = value;
            }
        }
        public uint AvailableFood
        {
            get
            {
                return availableFood;
            }
            set
            {
                availableFood = value;
            }
        }
        public uint AvailableOre
        {
            get
            {
                return availableOre;
            }
            set
            {
                availableOre = value;
            }
        }

        public Queue<ICity> CitiesToBeExtended
        {
            get;
            set;
        }
        #endregion

        #region Methods
        public void AddCity(ICity city)
        {
            cities.Add(city);
        }
        public void AddUnit(IUnit unit)
        {
            units.Add(unit);
        }

        public bool HasCity(Point point)
        {
            foreach(ICity city in Cities)
            {
                if (city.ControlledCases.Contains(point))
                {
                    return true;
                }
            }
            return false;
        }

        public bool HasUnit(Point point)
        {
            foreach (IUnit unit in Units)
            {
                if (unit.Position.Equals(point))
                {
                    return true;
                }
            }
            return false;
        }

        public void RemoveCity(ICity city)
        {
            cities.Remove(city);
        }

        public void RemoveUnit(IUnit unit)
        {
 	        units.Remove(unit);
        }

        /// <summary>
        /// Next turn.
        /// </summary>
        public void NextTurn()
        {
            units.ForEach(unit => unit.CurrentMovementNb = 0);            

            cities.ForEach(city => city.FindExtensionPoint());

            while (CitiesToBeExtended.Count != 0)
            {
                CitiesToBeExtended.Dequeue().ExtendPoint();
            }

            availableFood = 0;
            cities.ForEach(city => city.NextTurn());
            cities.ForEach(city => availableFood += city.Food);
            cities.ForEach(city => availableOre += city.Ore);

           
        }

        /// <summary>
        /// Renders the specified map viewer.
        /// </summary>
        /// <param name="mapViewer">The map viewer.</param>
        /// <param name="drawingContext">The drawing context.</param>
        /// <param name="viewPoints"></param>
        public void Render(MapViewer mapViewer, DrawingContext drawingContext, List<Point> viewPoints = null)
        {
            foreach (ICity city in cities)
            { 
                if (viewPoints != null)
                {
                    foreach (Point p in viewPoints)
                    {
                        if (city.Position.X > p.X - 5 && city.Position.X < p.X + 5 && city.Position.Y > p.Y - 5 && city.Position.Y < p.Y + 5)
                        {
                            city.Render(mapViewer, drawingContext, color);
                            break;
                        }
                    }
                }
                else
                {
                    city.Render(mapViewer, drawingContext, color);
                }
            }

            foreach (IUnit unit in units)
            {
                if (viewPoints != null)
                {
                     foreach (Point p in viewPoints)
                    {
                        if (unit.Position.X > p.X - 6 && unit.Position.X < p.X + 6 && unit.Position.Y > p.Y - 6 && unit.Position.Y < p.Y + 6)
                        {
                            unit.Render(mapViewer, drawingContext, color);
                            break;
                        }
                    }
                }
                else
                {
                    unit.Render(mapViewer, drawingContext, color);
                }
            }
        }

        /// <summary>
        /// Gets the units.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        public List<IUnit> GetUnits(Point point)
        {
            List<IUnit> units = new List<IUnit>();

            foreach (IUnit unit in Units)
            {
                if (unit.Position.Equals(point))
                {
                    units.Add(unit);
                }
            }

            return units;
        }

        /// <summary>
        /// Gets the city.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        public ICity GetCity(Point point)
        {
            foreach (ICity city in Cities)
            {
                if (city.ControlledCases.Contains(point))
                {
                    return city;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets all view point.
        /// </summary>
        /// <returns></returns>
        public List<Point> GetAllViewPoint()
        {
            List<Point> viewPoints = new List<Point>();

            foreach (ICity city in cities)
            {
                viewPoints.Add(city.Position);
            }

            foreach (IUnit unit in units)
            {
                viewPoints.Add(unit.Position);
            }

            return viewPoints;
        }
        #endregion
    }
}
