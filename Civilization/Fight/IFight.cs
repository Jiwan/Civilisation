﻿
namespace Civilization.Fight
{
    interface IFight
    {
        #region methods
        public void AddDefender(IUnit unit);
        public void AddFighter(IUnit unit);
        public void AddSupport(IDepartDirector unit);
        public void StartFight();
        public IPlayer GetWinner();
        #endregion
    }
}
