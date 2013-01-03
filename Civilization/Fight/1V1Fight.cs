#region usings
﻿using Civilization.ClockWork.Unit;
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

    public enum Support
    {
        S_ATTACKER,
        S_DEFENDER,
        S_BOTH,
        S_NONE,
    };
    #endregion

    public class _1V1Fight : IFight
    {
        #region fields
        private IUnit attacker;
        private IUnit defender;
        private Support support;
        private Winner winner;
        #endregion

        #region methods

        public _1V1Fight(IUnit att, IUnit def)
        {
            if (att.Attack != 0)
            {
                attacker = att;
            }
            else
            {
                throw AttackException("This unit cannot attack\n");
            }
            defender = def;
            winner = Winner.W_NONE;
        }

        private System.Exception AttackException(string p)
        {
            throw new Exception(p);
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
            // nombre de combats : choisi aléatoirement à l’engagement
            // (entre 3 et le nombre de points de vie de l’unité ayant le plus de points de vie + 2 points).
            Random rnd = new Random();
            int nbCombats = rnd.Next(3, Math.Max(defender.HP, attacker.HP) + 2);

            for (int i = 0; i < nbCombats; i++)
            {
                if (defender.HP != 0 && attacker.HP != 0)
                {
                    double realAttack = attacker.Attack * attacker.HP;
                    double realDefence = defender.Defense * defender.HP;

                    switch (support)
                    {
                        case Support.S_ATTACKER:
                            realAttack *= 1.5;
                            break;
                        case Support.S_DEFENDER:
                            realDefence *= 1.5;
                            break;
                        case Support.S_BOTH:
                            realAttack *= 1.5;
                            realDefence *= 1.5;
                            break;
                        default:
                            break;
                    }

                    if (rnd.Next(0, 100) < realAttack / realDefence)
                    {
                        defender.HP--;
                    }
                    else
                    {
                        attacker.HP--;
                    }
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

        public Winner GetWinner()
        {
            return winner;
        }
        #endregion
    }
}
