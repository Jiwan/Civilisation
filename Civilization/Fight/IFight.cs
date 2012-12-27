using Civilization.Civilization.Unit;
using Civilization.Player;

namespace Civilization.Fight
{
    public interface IFight
    {
        #region methods
        void AddDefender(IUnit unit);

        void AddFighter(IUnit unit);

        void AddSupport(IDepartDirector unit);

        void StartFight();

        IPlayer GetWinner();
        #endregion
    }
}
