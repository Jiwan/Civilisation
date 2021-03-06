﻿#region usings
using System;
using System.Collections.Generic;
using System.Windows;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Globalization;
using System.Windows.Media.Imaging;
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
    public abstract class Unit : IUnit, INotifyPropertyChanged
    {        
        #region fields
        /// <summary>
        /// The case position
        /// </summary>
        private Point casePosition;

        /// <summary>
        /// The attack
        /// </summary>
        private int attack;

        /// <summary>
        /// The defense
        /// </summary>
        private int defense;

        /// <summary>
        /// The hp
        /// </summary>
        private int hp;

        /// <summary>
        /// The movement
        /// </summary>
        private int movement;

        /// <summary>
        /// The current movement nb
        /// </summary>
        private int currentMovementNb;
        #endregion

        #region properties
        /// <summary>
        /// Gets the tile.
        /// </summary>
        /// <value>
        /// The tile.
        /// </value>
        public abstract BitmapImage Tile { get; }

        /// <summary>
        /// Gets or sets the attack.
        /// </summary>
        /// <value>
        /// The attack.
        /// </value>
        public int Attack
        {
            get 
            { 
                return attack; 
            }
            set 
            {
                NotifyPropertyChanged(true, "Attack");
                attack = value; 
            }
        }

        /// <summary>
        /// Gets the cost.
        /// </summary>
        /// <value>
        /// The cost.
        /// </value>
        public virtual int Cost
        {
            get { return 0; }
        }

        /// <summary>
        /// Gets or sets the defense.
        /// </summary>
        /// <value>
        /// The defense.
        /// </value>
        public int Defense
        {
            get 
            { 
                return defense; 
            }
            set 
            {
                NotifyPropertyChanged(true, "Defense");
                defense = value; 
            }
        }

        /// <summary>
        /// Gets or sets the HP.
        /// </summary>
        /// <value>
        /// The HP.
        /// </value>
        public int HP
        {
            get
            {
                return hp;
            }
            set
            {
                NotifyPropertyChanged(true, "HP");
                hp = value;
            }
        }

        /// <summary>
        /// Gets or sets the movement.
        /// </summary>
        /// <value>
        /// The movement.
        /// </value>
        public int Movement
        {
            get 
            { 
                return movement;
            }
            set 
            {
                NotifyPropertyChanged(true, "Movement");
                movement = value; 
            }
        }

        /// <summary>
        /// Gets or sets the current movement nb.
        /// </summary>
        /// <value>
        /// The current movement nb.
        /// </value>
        public int CurrentMovementNb
        {
            get
            {
                return currentMovementNb;
            }
            set
            {
                currentMovementNb = value;
                NotifyPropertyChanged(false, "RemainingMovement");
                NotifyPropertyChanged(false, "CurrentMovementNb");                
            }
        }

        public int RemainingMovement
        {
            get
            {
                return movement - currentMovementNb;
            }
        }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        /// <value>
        /// The position.
        /// </value>
        public Point Position
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

        /// <summary>
        /// Gets a value indicating whether this unit is dead.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this unit is dead; otherwise, <c>false</c>.
        /// </value>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool IsDead
        {
            get { return hp <= 0; }
        }

        /// <summary>
        /// Gets a value indicating whether this unit is in a city.
        /// </summary>
        /// <value>
        /// <c>true</c> if this unit is in a city; otherwise, <c>false</c>.
        /// </value>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool IsInCity
        {
            get { throw new System.NotImplementedException(); }
        }

        public abstract string Name
        {
            get;
        }

        /// <summary>
        /// Occurs when [property changed].
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Unit" /> class.
        /// </summary>
        /// <param name="attack">The attack.</param>
        /// <param name="defense">The defense.</param>
        /// <param name="cost">The cost.</param>
        /// <param name="hp">The hp.</param>
        /// <param name="movement">The movement.</param>
        public Unit(int attack, int defense, int hp, int movement)
        {            
            this.attack = attack;
            this.defense = defense;
            this.hp = hp;
            this.movement = movement;
            currentMovementNb = 0;
        }
        #endregion        

        #region methods
        #region public
        /// <summary>
        /// Damages the specified damage value to the unit.
        /// </summary>
        /// <param name="damageValue">The damage value.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void Damage(int damageValue)
        {
            throw new System.NotImplementedException();
        }

        public object Clone()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Renders the specified map viewer.
        /// </summary>
        /// <param name="mapViewer">The map viewer.</param>
        /// <param name="drawingContext">The drawing context.</param>
        /// <param name="playerColor">Color of the player.</param>
        public void Render(CustomControls.MapViewer mapViewer, System.Windows.Media.DrawingContext drawingContext, System.Windows.Media.Color playerColor)
        {
            if (mapViewer.IsInView(casePosition))
            {
                Rect rect = mapViewer.GetRectangle((int)casePosition.X, (int)casePosition.Y);

                drawingContext.DrawImage(Tile, rect);
                SolidColorBrush myBrush = new SolidColorBrush(playerColor);
                myBrush.Opacity = 0.3;
                drawingContext.DrawRectangle(myBrush, null, rect);
            }
        }

        /// <summary>
        /// Moves to the left.
        /// </summary>
        public void MoveLeft()
        {
            casePosition.X--;
            CurrentMovementNb++;
        }

        /// <summary>
        /// Moves to the right.
        /// </summary>
        public void MoveRight()
        {
            casePosition.X++;
            CurrentMovementNb++;
        }

        /// <summary>
        /// Moves to the up.
        /// </summary>
        public void MoveUp()
        {
            casePosition.Y--;
            CurrentMovementNb++;
        }

        /// <summary>
        /// Moves to the down.
        /// </summary>
        public void MoveDown()
        {
            casePosition.Y++;
            CurrentMovementNb++;
        }

        /// <summary>
        /// Determines whether this instance can move.
        /// </summary>
        /// <returns>
        ///   <c>true</c> if this instance can move; otherwise, <c>false</c>.
        /// </returns>
        public bool CanMove()
        {
            return currentMovementNb < movement;
        }
        #endregion

        /// <summary>
        /// Notifies the property changed.
        /// </summary>
        /// <param name="updateCost">if set to <c>true</c> [update cost].</param>
        /// <param name="propertyName">Name of the property.</param>
        private void NotifyPropertyChanged(bool updateCost, String propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            if (updateCost)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Cost"));
            }

            if (propertyName != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
    #endregion
}
