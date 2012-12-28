using System.Windows.Controls;
using System.Windows;
using CivilizationAlgorithms;

namespace Civilization
{
    class PropertyDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DefaultDataTemplate { get; set; }
        public DataTemplate MountainDataTemplate { get; set; }
        public DataTemplate FieldDataTemplate { get; set; }
        public DataTemplate DesertDataTemplate { get; set; }
        public DataTemplate WaterDataTemplate { get; set; }

        public override DataTemplate SelectTemplate(ManagedTileType item, DependencyObject container)
        {
            if (item == ManagedTileType.Mountain)
            {
                return MountainDataTemplate;
            }
            else if (item == ManagedTileType.Field)
            {
                return FieldDataTemplate;
            }
            else if (item == ManagedTileType.Desert)
            {
                return DesertDataTemplate;
            }
            else if (item == ManagedTileType.Water)
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