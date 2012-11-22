using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Civilization.Game
{
    public interface IGameState
    {
        #region methods

        /// <summary>
        /// Destroys this instance.
        /// </summary>
        public void Destroy();
        /// <summary>
        /// Draws with the specified engine.
        /// </summary>
        /// <param name="engine">The engine.</param>
        public void Draw(GraphicEngine engine);
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize();
        /// <summary>
        /// Handles the pressed Keyboard event.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="e">The <see cref="KeyboardEventArgs" /> instance containing the event data.</param>
        public void KeyboardPressedEventHandler(Object o, KeyboardEventArgs e);
        /// <summary>
        /// Loads the components.
        /// </summary>
        public void LoadComponents();
        /// <summary>
        /// Handles the clicked mouse event.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        public void MouseClickedEventHandler(Object o, MouseEventArgs e);
        /// <summary>
        /// Handles the moved mouse event.
        /// </summary>
        /// <param name="o">The o.</param>
        /// <param name="e">The <see cref="MouseEventArgs" /> instance containing the event data.</param>
        public void MouseMovedEventHandler(Object o, MouseEventArgs e);
        /// <summary>
        /// Pauses this instance.
        /// </summary>
        public void Pause();
        /// <summary>
        /// Sets the game.
        /// </summary>
        /// <param name="game">The game.</param>
        public void SetGame(Game game);
        /// <summary>
        /// Starts this instance.
        /// </summary>
        public void Start();
        /// <summary>
        /// Updates the game every deltaTime.
        /// </summary>
        /// <param name="deltaTime">The delta time.</param>
        public void Update(float deltaTime);

        #endregion
    }
}
