﻿using Civilization.Civilization.Unit;

namespace Civilization.Player.Actions
{
    public class SelectUnitAction : IPlayerAction
    {
        #region properties
        public IUnit SelectedUnit { get; set; }
        #endregion

        #region methods
        public override bool Do()
        {
            throw new System.NotImplementedException();
        }

        public override bool UnDo()
        {
            throw new System.NotImplementedException();
        }

        public override string GetLog()
        {
            throw new System.NotImplementedException();
        }
        #endregion
    }
}