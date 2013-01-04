using System;

namespace Civilization.ClockWork.Unit
{
   [Serializable()]
    public class BasicDepartDirector : Unit, IDepartDirector
    {
        #region fields
        private double defenceBonus;

        private double attackBonus;
        #endregion

        #region constructors
        public BasicDepartDirector() : base(0, 2, 5, 3)
        {
            defenceBonus = 0.50; // 50%.
            attackBonus = 0.50; // 50%.
        }
        #endregion

        #region properties
        /// <summary>
        /// Gets the attack bonus.
        /// </summary>
        /// <value>
        /// The attack bonus.
        /// </value>
        public double AttackBonus
        {
            get { return attackBonus; }
        }

        /// <summary>
        /// Gets the defence bonus.
        /// </summary>
        /// <value>
        /// The defence bonus.
        /// </value>
        public double DefenceBonus
        {
            get { return defenceBonus; }
        }

        /// <summary>
        /// Gets the cost.
        /// </summary>
        /// <value>
        /// The cost.
        /// </value>
        public override int Cost
        {
            get
            {
                return 20 * (Attack + Defense + Movement + HP);
            }
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
