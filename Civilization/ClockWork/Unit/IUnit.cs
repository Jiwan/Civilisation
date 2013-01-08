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

        int CurrentMovementNb
        {
            get;
            set;
        }

        int RemainingMovement
        {
            get;
        }
        #endregion

        #region methods
        void Damage(int damageValue);

        void Render(CustomControls.MapViewer mapViewer, System.Windows.Media.DrawingContext drawingContext, System.Windows.Media.Color playerColor);

        void MoveLeft();

        void MoveRight();

        void MoveUp();

        void MoveDown();

        bool CanMove();
        #endregion
    }
}
