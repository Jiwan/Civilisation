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

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            ManagedTileType tile = CivilizationAlgorithms.PerlinNoise.GetTileType(0, 0);
            if (tile == ManagedTileType.Mountain)
            {
                return MountainDataTemplate;
            }
            else if (tile == ManagedTileType.Field)
            {
                return FieldDataTemplate;
            }
            else if (tile == ManagedTileType.Desert)
            {
                return DesertDataTemplate;
            }
            else if (tile == ManagedTileType.Water)
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
