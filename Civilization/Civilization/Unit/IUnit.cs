using System;
using System.Drawing;

namespace Civilization.Civilization.Unit
{
    public interface IUnit : ICloneable
    {
        #region properties
        int Attack
        {
            get;
        }

        int Cost
        {
            get;
        }

        int Defense
        {
            get;
        }

        int HP
        {
            get;
        }

        int Movement
        {
            get;
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
