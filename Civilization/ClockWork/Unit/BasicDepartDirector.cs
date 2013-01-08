using System;
using System.Windows.Media.Imaging;
using Civilization.Utils.Drawing;

namespace Civilization.ClockWork.Unit
{
   [Serializable()]
    public class BasicDepartDirector : Unit, IDepartDirector
    {
        #region fields
        private double defenceBonus;

        private double attackBonus;

        /// <summary>
        /// The tile
        /// </summary>
        private static readonly BitmapImage tile = TileFlyWeight.Instance.GetBitmapImage(new Uri(@"pack://application:,,,/Images/sprite_director.png", UriKind.Absolute));
        #endregion

        #region propeperties
        /// <summary>
        /// Gets the tile.
        /// </summary>
        /// <value>
        /// The tile.
        /// </value>
        public override BitmapImage Tile
        {
            get { return tile; }
        }
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

        public override string Name
        {
            get { return "Directeur de département"; }
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
