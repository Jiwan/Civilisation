﻿using System;
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
    public delegate void SelectedSquareChangedHandler(Point position);
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

        private double zoom;
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

        public MouseAction CurrentMouseAction
        {
            get;
            set;
        }

        /// <summary>
        /// Occurs when [selected square changed].
        /// </summary>
        public event SelectedSquareChangedHandler SelectedSquareChanged;
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
        }
        #endregion

        #region methods
        
        #region protected
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            if (CurrentMouseAction == MouseAction.MoveView)
            {
                oldCameraPosition = cameraPosition;
                mousePosition = e.GetPosition(this);
                MovingCamera = true;
            }
            else
            {
                 // Throw an event.
            }
        }

        protected override void OnMouseLeftButtonUp(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonUp(e);
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
            
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                UpdateCamera(e.GetPosition(this));
                MovingCamera = false;
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
                    Size size = new Size(zoom, zoom);
                    Point position = new Point((i * zoom) - cameraPosition.X, (j * zoom) - cameraPosition.Y);
                    
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

                    if ((position.X + zoom) > ActualWidth)
                    {
                        size.Width = ActualWidth - position.X;
                    }

                    if ((position.Y + zoom) > ActualHeight)
                    {
                        size.Height = ActualHeight - position.Y;
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
                this.InvalidateVisual();
        }
        #endregion
        #endregion
    }
}
