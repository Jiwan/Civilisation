using System.Drawing;
using Civilization.Civilization.Unit;

namespace Civilization.Player.Actions
{
    public class MoveUnitAction : IPlayerAction
    {
        #region properties
        public Point AttackPosition { get; set; }
        public IUnit MovingUnit { get; set; }
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
