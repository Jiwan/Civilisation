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

        string Name
        {
            get;
        }

        public int CurrentMovementNb
        {
            get;
            set;
        }
        #endregion

        #region methods
        void Damage(int damageValue);

        void Render(CustomControls.MapViewer mapViewer, System.Windows.Media.DrawingContext drawingContext);

        void MoveLeft();

        void MoveRight();

        void MoveUp();

        void MoveDown();
        #endregion
    }
}
