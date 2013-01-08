using Civilization.ClockWork.City;
using Civilization.ClockWork.Unit;

namespace Civilization.ClockWork
{
    public interface ICivilizationAbstractFactory
    {
        #region methods
        /// <summary>
        /// Creates the city.
        /// </summary>
        /// <returns></returns>
        ICity CreateCity();

        /// <summary>
        /// Creates the depart director.
        /// </summary>
        /// <returns></returns>
        IDepartDirector CreateDepartDirector();

        /// <summary>
        /// Creates the student.
        /// </summary>
        /// <returns></returns>
        IStudent CreateStudent();

        /// <summary>
        /// Creates the teacher.
        /// </summary>
        /// <returns></returns>
        ITeacher CreateTeacher();
        #endregion
    }
}
