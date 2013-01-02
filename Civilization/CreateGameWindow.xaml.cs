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
using System.Windows.Shapes;
using System.Collections.ObjectModel;

using Civilization.Player;
using Civilization.World.Map;
using Civilization.CustomControls;

namespace Civilization
{
    /// <summary>
    /// Logique d'interaction pour CreateGameWindow.xaml
    /// </summary>
    public partial class CreateGameWindow : Window
    {
        #region fields
        /// <summary>
        /// The players
        /// </summary>
        private ObservableCollection<IPlayer> players;
        #endregion

        #region constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateGameWindow" /> class.
        /// </summary>
        public CreateGameWindow()
        {
            InitializeComponent();
            InitializePlayers();
        }
        #endregion

        #region methods
        #region private
        /// <summary>
        /// Handles the Click event of the cancelButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        /// <summary>
        /// Initializes the players.
        /// </summary>
        private void InitializePlayers()
        {
            players = new ObservableCollection<IPlayer>();
            players.Add(new HumanPlayer("Joueur 1", Colors.Blue));
            players.Add(new AIPlayer("Joueur 2", Colors.Red));

            playerListBox.ItemsSource = players;
        }

        /// <summary>
        /// Handles the Click event of the playerListBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void playerListBox_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button)
            {
                
            }
        }

        /// <summary>
        /// Handles the SelectionChanged event of the tabControlOption control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs" /> instance containing the event data.</param>
        private void tabControlOption_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        /// <summary>
        /// Handles the SelectionChanged event of the playerListBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs" /> instance containing the event data.</param>
        private void playerListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Avoid the event to bubbling.
            e.Handled = true;
        }

        /// <summary>
        /// Handles the Loaded event of the ColorPicker control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void ColorPicker_Loaded(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
        }

        /// <summary>
        /// Handles the SelectionChanged event of the civilizationComboBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs" /> instance containing the event data.</param>
        private void civilizationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            e.Handled = true;
        }

        /// <summary>
        /// Handles the CanExecute event of the CommandBinding control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="CanExecuteRoutedEventArgs" /> instance containing the event data.</param>
        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            Control target = e.Source as Control;

            if (target != null)
            {
                e.CanExecute = true;
            }
            else
            {
                e.CanExecute = false;
            }
        }

        /// <summary>
        /// Handles the Executed event of the CommandBinding control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ExecutedRoutedEventArgs" /> instance containing the event data.</param>
        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            ListBox listBox = (ListBox)sender;
            bool result = players.Remove((IPlayer)((Button)e.OriginalSource).DataContext);

            e.Handled = true;
        }

        /// <summary>
        /// Handles the Click event of the GenerateButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void GenerateButton_Click(object sender, RoutedEventArgs e)
        {
            mapViewer.Map = SmallMap.Instance.CreateMap(null);
        }

        /// <summary>
        /// Handles the Click event of the addPlayerButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void addPlayerButton_Click(object sender, RoutedEventArgs e)
        {
            PlayerMessageBox msgBox = new PlayerMessageBox();

            msgBox.ShowDialog();

            if (msgBox.PlayerChoiceResult == PlayerMessageBox.PlayerChoice.Human)
            {
                players.Add(new HumanPlayer("Nouveau joueur", Colors.Green));
            }
            else
            {
                players.Add(new AIPlayer("Nouveau joueur", Colors.Green));
            }

        }
        #endregion
        #endregion
    }
}
