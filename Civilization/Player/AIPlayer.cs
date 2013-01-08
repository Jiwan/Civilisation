using System.Collections.Generic;
using Civilization.ClockWork.Unit;
using Civilization.ClockWork.City;
using System.Windows;
using Civilization.Player.Actions;
using Civilization.CustomControls;
using System.Windows.Media;

namespace Civilization.Player
{
    public class AIPlayer : IPlayer
    {
        #region Attributes
        /// <summary>
        /// bool true if alive
        /// </summary>
        private bool alive;
        /// <summary>
        /// The cities
        /// </summary>
        private List<ICity> cities;
        /// <summary>
        /// The units
        /// </summary>
        private List<IUnit> units;
        /// <summary>
        /// The game
        /// </summary>
        private Game.Game game;
        /// <summary>
        /// The name
        /// </summary>
        private string name;
        /// <summary>
        /// The played civilization
        /// </summary>
        private Civilization.ClockWork.Civilization playedCivilization;
        /// <summary>
        /// The color
        /// </summary>
        private System.Windows.Media.Color color;
        /// <summary>
        /// The available food
        /// </summary>
        private uint availableFood;
        /// <summary>
        /// The available ore
        /// </summary>
        private uint availableOre;
        /// <summary>
        /// The cities to be extended
        /// </summary>
        private Queue<ICity> citiesToBeExtended;
        #endregion

        #region properties
        /// <summary>
        /// Gets or sets a value indicating whether this <see cref="AIPlayer" /> is alive.
        /// </summary>
        /// <value>
        ///   <c>true</c> if alive; otherwise, <c>false</c>.
        /// </value>
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
        /// <summary>
        /// Gets the cities.
        /// </summary>
        /// <value>
        /// The cities.
        /// </value>
        public List<ICity> Cities
        {
            get
            {
                return cities;
            }
        }
        /// <summary>
        /// Gets the units.
        /// </summary>
        /// <value>
        /// The units.
        /// </value>
        public List<IUnit> Units
        {
            get
            {
                return units;
            }
        }
        /// <summary>
        /// Gets or sets the game.
        /// </summary>
        /// <value>
        /// The game.
        /// </value>
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
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
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
        /// <summary>
        /// Gets or sets the played civilization.
        /// </summary>
        /// <value>
        /// The played civilization.
        /// </value>
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
        /// <summary>
        /// Gets or sets the color.
        /// </summary>
        /// <value>
        /// The color.
        /// </value>
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
        /// <summary>
        /// Gets or sets the available food.
        /// </summary>
        /// <value>
        /// The available food.
        /// </value>
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
        /// <summary>
        /// Gets or sets the available ore.
        /// </summary>
        /// <value>
        /// The available ore.
        /// </value>
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
        /// <summary>
        /// Gets or sets the cities to be extended.
        /// </summary>
        /// <value>
        /// The cities to be extended.
        /// </value>
        public Queue<ICity> CitiesToBeExtended
        {
            get;
            set;
        }
        #endregion

        #region constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="AIPlayer" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="color">The color.</param>
        public AIPlayer(string name, System.Windows.Media.Color color)
        {
            Name = name;
            Color = color;
            alive = true;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Adds the city.
        /// </summary>
        /// <param name="city">The city.</param>
        public void AddCity(ICity city)
        {
            cities.Add(city);
        }

        /// <summary>
        /// Adds the unit.
        /// </summary>
        /// <param name="unit">The unit.</param>
        public void AddUnit(IUnit unit)
        {
            units.Add(unit);
        }

        /// <summary>
        /// Determines whether the specified point has a city.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>
        ///   <c>true</c> if the specified point has city; otherwise, <c>false</c>.
        /// </returns>
        public bool HasCity(Point point)
        {
            foreach (ICity city in Cities)
            {
                if (city.ControlledCases.Contains(point))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether the specified point has a unit.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns>
        ///   <c>true</c> if the specified point has unit; otherwise, <c>false</c>.
        /// </returns>
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

        public IPlayerAction GetCommands()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// Removes the city.
        /// </summary>
        /// <param name="city">The city.</param>
        public void RemoveCity(ICity city)
        {
            cities.Remove(city);
        }

        /// <summary>
        /// Removes the unit.
        /// </summary>
        /// <param name="unit">The unit.</param>
        public void RemoveUnit(IUnit unit)
        {
            units.Remove(unit);
        }

        public void NextTurn()
        {
            availableFood = 0;
            cities.ForEach(city => city.NextTurn());
            cities.ForEach(city => availableFood += city.Food);
            cities.ForEach(city => availableOre += city.Ore);

        }

        public void Render(MapViewer mapViewer, DrawingContext drawingContext, List<Point> viewPoints = null)
        {

        }

        /// <summary>
        /// Gets the units.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        public List<IUnit> GetUnits(Point point)
        {
            return null;
        }

        /// <summary>
        /// Gets the city.
        /// </summary>
        /// <param name="point">The point.</param>
        /// <returns></returns>
        public ICity GetCity(Point point)
        {
            return null;
        }

        public List<Point> GetAllViewPoint()
        {
            return null;
        }

        /// <summary>
        /// Determines whether this instance has director.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance has director; otherwise, <c>false</c>.
        /// </returns>
        public bool HasDirector()
        {
            return false;
        }

        /// <summary>
        /// Determines whether this instance is dead.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance is dead; otherwise, <c>false</c>.
        /// </returns>
        public bool IsDead()
        {
            return true;
        }
        #endregion


    }
}
