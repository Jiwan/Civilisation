#region usings
using System;
using System.Collections.Generic;
using System.Drawing;
#endregion

namespace Civilization.ClockWork.Unit
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
        /// <summary>
        /// Gets or sets the attack.
        /// </summary>
        /// <value>
        /// The attack.
        /// </value>
        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }

        public int Cost
        {
            get { return cost; }
        }

        public int Defense
        {
            get { return defense; }
            set { defense = value; }
        }

        public int HP
        {
            get
            {
                return hp;
            }
            set
            {
                hp = value;
            }
        }

        public int Movement
        {
            get { return movement; }
            set { movement = value; }
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

        public object Clone()
        {
            throw new NotImplementedException();
        }
        #endregion

    }
    #endregion
}
