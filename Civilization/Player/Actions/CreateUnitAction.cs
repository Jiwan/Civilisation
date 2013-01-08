using Civilization.ClockWork.City;
using Civilization.ClockWork.Unit;

namespace Civilization.Player.Actions
{
    public class CreateUnitAction : InGameAction
    {
        #region properties
        /// <summary>
        /// Gets or sets the selected city.
        /// </summary>
        /// <value>
        /// The selected city.
        /// </value>
        public ICity SelectedCity { get; set; }
        /// <summary>
        /// Gets or sets the new unit.
        /// </summary>
        /// <value>
        /// The new unit.
        /// </value>
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
