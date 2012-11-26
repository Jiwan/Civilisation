using System.Drawing;

namespace Civilization.Civilization.Unit
{
    public interface IUnit
    {
        #region properties
        public int Attack
        {
            get;
        }

        public int Cost
        {
            get;
        }

        public int Defense
        {
            get;
        }

        public int HP
        {
            get;
        }

        public int Movement
        {
            get;
        }

        public Point Position
        {
            get;
            set;
        }

        public bool IsDead
        {
            get;
        }

        public bool IsInCity
        {
            get;
        }
        #endregion

        #region methods
        public void Damage(int damageValue);
        #endregion
    }
}
