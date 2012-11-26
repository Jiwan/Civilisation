
namespace Civilization.Civilization
{
    public interface ICivilizationAbstractFactory
    {
        #region methods
        public ICity CreateCity();

        public IDepartDirector CreateDepartDirector();

        public IStudent CreateStudent();

        public ITeacher CreateTeacher();
        #endregion
    }
}
