using System;
using System.Windows;

namespace Civilization.ClockWork.Unit
{
    public interface IUnit : ICloneable
    {
        #region properties
        int Attack
        {
            get;
            set;
        }

        int Cost
        {
            get;
        }

        int Defense
        {
            get;
            set;
        }

        int HP
        {
            get;
            set;
        }

        int Movement
        {
            get;
            set;
        }

        Point Position
        {
            get;
            set;
        }

        bool IsDead
        {
            get;
        }

        bool IsInCity
        {
            get;
        }
        #endregion

        #region methods
        void Damage(int damageValue);
        #endregion
    }
}
