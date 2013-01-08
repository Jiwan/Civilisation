
namespace Civilization.Player.Actions
{
    public interface IPlayerAction
    {
        #region methods
        /// <summary>
        /// Does the action.
        /// </summary>
        /// <returns></returns>
        bool Do();
        /// <summary>
        /// Undoes the action.
        /// </summary>
        /// <returns></returns>
        bool UnDo();
        /// <summary>
        /// Gets the log.
        /// </summary>
        /// <returns></returns>
        string GetLog();
        #endregion
    }
}
