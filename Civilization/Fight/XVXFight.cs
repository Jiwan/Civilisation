#region usings
using Civilization.ClockWork.Unit;
using Civilization.Player;
using System;
using System.Collections.Generic;
#endregion

namespace Civilization.Fight
{
    class XVXFight : IFight
    {
        #region fields
        private List<IUnit> attackers;
        private List<IUnit> defenders;
        private Winner winner;
        private Support support;
        #endregion

        public XVXFight(IUnit initialAttacker, IUnit initialDefender)
        {
            attackers = new List<IUnit>();
            attackers.Add(initialAttacker);
            defenders = new List<IUnit>();
            defenders.Add(initialDefender);
            winner = Winner.W_NONE;
        }

        public void addAttacker(IUnit attacker)
        {
            attackers.Add(attacker);
        }

        public void addDefender(IUnit defender)
        {
            defenders.Add(defender);
        }

        public void AddSupportToAttack()
        {
            switch (support)
            {
                case Support.S_NONE:
                    support = Support.S_ATTACKER;
                    break;
                case Support.S_DEFENDER:
                    support = Support.S_BOTH;
                    break;
                default:
                    Console.WriteLine("Attacker already has the support of a director!");
                    break;
            }
        }

        public void AddSupportToDefence()
        {
            switch (support)
            {
                case Support.S_NONE:
                    support = Support.S_DEFENDER;
                    break;
                case Support.S_ATTACKER:
                    support = Support.S_BOTH;
                    break;
                default:
                    Console.WriteLine("Defender already has the support of a director!");
                    break;
            }
        }

        public void StartFight()
        {
            // Demain Jean :-)
            throw new NotImplementedException();
        }

        public Winner GetWinner()
        {
            return winner;
        }
    }
}
