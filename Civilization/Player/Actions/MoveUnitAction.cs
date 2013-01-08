using System.Drawing;
using Civilization.ClockWork.Unit;

namespace Civilization.Player.Actions
{
    public class MoveUnitAction : IPlayerAction
    {
        #region properties
        /// <summary>
        /// Gets or sets the attack position.
        /// </summary>
        /// <value>
        /// The attack position.
        /// </value>
        public Point AttackPosition { get; set; }
        /// <summary>
        /// Gets or sets the moving unit.
        /// </summary>
        /// <value>
        /// The moving unit.
        /// </value>
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
