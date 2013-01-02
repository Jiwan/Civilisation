using Civilization.ClockWork.Unit;
using Civilization.Player;

namespace Civilization.Fight
{
    public interface IFight
    {
        #region methods

        void AddSupportToAttack();

        void AddSupportToDefence();

        void StartFight();

        Winner GetWinner();
        #endregion
    }
}
