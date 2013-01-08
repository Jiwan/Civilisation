using System.Drawing;
using Civilization.ClockWork.Unit;

namespace Civilization.Player.Actions
{
    public class AttackAction : IPlayerAction
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
        /// Gets or sets the attacker unit.
        /// </summary>
        /// <value>
        /// The attacker unit.
        /// </value>
        public IUnit AttackerUnit { get; set; }
        #endregion

        #region methods
        /// <summary>
        /// Does this instance.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="System.NotImplementedException"></exception>
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
