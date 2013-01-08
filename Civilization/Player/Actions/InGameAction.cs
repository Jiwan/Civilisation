
namespace Civilization.Player.Actions
{
    public class InGameAction : IPlayerAction
    {
        #region properties
        /// <summary>
        /// Gets or sets the player.
        /// </summary>
        /// <value>
        /// The player.
        /// </value>
        public IPlayer Player { get; set; }
        #endregion

        #region methods
        public virtual bool Do()
        {
            throw new System.NotImplementedException();
        }

        public virtual bool UnDo()
        {
            throw new System.NotImplementedException();
        }

        public virtual string GetLog()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
