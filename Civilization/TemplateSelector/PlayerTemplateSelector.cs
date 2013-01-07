
using System.Windows.Controls;
using System.Windows;
using Civilization.Player;

namespace Civilization.TemplateSelector
{
    /// <summary>
    /// 
    /// </summary>
    public class PlayerTemplateSelector : DataTemplateSelector
    {
        #region properties
        /// <summary>
        /// Gets or sets the human data template.
        /// </summary>
        /// <value>
        /// The human data template.
        /// </value>
        public DataTemplate HumanDataTemplate { get; set; }

        /// <summary>
        /// Gets or sets the AI data template.
        /// </summary>
        /// <value>
        /// The AI data template.
        /// </value>
        public DataTemplate AIDataTemplate { get; set; }
        #endregion

        #region methods
        /// <summary>
        /// Selects the template.
        /// </summary>
        /// <param name="player">The player.</param>
        /// <param name="container">The container.</param>
        /// <returns></returns>
        public override DataTemplate SelectTemplate(object player, DependencyObject container)
        {
            if (player is HumanPlayer)
            {
                return HumanDataTemplate;
            }
            else if (player is AIPlayer)
            {
                return AIDataTemplate;
            }            
            else
            {
                return base.SelectTemplate(player, container);
            }
        }
        #endregion
    }
}