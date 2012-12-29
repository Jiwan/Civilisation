using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace Civilization
{
    class DynamicGrid
    {
        private Grid DynamicGrid;

        public DynamicGrid()
        {
            DynamicGrid = new Grid();
            DynamicGrid.Width = 490;
            DynamicGrid.HorizontalAlignment = HorizontalAlignment.Left;
            DynamicGrid.VerticalAlignment = VerticalAlignment.Top;
            DynamicGrid.ShowGridLines = true;
            DynamicGrid.Background = new SolidColorBrush(Colors.White);
        }

        public void addRow()
        {
            RowDefinition gridRow1 = new RowDefinition();
            gridRow1.Height = new GridLength(50);
            DynamicGrid.RowDefinitions.Add(gridRow1);
        }

        public void addColomn()
        {
            DynamicGrid.ColumnDefinitions.Add(new ColumnDefinition());
        }

        public void addTile(CivilizationAlgorithms.ManagedTileType managedTileType)
        {
            throw new NotImplementedException();
        }

        public void loadGrid()
        {
            MainWindow.Content = DynamicGrid;
        }
    }
}
