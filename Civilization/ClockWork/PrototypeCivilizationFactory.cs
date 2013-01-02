using System;
using Civilization.ClockWork.City;
using Civilization.ClockWork.Unit;
using System.Drawing;

namespace Civilization.ClockWork
{
    [Serializable()]
    public class PrototypeCivilizationFactory : ICivilizationAbstractFactory
    {
        #region fields
        /// <summary>
        /// The proto city
        /// </summary>
        private ICity protoCity;

        /// <summary>
        /// The proto depart director
        /// </summary>
        private IDepartDirector protoDepartDirector;

        /// <summary>
        /// The proto student
        /// </summary>
        private IStudent protoStudent;

        /// <summary>
        /// The proto teacher
        /// </summary>
        private ITeacher protoTeacher;
        #endregion

        #region properties
        /// <summary>
        /// Gets the depart director prototype.
        /// </summary>
        /// <value>
        /// The depart director prototype.
        /// </value>
        public IDepartDirector DepartDirectorPrototype
        {
            get
            {
                return protoDepartDirector;
            }
        }

        /// <summary>
        /// Gets the student prototype.
        /// </summary>
        /// <value>
        /// The student prototype.
        /// </value>
        public IStudent StudentPrototype
        {
            get
            {
                return protoStudent;
            }
        }

        /// <summary>
        /// Gets the teacher prototype.
        /// </summary>
        /// <value>
        /// The teacher prototype.
        /// </value>
        public ITeacher TeacherPrototype
        {
            get
            {
                return protoTeacher;
            }
        }
        #endregion

        #region constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PrototypeCivilizationFactory" /> class.
        /// </summary>
        /// <param name="protoCity">The proto city.</param>
        /// <param name="protoDepartDirector">The proto depart director.</param>
        /// <param name="protoStudent">The proto student.</param>
        /// <param name="protoTeacher">The proto teacher.</param>
        public PrototypeCivilizationFactory(
            ICity protoCity,
            IDepartDirector protoDepartDirector,
            IStudent protoStudent,
            ITeacher protoTeacher)
        {
            this.protoCity = protoCity;
            this.protoDepartDirector = protoDepartDirector;
            this.protoStudent = protoStudent;
            this.protoTeacher = protoTeacher;
        }

        public PrototypeCivilizationFactory()
        {
            this.protoCity = new BasicCity(new Point(0, 0));
            this.protoDepartDirector = new BasicDepartDirector();
            this.protoStudent = new BasicStudent(0, 0, 0, 0, 0);
            this.protoTeacher = new BasicTeacher(0, 0, 0, 0, 0);
        }
        #endregion

        #region methods
        /// <summary>
        /// Creates the city.
        /// </summary>
        /// <returns></returns>
        public ICity CreateCity()
        {
            return (ICity)protoCity.Clone();
        }

        /// <summary>
        /// Creates the depart director.
        /// </summary>
        /// <returns></returns>
        public IDepartDirector CreateDepartDirector()
        {
            return (IDepartDirector)protoDepartDirector.Clone();
        }

        /// <summary>
        /// Creates the student.
        /// </summary>
        /// <returns></returns>
        public IStudent CreateStudent()
        {
            return (IStudent)protoStudent.Clone();
        }

        /// <summary>
        /// Creates the teacher.
        /// </summary>
        /// <returns></returns>
        public ITeacher CreateTeacher()
        {
            return (ITeacher)protoTeacher.Clone();
        }
        #endregion
    }
}
