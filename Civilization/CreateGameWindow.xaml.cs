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

using Civilization.Player;

namespace Civilization
{
    /// <summary>
    /// Logique d'interaction pour CreateGameWindow.xaml
    /// </summary>
    public partial class CreateGameWindow : Window
    {
        #region fields
        private List<IPlayer> players;
        #endregion

        #region constructor
        public CreateGameWindow()
        {
            InitializeComponent();
            InitializePlayers();
        }
        #endregion

        #region methods
        #region private
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void InitializePlayers()
        {
            players = new List<IPlayer>();
            players.Add(new HumanPlayer("Joueur 1", Colors.Blue));
            players.Add(new AIPlayer("Joueur 2", Colors.Red));

            playerListBox.ItemsSource = players;
        }
        #endregion
        #endregion
    }
}
