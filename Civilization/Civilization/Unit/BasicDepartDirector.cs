
namespace Civilization.Civilization.Unit
{
    public class BasicDepartDirector : Unit, IDepartDirector
    {
        #region fields
        private double defenceBonus;

        private double attackBonus;
        #endregion

        #region constructors
        public BasicDepartDirector() : base(0, 2, 200, 5, 3)
        {
            defenceBonus = 0.50; // 50%.
            attackBonus = 0.50; // 50%.
        }
        #endregion

        #region properties
        public double AttackBonus
        {
            get { return attackBonus; }
        }

        public double DefenceBonus
        {
            get { return defenceBonus; }
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
