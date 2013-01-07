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
    /// An event that fire-up when a new square has been selected.
    /// </summary>
    /// <param name="position">The position.</param>
    public delegate void SelectedSquareChangedHandler(Point position);

    public delegate void RenderMapHandler(object sender, DrawingContext drawingContext);

    /// <summary>
    /// Logique d'interaction pour MapViewer.xaml
    /// </summary>
    public partial class MapViewer : UserControl
    {
        #region enums
        public enum MouseAction
        {
            MoveView,
            PickSquare
        }
        #endregion

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
        /// The old camera position
        /// </summary>
        private Point oldCameraPosition;

        /// <summary>
        /// The mouse position
        /// </summary>
        private Point mousePosition;

        /// <summary>
        /// The moving camera
        /// </summary>
        private bool MovingCamera;

        /// <summary>
        /// The zoom
        /// </summary>
        private double zoom;

        /// <summary>
        /// The current mouse action
        /// </summary>
        private MouseAction currentMouseAction;

        private bool enableIdealLocation;
        #endregion

        #region properties

        public static readonly DependencyProperty PickedSquareProperty = DependencyProperty.Register("PickedSquare", typeof(Point), typeof(MapViewer));

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

        /// <summary>
        /// Gets or sets the current mouse action.
        /// </summary>
        /// <value>
        /// The current mouse action.
        /// </value>
        public MouseAction CurrentMouseAction
        {
            get
            {
                return currentMouseAction;
            }
            set
            {
                if (value == MouseAction.MoveView)
                {
                    this.Cursor = Cursors.Hand;
                }
                else
                {
                    this.Cursor = Cursors.Arrow;
                }
                currentMouseAction = value;
            }
        }

        /// <summary>
        /// Gets or sets the picked square.
        /// </summary>
        /// <value>
        /// The picked square.
        /// </value>
        public Point PickedSquare
        {
            get
            {
                return (Point)GetValue(PickedSquareProperty);
            }

            set
            {
                SetValue(PickedSquareProperty, value);
            }
        }

        /// <summary>
        /// Occurs when [selected square changed].
        /// </summary>
        public event SelectedSquareChangedHandler SelectedSquareChanged;

        public event RenderMapHandler RenderMap;

        public bool EnableIdealLocation 
        {
            get
            {
                return enableIdealLocation;
            }
            
            set
            {
                enableIdealLocation = value;
                Redraw();
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
            zoom = 50;
            CurrentMouseAction = MouseAction.MoveView;
            enableIdealLocation = true;
        }
        #endregion

        #region methods

        #region public
        /// <summary>
        /// Gets the rectangle according to square indexes et current camera.
        /// </summary>
        /// <param name="posX">The index X of the square.</param>
        /// <param name="posY">The index Y of the square.</param>
        /// <returns></returns>
        public Rect GetRectangle(int posX, int posY)
        {
            Size size = new Size(zoom, zoom);
            Point position = new Point((posX * zoom) - cameraPosition.X, (posY * zoom) - cameraPosition.Y);

            if (position.X < 0)
            {
                size.Width += position.X;
                position.X = 0;
            }

            if (position.Y < 0)
            {
                size.Height += position.Y;
                position.Y = 0;
            }

            if ((position.X + zoom) > ActualWidth)
            {
                size.Width = ActualWidth - position.X;
            }

            if ((position.Y + zoom) > ActualHeight)
            {
                size.Height = ActualHeight - position.Y;
            }

            return new Rect(position, size);
        }

        /// <summary>
        /// Check wether the square at position (position) is viewed by the camera.
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public bool IsInView(Point position)
        {
            int upperBoundX = (int)(cameraPosition.X / zoom);
            int upperBoundY = (int)(cameraPosition.Y / zoom);
            int maxX = (int)Math.Ceiling(Math.Min(upperBoundX + (ActualWidth / zoom), map.Size.X));
            int maxY = (int)Math.Ceiling(Math.Min(upperBoundY + (ActualHeight / zoom), map.Size.Y));

            return position.X >= upperBoundX && position.X < maxX && position.Y >= upperBoundY && position.Y < maxY;
        }

        public void Redraw()
        {
            this.InvalidateVisual();
        }
        #endregion

        #region protected
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            if (currentMouseAction == MouseAction.MoveView)
            {
                oldCameraPosition = cameraPosition;
                mousePosition = e.GetPosition(this);
                this.Cursor = Cursors.SizeAll;
                MovingCamera = true;
            }
            else
            {
                Point pickPosition = e.GetPosition(this);
                PickedSquare = new Point
                    {
                        X = Math.Floor(((pickPosition.X + cameraPosition.X) / 50)),
                        Y = Math.Floor(((pickPosition.Y + cameraPosition.Y) / 50))
                    };

                this.InvalidateVisual();

                if (SelectedSquareChanged != null)
                    SelectedSquareChanged((Point)PickedSquare);
            }
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
            if (currentMouseAction == MouseAction.MoveView)
            {
                UpdateCamera(e.GetPosition(this));
                MovingCamera = false;
                this.Cursor = Cursors.Hand;
            }
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

            if (currentMouseAction == MouseAction.MoveView)
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    UpdateCamera(e.GetPosition(this));
                    MovingCamera = false;
                    this.Cursor = Cursors.Hand;
                }
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (map == null)
                return;

            // Calculer l'affichage de la map.
            int upperBoundX = (int)(cameraPosition.X / zoom);
            int upperBoundY = (int)(cameraPosition.Y / zoom);
            int maxX = (int)Math.Ceiling(Math.Min(upperBoundX + (ActualWidth / zoom), map.Size.X));
            int maxY = (int)Math.Ceiling(Math.Min(upperBoundY + (ActualHeight / zoom), map.Size.Y));

            for (int i = upperBoundX; i < maxX; ++i)
            {
                for (int j = upperBoundY; j < maxY; ++j)
                {
                    Rect rect = GetRectangle(i, j);

                    drawingContext.DrawImage(map.SquareMatrix[i, j].Tile, rect);
                    Pen pen = new Pen(Brushes.Black, 1);
                    drawingContext.DrawRectangle(null, pen, rect);

                    if (map.SquareMatrix[i, j].TileDecorator != null)
                    {
                        rect.Width /= 2;
                        rect.Height /= 2;
                        drawingContext.DrawImage(map.SquareMatrix[i, j].TileDecorator, rect);
                    }
                }
            }

            if (RenderMap != null)
            {
                RenderMap(this, drawingContext);
            }

            if (PickedSquare != null)
            {
                if (IsInView(PickedSquare))
                {
                    DrawPickedSquare(drawingContext);
                }
            }

            if (EnableIdealLocation)
            {
                if (IsInView(map.IdealPosition1))
                {
                    DrawIdealLocation(drawingContext, map.IdealPosition1);
                }
                if (IsInView(map.IdealPosition2))
                {
                    DrawIdealLocation(drawingContext, map.IdealPosition2);
                }
                if (IsInView(map.IdealPosition3))
                {
                    DrawIdealLocation(drawingContext, map.IdealPosition3);
                }
            }


        }
        #endregion

        #region private
        /// <summary>
        /// Updates the camera.
        /// </summary>
        /// <param name="newPosition">The new position.</param>
        private void UpdateCamera(Point newPosition)
        {
            bool update = false;

            if ((map.Size.X * zoom) > ActualWidth)
            {
                cameraPosition.X = oldCameraPosition.X + (mousePosition.X - newPosition.X);
                cameraPosition.X = Math.Max(cameraPosition.X, 0);
                cameraPosition.X = Math.Min(cameraPosition.X, (map.Size.X * zoom) - ActualWidth);
                update = true;
            }

            if ((map.Size.Y * zoom) > ActualHeight)
            {
                cameraPosition.Y = oldCameraPosition.Y + (mousePosition.Y - newPosition.Y);
                cameraPosition.Y = Math.Max(cameraPosition.Y, 0);
                cameraPosition.Y = Math.Min(cameraPosition.Y, (map.Size.Y * zoom) - ActualHeight);
                update = true;
            }

            if (update)
                Redraw();
        }

        private void DrawPickedSquare(DrawingContext drawingContext)
        {
            Rect rect = GetRectangle((int)PickedSquare.X, (int)PickedSquare.Y);
            SolidColorBrush myBrush = new SolidColorBrush(Colors.Blue);
            myBrush.Opacity = 0.2;
            drawingContext.DrawRectangle(myBrush, null, rect);
        }

        private void DrawIdealLocation(DrawingContext drawingContext, Point pos)
        {
            Rect rect = GetRectangle((int)pos.X, (int)pos.Y);
            SolidColorBrush myBrush = new SolidColorBrush(Colors.Green);
            myBrush.Opacity = 0.5;
            drawingContext.DrawRectangle(myBrush, null, rect);
        }
        #endregion
        #endregion
    }
}
