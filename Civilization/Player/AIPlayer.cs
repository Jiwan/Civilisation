﻿using System.Collections.Generic;
using Civilization.ClockWork.Unit;
using Civilization.ClockWork.City;
using System.Drawing;
using Civilization.Player.Actions;

namespace Civilization.Player
{
    class AIPlayer : IPlayer
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
        #endregion

        #region constructor
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

        public void NextTurn()
        {
            availableFood = 0;
            cities.ForEach(city => city.NextTurn());
            cities.ForEach(city => availableFood += city.Food);
            cities.ForEach(city => availableOre += city.Ore);

        }
        #endregion


    }
}
