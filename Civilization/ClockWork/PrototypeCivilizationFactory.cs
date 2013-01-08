using System.Windows;
using System.Xml.Serialization;
using Civilization.ClockWork.City;
using Civilization.ClockWork.Unit;
using Civilization.Utils.Serialization;

namespace Civilization.ClockWork
{
    public class PrototypeCivilizationFactory : ICivilizationAbstractFactory
    {
        #region fields
        /// <summary>
        /// The proto city
        /// </summary>
        private ICity protoCity;

        #endregion

        #region properties
        /// <summary>
        /// Gets the depart director prototype.
        /// </summary>
        /// <value>
        /// The depart director prototype.
        /// </value>
        [XmlIgnore()]
        public IDepartDirector DepartDirectorPrototype
        {
            get
            {
                return XmlDepartDirectorPrototype.Value;
            }

            set
            {
                XmlDepartDirectorPrototype.Value = value;
            }
        }

        /// <summary>
        /// Gets the student prototype.
        /// </summary>
        /// <value>
        /// The student prototype.
        /// </value>
        [XmlIgnore()]
        public IStudent StudentPrototype
        {
            get
            {
                return XmlStudentPrototype.Value;
            }

            set
            {
                XmlStudentPrototype.Value = value;
            }
        }

        /// <summary>
        /// Gets the teacher prototype.
        /// </summary>
        /// <value>
        /// The teacher prototype.
        /// </value>
        [XmlIgnore()]
        public ITeacher TeacherPrototype
        {
            get
            {
                return XmlTeacherPrototype.Value;
            }

            set
            {
                XmlTeacherPrototype.Value = value;
            }
        }


        /// <summary>
        /// The XML teacher prototype (is only use for internal purpose).
        /// </summary>
        public XmlAnything<IDepartDirector> XmlDepartDirectorPrototype;
        
        /// <summary>
        /// The XML teacher prototype (is only use for internal purpose.
        /// </summary>
        public XmlAnything<IStudent> XmlStudentPrototype;

        /// <summary>
        /// The XML teacher prototype (is only use for internal purpose).
        /// </summary>
        public XmlAnything<ITeacher> XmlTeacherPrototype;

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
            XmlDepartDirectorPrototype = new XmlAnything<IDepartDirector>(protoDepartDirector);
            XmlStudentPrototype = new XmlAnything<IStudent>(protoStudent);
            XmlTeacherPrototype = new XmlAnything<ITeacher>(protoTeacher);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PrototypeCivilizationFactory" /> class.
        /// </summary>
        public PrototypeCivilizationFactory()
        {
            this.protoCity = new BasicCity(new Point(0, 0), null, null);
            XmlDepartDirectorPrototype = new XmlAnything<IDepartDirector>(new BasicDepartDirector());
            XmlStudentPrototype = new XmlAnything<IStudent>(new BasicStudent(0, 0, 0, 0));
            XmlTeacherPrototype = new XmlAnything<ITeacher>(new BasicTeacher(0, 0, 0, 0));
        }
        #endregion

        #region methods
        #region publics
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
            return (IDepartDirector)XmlDepartDirectorPrototype.Value.Clone();
        }

        /// <summary>
        /// Creates the student.
        /// </summary>
        /// <returns></returns>
        public IStudent CreateStudent()
        {
            return (IStudent)XmlStudentPrototype.Value.Clone();
        }

        /// <summary>
        /// Creates the teacher.
        /// </summary>
        /// <returns></returns>
        public ITeacher CreateTeacher()
        {
            return (ITeacher)XmlTeacherPrototype.Value.Clone();
        }
        #endregion

        #region privates
       
        #endregion
        #endregion
    }
}
