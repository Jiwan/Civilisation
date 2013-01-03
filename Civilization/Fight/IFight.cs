using Civilization.ClockWork.Unit;
using Civilization.Player;

namespace Civilization.Fight
{
    public interface IFight
    {
        #region methods
        /// <summary>
        /// Adds the support to attack.
        /// </summary>
        void AddSupportToAttack();

        /// <summary>
        /// Adds the support to defence.
        /// </summary>
        void AddSupportToDefence();

        /// <summary>
        /// Starts the fight.
        /// </summary>
        void StartFight();

        /// <summary>
        /// Gets the winner.
        /// </summary>
        /// <returns></returns>
        Winner GetWinner();
        #endregion
    }
}
