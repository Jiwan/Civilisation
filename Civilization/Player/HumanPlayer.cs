using System.Collections.Generic;
using Civilization.ClockWork.Unit;
using Civilization.ClockWork.City;
using System.Drawing;
using System;
using Civilization.Player.Actions;
using System.Windows.Input;

namespace Civilization.Player
{
    class HumanPlayer : IPlayer
    {
        #region Attributes

        /// <summary>
        /// The cities
        /// </summary>
        private IList<ICity> cities;

        /// <summary>
        /// The units
        /// </summary>
        private IList<IUnit> units;

        /// <summary>
        /// The game
        /// </summary>
        private Game.Game game; 
        #endregion

        #region Constructeur

        public HumanPlayer(string name, System.Windows.Media.Color color)
        {
            Name = name;
            Color = color;
        }

        #endregion

        #region properties

        /// <summary>
        /// Gets the cities.
        /// </summary>
        /// <value>
        /// The cities.
        /// </value>
        public IList<ICity> Cities
        {
            get
            {
                return cities;
            }
        }

        public IList<IUnit> Units
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

        public string Name { get; set; }

        public System.Windows.Media.Color Color { get; set; }
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
            foreach(ICity city in Cities)
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
        public bool HasUnit(System.Drawing.Point point)
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

        public bool IsDead()
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

        public void KeyboardPressedEventHandler(Object o, KeyEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        public void MousePressedEventHandler(Object o, MouseEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        public void MouseMovedEventHandler(Object o, MouseEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
