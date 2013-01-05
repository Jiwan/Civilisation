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
                this.InvalidateVisual();
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
        
        #region protected
        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (map == null)
                return;

            for (int i = 0; i < map.Size.X; ++i)
            {
                for (int j = 0; j < map.Size.Y; ++j)
                {
                    Point position = new Point(i * (this.ActualWidth / map.Size.X), j * (this.ActualHeight / map.Size.Y));
                    Size size = new Size(this.ActualWidth / map.Size.X, this.ActualHeight / map.Size.Y);

                    drawingContext.DrawImage(map.SquareMatrix[i, j].Tile, new Rect(position, size));              
                }
            }
        }
        #endregion

        #region private
        #endregion
        #endregion
    }
}
