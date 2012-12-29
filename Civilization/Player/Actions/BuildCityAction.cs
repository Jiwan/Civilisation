using System.Drawing;

namespace Civilization.Player.Actions
{
    public class BuildCityAction : IPlayerAction
    {
        #region properties
        public Point CityPosition { get; set; }
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
