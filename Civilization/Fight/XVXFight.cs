#region usings
using Civilization.Civilization.Unit;
using Civilization.Player;
using System;
using System.Collections.Generic;
#endregion

namespace Civilization.Fight
{
    class XVXFight : IFight
    {
        #region fields
        private List<IUnit> attacker;
        private List<IUnit> defender;
        private List<IDepartDirector> support;
        private Winner winner;
        #endregion


        public void AddDefender(IUnit unit)
        {
            throw new NotImplementedException();
        }

        public void AddFighter(IUnit unit)
        {
            throw new NotImplementedException();
        }

        public void AddSupport(IDepartDirector unit)
        {
            throw new NotImplementedException();
        }

        public void StartFight()
        {
            throw new NotImplementedException();
        }

        public IPlayer GetWinner()
        {
            throw new NotImplementedException();
        }
    }
}
