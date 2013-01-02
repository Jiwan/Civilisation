#region usings
using Civilization.Civilization.Unit;
using Civilization.Player;
using System;
#endregion

namespace Civilization.Fight
{
    #region enumerates
    public enum Winner
    {
        W_ATTACKER,
        W_DEFENDER,
        W_NONE,
    };
    #endregion

    public class _1V1Fight : IFight
    {
        #region fields
        private IUnit attacker;
        private IUnit defender;
        private IDepartDirector support;
        private Winner winner;
        #endregion

        #region methods
        public void AddDefender(IUnit unit)
        {
            // TODO : Lorsqu’une unité attaque une case contenant plusieurs unités, la meilleure unité défensive est choisie.
            defender = unit;
        }

        public void AddFighter(IUnit unit)
        {
            if (unit.Attack != 0)
            {
                attacker = unit;
            }
            else
            {
                throw AttackException("This unit cannot attack\n");
            }
        }

        private System.Exception AttackException(string p)
        {
            throw new Exception(p);
        }

        public void AddSupport(IDepartDirector unit)
        {
            support = unit;
        }

        public void StartFight()
        {
            winner = Winner.W_NONE;
            // nombre de combats : choisi aléatoirement à l’engagement (entre 3 et le nombre de points de vie de l’unité ayant le plus de points de vie + 2 points).
            Random rnd = new Random();
            int nbCombats = rnd.Next(3, Math.Max(defender.HP, attacker.HP) + 2);

            for (int i = 0; i < nbCombats; i++)
            {
                if (defender.HP != 0 && attacker.HP != 0)
                {
                    int realAttack = attacker.Attack * attacker.HP;
                    int realDefence = defender.Defense * defender.HP;

                    if (rnd.Next(0, 100) < realAttack / realDefence)
                        defender.HP--;
                    if (rnd.Next(0, 100) < 1 / (realDefence / realAttack))
                        attacker.HP--;
                }
                else if (attacker.HP == 0)
                {
                    winner = Winner.W_DEFENDER;
                    return;
                }
                else
                {
                    winner = Winner.W_ATTACKER;
                    return;
                }
            }
        }

        public IPlayer GetWinner()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}
