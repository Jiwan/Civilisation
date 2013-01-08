using Civilization.ClockWork.City;

namespace Civilization.Player.Actions
{
    public class SelectCity : InGameAction
    {
        #region properties
        /// <summary>
        /// Gets or sets the selected city.
        /// </summary>
        /// <value>
        /// The selected city.
        /// </value>
        public ICity SelectedCity { get; set; }
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
