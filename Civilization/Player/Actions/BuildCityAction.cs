using System.Drawing;

namespace Civilization.Player.Actions
{
    public class BuildCityAction : IPlayerAction
    {
        #region properties
        public Point CityPosition { get; set; }
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
