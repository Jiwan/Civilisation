using System;
using System.Windows.Media.Imaging;
using Civilization.Utils.Drawing;

namespace Civilization.ClockWork.Unit
{
    [Serializable()]
    public class BasicStudent : Unit, IStudent
    {
        #region fields
        /// <summary>
        /// The tile
        /// </summary>
        private static readonly BitmapImage tile = TileFlyWeight.Instance.GetBitmapImage(new Uri(@"pack://application:,,,/Images/sprite_student.png", UriKind.Absolute));
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


        /// <summary>
        /// Initializes a new instance of the <see cref="BasicStudent" /> class.
        /// </summary>
        public BasicStudent() : base(4, 2, 10, 2) 
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BasicStudent" /> class.
        /// </summary>
        /// <param name="attack">The attack.</param>
        /// <param name="defence">The defence.</param>
        /// <param name="hp">The hp.</param>
        /// <param name="movement">The movement.</param>
        public BasicStudent(int attack, int defence, int hp, int movement) 
            : base(attack, defence, hp, movement)
        {

        }
        #endregion

        #region properties
        /// <summary>
        /// Gets a value indicating whether this student can attack.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this student can attack; otherwise, <c>false</c>.
        /// </value>
        /// <exception cref="System.NotImplementedException"></exception>
        public bool CanAttack
        {
            get { throw new System.NotImplementedException(); }
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
                return 8 * (Attack + Defense + Movement + HP);
            }
        }

        public override string Name
        {
            get { return "Etudiant"; }
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
