using System;

namespace Civilization.ClockWork
{
    [Serializable()]
    public class Civilization
    {
        #region properties
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the factory.
        /// </summary>
        /// <value>
        /// The factory.
        /// </value>
        public PrototypeCivilizationFactory Factory { get; set; }
        #endregion   

        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Civilization" /> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="factory">The factory.</param>
        public Civilization(string name, PrototypeCivilizationFactory factory)
        {
            Name = name;
            Factory = factory;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Civilization" /> class.
        /// </summary>
        public Civilization()
        {
 
        }
        #endregion
    }
}
