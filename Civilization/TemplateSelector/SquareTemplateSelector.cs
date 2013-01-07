using System.Windows.Controls;
using System.Windows;
using CivilizationAlgorithms;
using Civilization.World.Square;

namespace Civilization.TemplateSelector
{
    public class SquareTemplateSelector : DataTemplateSelector
    {
        #region properties
        /// <summary>
        /// Gets or sets the mountain data template.
        /// </summary>
        /// <value>
        /// The mountain data template.
        /// </value>
        public DataTemplate MountainDataTemplate { get; set; }

        /// <summary>
        /// Gets or sets the field data template.
        /// </summary>
        /// <value>
        /// The field data template.
        /// </value>
        public DataTemplate FieldDataTemplate { get; set; }

        /// <summary>
        /// Gets or sets the desert data template.
        /// </summary>
        /// <value>
        /// The desert data template.
        /// </value>
        public DataTemplate DesertDataTemplate { get; set; }

        /// <summary>
        /// Gets or sets the water data template.
        /// </summary>
        /// <value>
        /// The water data template.
        /// </value>
        public DataTemplate WaterDataTemplate { get; set; }
        #endregion

        #region methods
        /// <summary>
        /// Selects the template.
        /// </summary>
        /// <param name="tile">The tile.</param>
        /// <param name="container">The container.</param>
        /// <returns></returns>
        public override DataTemplate SelectTemplate(object tile, DependencyObject container)
        {
            if (tile is Mountain)
            {
                return MountainDataTemplate;
            }
            else if (tile is Field)
            {
                return FieldDataTemplate;
            }
            else if (tile is Desert)
            {
                return DesertDataTemplate;
            }
            else if (tile is Water)
            {
                return WaterDataTemplate;
            }
            else
            {
                return base.SelectTemplate(tile, container);
            }
        }
        #endregion
    }
}