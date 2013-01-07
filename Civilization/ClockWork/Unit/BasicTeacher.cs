using System;
using System.Windows;
using Civilization.World.Map;
using Civilization.Player;

namespace Civilization.ClockWork.Unit
{
    public class BasicTeacher : Unit, ITeacher
    {
        #region Fields
        private IPlayer player;
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

        #region constructors
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
