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

        /// <summary>
        /// The camera position.
        /// </summary>
        private Point cameraPosition;

        /// <summary>
        /// The mouse position
        /// </summary>
        private Point mousePosition;

        /// <summary>
        /// The moving camera
        /// </summary>
        private bool MovingCamera;
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
            cameraPosition = new Point(0, 0);
            MovingCamera = false;
        }
        #endregion

        #region methods
        
        #region protected
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            mousePosition = e.GetPosition(this);
            MovingCamera = true;
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
            // Update camera.
            UpdateCamera(e.GetPosition(this));

            MovingCamera = false;
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (MovingCamera)
            {
                UpdateCamera(e.GetPosition(this));
            }
        }

        protected override void OnMouseLeave(MouseEventArgs e)
        {
            base.OnMouseLeave(e);
            UpdateCamera(e.GetPosition(this));

            MovingCamera = false;
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (map == null)
                return;

            // Calculer l'affichage de la map.
            int upperBoundX = (int)(cameraPosition.X / 50);
            int upperBoundY = (int)(cameraPosition.Y / 50);
            int maxX = (int)Math.Min(upperBoundX + (ActualWidth / 50), map.Size.X);
            int maxY = (int)Math.Min(upperBoundY + (ActualHeight / 50), map.Size.Y);

            for (int i = upperBoundX; i < maxX; ++i)
            {
                for (int j = upperBoundY; j < maxY; ++j)
                {
                    Size size = new Size(50, 50);
                    Point position = new Point((i * 50) - cameraPosition.X, (j * 50) - cameraPosition.Y);
                    
                    if (position.X < 0)
                    {
                        size.Width -= position.X;
                        position.X = 0;
                    }

                    if (position.Y < 0)
                    {
                        size.Height -= position.Y;
                        position.Y = 0;
                    }
                        // 50 dpi and not 50 px.
                    Rect rect = new Rect(position, size);

                    drawingContext.DrawImage(map.SquareMatrix[i, j].Tile, new Rect(position, size));
                    Pen pen = new Pen(Brushes.Black, 1);
                    drawingContext.DrawRectangle(null, pen, rect);
                }
            }
        }
        #endregion

        #region private
        private void UpdateCamera(Point newPosition)
        {
            cameraPosition.X += (mousePosition.X - newPosition.X) / 10;
            cameraPosition.Y += (mousePosition.Y - newPosition.Y) / 10;

            cameraPosition.X = Math.Max(cameraPosition.X, 0);
            cameraPosition.Y = Math.Max(cameraPosition.Y, 0);

            cameraPosition.X = Math.Min(cameraPosition.X, ActualWidth);
            cameraPosition.Y = Math.Min(cameraPosition.Y, ActualHeight);

            this.InvalidateVisual();
        }
        #endregion
        #endregion
    }
}
