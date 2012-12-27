using System.Drawing;
using Civilization.Civilization.Unit;

namespace Civilization.Player.Actions
{
    public class AttackAction : IPlayerAction
    {
        #region properties
        public Point AttackPosition { get; set; }
        public IUnit AttackerUnit { get; set; }
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
