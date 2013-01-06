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
        public void RemoveCity(ICity city)
        {
            cities.Remove(city);
        }
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
        public void NextTurn()
        {
            availableFood = 0;
            cities.ForEach(city => city.NextTurn());
            cities.ForEach(city => availableFood = city.Food);
            cities.ForEach(city => availableOre += city.Ore);

        }
        #endregion
    }
}
