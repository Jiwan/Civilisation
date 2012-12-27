
namespace Civilization.Player.Actions
{
    public interface IPlayerAction
    {
        #region methods
        bool Do();
        bool UnDo();
        string GetLog();
        #endregion
    }
}
