using System.Windows.Controls;
using System.Windows;
using Civilization.Player;

namespace Civilization.TemplateSelector
{
    class PlayerTemplateSelector : DataTemplateSelector
    {
        public DataTemplate HumanDataTemplate { get; set; }
        public DataTemplate AIDataTemplate { get; set; }    

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
    }
}