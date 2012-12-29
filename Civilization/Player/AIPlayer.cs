using System.Collections.Generic;
using Civilization.Civilization.Unit;
using Civilization.Civilization.City;
using System.Drawing;
using Civilization.Player.Actions;

namespace Civilization.Player
{
    class AIPlayer : IPlayer
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

        #region properties

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

        #endregion
    }
}
