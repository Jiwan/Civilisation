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
            // nombre de combats : choisi aléatoirement à l’engagement
            // (entre 3 et le nombre de points de vie de l’unité ayant le plus de points de vie + 2 points).
            Random rnd = new Random();
            int totalDefHP = 0, totalAttHP = 0;
            attackers.ForEach(attacker => totalAttHP += attacker.HP);
            defenders.ForEach(defender => totalDefHP += defender.HP);

            int nbCombats = rnd.Next(3, Math.Max(totalDefHP, totalAttHP) + 2);

            for (int i = 0; i < nbCombats; i++)
            {
                if (!TeamDefeated(defenders) && !TeamDefeated(attackers))
                {
                    double realAttack = 0, realDefence = 0;
                    attackers.ForEach(attacker => realAttack += (attacker.Attack * attacker.HP));
                    defenders.ForEach(defender => realDefence += (defender.Defense * defender.HP));

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

                    // On choisit une victime et c'est elle qui prend cher :)
                    // Un membre de l'équipe adverse se blesse quand même, mais beaucoup moins
                    // Un peu random, mais ça rend le jeu palpitant
                    if (rnd.Next(0, 100) < realAttack / realDefence)
                    {
                        int victimIndex = rnd.Next(0, defenders.Count);
                        if (defenders[victimIndex].HP > attackers.Count)
                        {
                            defenders[victimIndex].HP -= attackers.Count;
                        }
                        else
                        {
                            defenders[victimIndex].HP = 0;
                        }
                        attackers[rnd.Next(0, attackers.Count)].HP--;
                    }
                    else
                    {
                        int victimIndex = rnd.Next(0, attackers.Count);
                        if (attackers[victimIndex].HP > defenders.Count)
                        {
                            attackers[victimIndex].HP -= defenders.Count;
                        }
                        else
                        {
                            attackers[victimIndex].HP = 0;
                        }
                        defenders[rnd.Next(0, defenders.Count)].HP--;
                    }
                }
                else if (!TeamDefeated(attackers))
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
        

        public static bool TeamDefeated(List<IUnit> team)
        {
            return team.TrueForAll(unit => unit.IsDead);
        }
        
        public Winner GetWinner()
        {
            return winner;
        }
    }
}
