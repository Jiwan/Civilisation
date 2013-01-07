using System;

namespace Civilization.ClockWork.Unit
{
    [Serializable()]
    public class BasicTeacher : Unit, ITeacher
    {
        #region properties
        public override int Cost
        {
            get
            {
                return 12 * (Attack + Defense + Movement + HP);
            }
        }
        #endregion 

        #region constructors
        public BasicTeacher() : base(0, 1, 1, 3)
        {

        }

        public BasicTeacher(int attack, int defence, int hp, int movement) 
            : base(attack, defence, hp, movement)
        {

        }
        #endregion

        #region methods
        public void CreateCity()
        {
            throw new NotImplementedException();
            /*
            if (MainWindow.players.hasCity(this.Position))
            {

            }
             */
        }

        public object Clone()
        {
            return (object)this.MemberwiseClone();
        }
        #endregion
    }
}
