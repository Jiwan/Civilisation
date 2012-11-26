using System;

namespace Civilization.Civilization.Unit
{
    public interface IDepartDirector : IUnit
    {
        #region properties
        /// <summary>
        /// Gets the attack bonus.
        /// </summary>
        /// <value>
        /// The attack bonus.
        /// </value>
        int AttackBonus { get; }

        /// <summary>
        /// Gets the defence bonus.
        /// </summary>
        /// <value>
        /// The defence bonus.
        /// </value>
        int DefenceBonus { get; }
        #endregion
    }
}
