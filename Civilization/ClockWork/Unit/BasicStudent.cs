using System;

namespace Civilization.ClockWork.Unit
{
    [Serializable()]
    public class BasicStudent : Unit, IStudent
    {
        #region constructors
        public BasicStudent() : base(4, 2, 100, 10, 2) 
        {

        }

        public BasicStudent(int attack, int defence, int cost, int hp, int movement) 
            : base(attack, defence, cost, hp, movement)
        {

        }
        #endregion

        #region properties
        public bool CanAttack
        {
            get { throw new System.NotImplementedException(); }
        }
        #endregion

        #region methods
        public object Clone()
        {
           return (object)this.MemberwiseClone();
        }
        #endregion
    }
}
