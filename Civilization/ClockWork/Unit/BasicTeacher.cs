using System;
using System.Windows;
using Civilization.World.Map;
using Civilization.Player;
using System.Windows.Media.Imaging;
using Civilization.Utils.Drawing;

namespace Civilization.ClockWork.Unit
{
    public class BasicTeacher : Unit, ITeacher
    {
        #region Fields
        private IPlayer player;

        /// <summary>
        /// The tile
        /// </summary>
        private static readonly BitmapImage tile = TileFlyWeight.Instance.GetBitmapImage(new Uri(@"pack://application:,,,/Images/sprite_teacher.png", UriKind.Absolute));
        #endregion

        #region properties
        public override int Cost
        {
            get
            {
                return 12 * (Attack + Defense + Movement + HP);
            }
        }

        public override string Name
        {
            get { return "Enseignant"; }
        }
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
        public BasicTeacher()
            : base(0, 1, 1, 3)
        {

        }

        public BasicTeacher(IPlayer player) : base(0, 1, 1, 3)
        {
            this.player = player;
        }

        public BasicTeacher(IPlayer player, int attack, int defence, int hp, int movement) 
            : base(attack, defence, hp, movement)
        {
            this.player = player;
        }
        #endregion

        #region methods
        public City.ICity CreateCity(Point constructionPoint, Map map)
        {
            return new City.BasicCity(constructionPoint, map, player);
        }

        public object Clone()
        {
            return (object)this.MemberwiseClone();
        }
        #endregion
    }
}
