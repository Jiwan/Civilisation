using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Civilization.Game
{
    public class ActiveState : IGameState
    {
        #region fields
        private Game game;
        #endregion

        #region constructors

        public ActiveState(Game game)
        {
            this.game = game;
        }

        private ~ActiveState()
        {
        }

        #endregion

        #region methods

        public void Destroy()
        {
            ~ActiveState();
        }

        public void Draw(GraphicEngine engine)
        {
            throw new NotImplementedException();
        }

        public void Initialize()
        {
            throw new NotImplementedException();
        }

        public void KeyboardPressedEventHandler(object o, System.Windows.Input.KeyboardEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void LoadComponents()
        {
            throw new NotImplementedException();
        }

        public void MouseClickedEventHandler(object o, System.Windows.Input.MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void MouseMovedEventHandler(object o, System.Windows.Input.MouseEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void SetGame(Game game)
        {
            throw new NotImplementedException();
        }

        public void Start()
        {
            throw new NotImplementedException();
        }

        public void Update(float deltaTime)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
