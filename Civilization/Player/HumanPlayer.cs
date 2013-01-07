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
        private Queue<ICity> citiesToBeExtended;
        #endregion

        #region Constructeur
        public HumanPlayer(string name, System.Windows.Media.Color color)
        {
            this.name = name;
            Color = color;
            alive = true;
            cities = new List<ICity>();
            units = new List<IUnit>();
            citiesToBeExtended = new Queue<ICity>();
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

        public void NextTurn()
        {
            Log.Instance.Write("Prochain tour.");
            units.ForEach(unit => unit.Movement = 0);
            Log.Instance.Write("Mouvements des unités remis à 0.");

            cities.ForEach(city => city.FindExtensionPoint());
            Log.Instance.Write("Cases d'extension des villes trouvées.");

            while (CitiesToBeExtended.Count != 0)
            {
                CitiesToBeExtended.Dequeue().ExtendPoint();
            }
            Log.Instance.Write("Villes étendues.");

            availableFood = 0;
            cities.ForEach(city => city.NextTurn());
            cities.ForEach(city => availableFood += city.Food);
            cities.ForEach(city => availableOre += city.Ore);
            Log.Instance.Write("Nourriture et minerai mis à jour.");
        }

        public void Render(MapViewer mapViewer, DrawingContext drawingContext)
        {
            foreach (ICity city in cities)
            {
                city.Render(mapViewer, drawingContext);
            }

            foreach (IUnit unit in units)
            {
                unit.Render(mapViewer, drawingContext);
            }
        }
        #endregion
    }
}
