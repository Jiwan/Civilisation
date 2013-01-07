using System.Windows;
using System.Windows.Controls;
using Civilization.World.Square;
using Civilization.ClockWork.Unit;
using Civilization.ClockWork.City;

namespace Civilization.TemplateSelector
{
    /// <summary>
    /// 
    /// </summary>
    public class PickTemplateSelector : DataTemplateSelector
    {
        #region properties
        /// <summary>
        /// Gets or sets the square data template.
        /// </summary>
        /// <value>
        /// The square data template.
        /// </value>
        public DataTemplate SquareDataTemplate { get; set; }

        /// <summary>
        /// Gets or sets the unit data template.
        /// </summary>
        /// <value>
        /// The unit data template.
        /// </value>
        public DataTemplate UnitDataTemplate { get; set; }

        /// <summary>
        /// Gets or sets the city data template.
        /// </summary>
        /// <value>
        /// The city data template.
        /// </value>
        public DataTemplate CityDataTemplate { get; set; }
        #endregion

        #region methods
        /// <summary>
        /// Selects the template.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <param name="container">The container.</param>
        /// <returns></returns>
        public override DataTemplate SelectTemplate(object pick, DependencyObject container)
        {
            if (pick is Square)
            {
                return SquareDataTemplate;
            }
            else if (pick is IUnit)
            {
                return UnitDataTemplate;
            }
            else if (pick is ICity)
            {
                return CityDataTemplate;
            }
            else
            {
                return base.SelectTemplate(pick, container);
            }
        }
        #endregion
    }
}
