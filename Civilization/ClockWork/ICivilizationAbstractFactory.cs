using Civilization.ClockWork.City;
using Civilization.ClockWork.Unit;

namespace Civilization.ClockWork
{
    public interface ICivilizationAbstractFactory
    {
        #region methods
        ICity CreateCity();

        IDepartDirector CreateDepartDirector();

        IStudent CreateStudent();

        ITeacher CreateTeacher();
        #endregion
    }
}
