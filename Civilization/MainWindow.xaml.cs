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
using Civilization.World.Square;
using Civilization.Utils.Logs;

namespace Civilization
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region fields
        /// <summary>
        /// The window
        /// </summary>
        CreateGameWindow window;
        #endregion
        
        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Log.Instance.WriteFunction = WriteLog;

        }
        #endregion

        #region methods
        /// <summary>
        /// Handles the Click event of the closeMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void closeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Handles the Click event of the createMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void createMenuItem_Click(object sender, RoutedEventArgs e)
        {
            window = new CreateGameWindow();
            var result = window.ShowDialog();

            if (result.HasValue && result.Value)
            {
                mapViewer.Map = window.CreatedMap;

                Log.Instance.Write("Chargement de la carte...");
                Log.Instance.Write("Chargement des joueurs...");
                Log.Instance.Write("Début de la partie.");
            }
        }

        /// <summary>
        /// Handles the Click event of the aboutMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void aboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(@"Ce projet a été crée par J.Guegant et R.Lagrange dans le cadre d'un projet de 4ème à l'Institut National des Sciences Appliquées de Rennes.
Pour plus d'informations, se référer au manuel utilisateur.");
        }

        /// <summary>
        /// Handles the Click event of the arrowButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void arrowButton_Click(object sender, RoutedEventArgs e)
        {
            mapViewer.CurrentMouseAction = CustomControls.MapViewer.MouseAction.PickSquare;
        }

        /// <summary>
        /// Handles the Click event of the handButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void handButton_Click(object sender, RoutedEventArgs e)
        {
            mapViewer.CurrentMouseAction = CustomControls.MapViewer.MouseAction.MoveView;
        }

        /// <summary>
        /// Maps the viewer_ selected square changed.
        /// </summary>
        /// <param name="position">The position.</param>
        private void mapViewer_SelectedSquareChanged(Point position)
        {
            //!TODO : Mettre a jour les infos sur la case.
            squarePositionStackPanel.DataContext = mapViewer;
        }

        /// <summary>
        /// Writes the log.
        /// </summary>
        /// <param name="info">The info you want to write.</param>
        private void WriteLog(string info)
        {
            logTextBlock.Text += info + "\n";
        }
        #endregion
    }
}
