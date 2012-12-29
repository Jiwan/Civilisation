using Civilization.Civilization.Unit;

namespace Civilization.Player.Actions
{
    public class SelectUnitAction : IPlayerAction
    {
        #region properties
        public IUnit SelectedUnit { get; set; }
        #endregion

        #region methods
        public bool Do()
        {
            throw new System.NotImplementedException();
        }

        public bool UnDo()
        {
            throw new System.NotImplementedException();
        }

        public string GetLog()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
