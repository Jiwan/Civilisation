using System.Windows;
using System.Drawing;
using Civilization.World.Map;
using System.Runtime.Serialization;
using System.Collections;
using System.Collections.Generic;

namespace Civilization.Game
{
    class Game : ISerializable
    {
        #region fields
        /// <summary>
        /// The engine
        /// </summary>
        private GraphicEngine engine;
        /// <summary>
        /// The main window
        /// </summary>
        private Window mainWindow;
        /// <summary>
        /// The map
        /// </summary>
        private Civilization.World.Map.Map map;
        /// <summary>
        /// The game states
        /// </summary>
        private Stack states;
        /// <summary>
        /// The players
        /// </summary>
        private List<Player> players;
        #endregion

        #region properties
        /// <summary>
        /// Gets the players.
        /// </summary>
        /// <value>
        /// The players.
        /// </value>
        public IList<Player> Players
        {
            get { return players; }
        }

        /// <summary>
        /// Sets the map.
        /// </summary>
        /// <value>
        /// The map.
        /// </value>
        public Map Map
        {
            set { map = value; }
        }

        /// <summary>
        /// Sets the engine.
        /// </summary>
        /// <value>
        /// The engine.
        /// </value>
        public GraphicEngine engine
        {
            set { engine = value; }
        }

        #endregion

        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Game" /> class.
        /// </summary>
        public Game()
        {
            engine = new GraphicEngine();
            mainWindow = new Window();
            map = new Map(new System.Drawing.Point(25, 25));
            states = new Stack();
            players = new List<Player>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Game" /> class.
        /// </summary>
        /// <param name="info">The serialization info.</param>
        public Game(SerializationInfo info)
        {
            engine = new GraphicEngine();
            mainWindow = new Window();
            // à implémenter
        }
        #endregion

        #region methods

        /// <summary>
        /// Adds the player.
        /// </summary>
        /// <param name="newPlayer">The new player.</param>
        public void AddPlayer(IPlayer newPlayer)
        {
            players.Add(newPlayer);
        }
        /// <summary>
        /// Gets the object data.
        /// </summary>
        /// <param name="info">The info.</param>
        public void GetObjectData(SerializationInfo info) { }
        /// <summary>
        /// Pops the state.
        /// </summary>
        /// <returns></returns>
        public IGameState PopState()
        {
            return states.Pop();
        }

        /// <summary>
        /// Pushes the state.
        /// </summary>
        /// <param name="gameState">State of the game.</param>
        public void PushState(IGameState gameState)
        {
            states.Push(gameState);
        }
        #endregion
    }
}
