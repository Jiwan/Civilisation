
namespace Civilization.Player.Actions
{
    public class InGameAction : IPlayerAction
    {
        #region properties
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
