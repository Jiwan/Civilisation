using System.Windows;
using System.Drawing;
using Civilization.World.Map;
using System.Runtime.Serialization;
using System.Collections;

namespace Civilization.Game
{
    class Game// : ISerializable
    {
        #region fields
        //private IGraphicEngine engine;
        private Window mainWindow;
        private Civilization.World.Map.Map map;
        private Stack states;
        private Player[] players; 
        #endregion

        #region properties
        public Player[] Players
        {
            get {return players;}
        }

        public Map Map
        {
            set {this.map = value;}
        }

        #endregion

        #region constructors
        public Game()
        {
            //engine = new GraphicEngine();
            mainWindow = new Window();
            map = new Map(new System.Drawing.Point(25, 25));
            states = new Stack(); 
            players = new Player[2];
        }

        public Game(SerializationInfo info)
        {
            //engine = new GraphicEngine();
            mainWindow = new Window();
            // à implémenter
        }
        #endregion

        #region methods
        //public void AddPlayer(IPlayer newPlayer) { };
        public void GetObjectData(SerializationInfo info){}
        public IGameState PopState()
        {
            return states.Pop();
        }

        public void PushState(IGameState gameState)
        {
            states.Push(gameState);
        }

        #endregion
    }
}
