using System.Windows.Controls;
using System.Windows;
using CivilizationAlgorithms;
using Civilization.World.Square;

namespace Civilization
{
    class PropertyDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultDataTemplate { get; set; }
        public DataTemplate MountainDataTemplate { get; set; }
        public DataTemplate FieldDataTemplate { get; set; }
        public DataTemplate DesertDataTemplate { get; set; }
        public DataTemplate WaterDataTemplate { get; set; }

        public override DataTemplate SelectTemplate(Square tile, DependencyObject container)
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
                return DefaultDataTemplate;
            }
        }
    }
}