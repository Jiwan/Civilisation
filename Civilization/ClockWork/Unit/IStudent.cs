
namespace Civilization.ClockWork.Unit
{
    public interface IStudent : IUnit
    {
        #region properties
        /// <summary>
        /// Gets a value indicating whether this student can attack.
        /// </summary>
        /// <value>
        /// <c>true</c> if this student can attack; otherwise, <c>false</c>.
        /// </value>
        bool CanAttack { get; }
        #endregion
    }
}
