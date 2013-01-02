using Civilization.ClockWork.City;
using Civilization.ClockWork.Unit;

namespace Civilization.Player.Actions
{
    public class CreateUnitAction : InGameAction
    {
        #region properties
        public ICity SelectedCity { get; set; }
        public IUnit NewUnit { get; set; }
        #endregion

        #region methods
        public override bool Do()
        {
            throw new System.NotImplementedException();
        }

        public override bool UnDo()
        {
            throw new System.NotImplementedException();
        }

        public override string GetLog()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
