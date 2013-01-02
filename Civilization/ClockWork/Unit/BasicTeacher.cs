
namespace Civilization.ClockWork.Unit
{
    public class BasicTeacher : Unit, ITeacher
    {
        #region constructors
        public BasicTeacher(int attack, int defence, int cost, int hp, int movement) 
            : base(attack, defence, cost, hp, movement)
        {

        }
        #endregion

        #region methods
        public void CreateCity()
        {
            throw new System.NotImplementedException();
        }

        public object Clone()
        {
            return (object)this.MemberwiseClone();
        }
        #endregion
    }
}
