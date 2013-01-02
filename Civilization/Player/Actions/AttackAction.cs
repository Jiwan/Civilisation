using System.Drawing;
using Civilization.ClockWork.Unit;

namespace Civilization.Player.Actions
{
    public class AttackAction : IPlayerAction
    {
        #region properties
        public Point AttackPosition { get; set; }
        public IUnit AttackerUnit { get; set; }
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
