using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Civilization.World.Map;

namespace Civilization.CustomControls
{
    /// <summary>
    /// Logique d'interaction pour MapViewer.xaml
    /// </summary>
    public partial class MapViewer : UserControl
    {
        #region fields
        /// <summary>
        /// The map we want to draw.
        /// </summary>
        private Map map;
        #endregion

        #region properties
        /// <summary>
        /// Gets or sets the map we want to draw.
        /// </summary>
        /// <value>
        /// The map.
        /// </value>
        public Map Map
        {
            get
            {
                return map;
            }
            set
            {
                map = value;
                UpdateMapView();
            }
        }
        #endregion

        #region constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="MapViewer" /> class.
        /// </summary>
        public MapViewer()
        {
            InitializeComponent();
        }
        #endregion

        #region methods
        #region private
        /// <summary>
        /// Updates the map view.
        /// </summary>
        private void UpdateMapView()
        {
            mainGrid.Children.Clear();
            mainGrid.RowDefinitions.Clear();
            mainGrid.ColumnDefinitions.Clear();

            for (int i = 0; i < map.Size.X; ++i)
            {
                RowDefinition rowdef = new RowDefinition();
                rowdef.Height = new GridLength(mainGrid.ActualHeight / map.Size.X);
                mainGrid.RowDefinitions.Add(rowdef);
            }

            for (int i = 0; i < map.Size.Y; ++i)
            {
                ColumnDefinition columndef = new ColumnDefinition();
                columndef.Width = new GridLength(mainGrid.ActualWidth / map.Size.Y);
                mainGrid.ColumnDefinitions.Add(columndef);
            }

            for (int i = 0; i < map.Size.X; ++i)
            {
                for (int j = 0; j < map.Size.Y; ++j)
                {
                    Image square = new Image();
                    square.Source = new BitmapImage(map.SquareMatrix[i, j].Tile);
                    
                    mainGrid.Children.Add(square);
                    
                    Grid.SetRow(square, j);
                    Grid.SetColumn(square, i);
                }
            }
        }
        #endregion
        #endregion
    }
}
