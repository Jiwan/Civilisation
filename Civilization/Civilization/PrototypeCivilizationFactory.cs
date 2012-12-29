using System;
using Civilization.Civilization.City;
using Civilization.Civilization.Unit;

namespace Civilization.Civilization
{
    [Serializable()]
    public class PrototypeCivilizationFactory : ICivilizationAbstractFactory
    {
        #region fields
        private ICity protoCity;
        private IDepartDirector protoDepartDirector;
        private IStudent protoStudent;
        private ITeacher protoTeacher;
        #endregion
 
        #region constructor
        public PrototypeCivilizationFactory(
            ICity protoCity,
            IDepartDirector protoDepartDirector,
            IStudent protoStudent,
            ITeacher protoTeacher)
        {

        }
        #endregion

        #region methods
        public ICity CreateCity()
        {
            return (ICity)protoCity.Clone();
        }

        public IDepartDirector CreateDepartDirector()
        {
            return (IDepartDirector)protoDepartDirector.Clone();
        }

        public IStudent CreateStudent()
        {
            return (IStudent)protoStudent.Clone();
        }

        public ITeacher CreateTeacher()
        {
            return (ITeacher)protoTeacher.Clone();
        }
        #endregion
    }
}
