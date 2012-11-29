#region usings
using System;
using System.Collections.Generic;
using System.Drawing;
#endregion

namespace Civilization.Civilization.Unit
{
    #region enumerates
    public enum UnitState
    {
        US_ATTACK,
        US_MOVING,
        US_DEFENCE,
        US_WAITING,
    };
    #endregion

    #region classes
    [Serializable()]
    public class Unit : IUnit
    {        
        #region fields
        private Dictionary<UnitState, Sprite> stateMotions;
        
        private Point casePosition;
        
        private int attack;

        private int cost;

        private int defense;

        private int hp;

        private int movement;
        #endregion

        #region properties
        public int Attack
        {
            get { return attack; }
        }

        public int Cost
        {
            get { return cost; }
        }

        public int Defense
        {
            get { return defense; }
        }

        public int HP
        {
            get { return hp; }
        }

        public int Movement
        {
            get { return movement; }
        }

        public System.Drawing.Point Position
        {
            get
            {
                return casePosition;
            }
            set
            {
                casePosition = value;
            }
        }

        public bool IsDead
        {
            get { throw new System.NotImplementedException(); }
        }

        public bool IsInCity
        {
            get { throw new System.NotImplementedException(); }
        }
        #endregion

        #region constructor
        public Unit(int attack, int defence, int cost, int hp, int movement)
        {
            stateMotions = new Dictionary<UnitState, Sprite>();
            
            this.attack = attack;
            this.cost = cost;
            this.hp = hp;
            this.movement = movement;
        }
        #endregion        

        #region methods
        public void Damage(int damageValue)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
    #endregion
}
