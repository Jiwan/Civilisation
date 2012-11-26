using Civilization.Civilization.City;
using Civilization.Civilization.Unit;

namespace Civilization.Civilization
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
