﻿using System;
using System.Collections.Generic;
using System.Drawing;

namespace Civilization.Civilization.Unit
{
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
        public Unit()
        {
            stateMotions = new Dictionary<UnitState, Sprite>();
        }
        #endregion        

        #region methods
        public void Damage(int damageValue)
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}