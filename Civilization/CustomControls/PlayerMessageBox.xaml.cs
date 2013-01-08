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

namespace Civilization.CustomControls
{
    /// <summary>
    /// Logique d'interaction pour PlayerMessageBox.xaml
    /// </summary>
    public partial class PlayerMessageBox : Window
    {
        #region fields
        /// <summary>
        /// The player choice
        /// </summary>
        private PlayerChoice playerChoice;
        #endregion

        #region enumeration
        public enum PlayerChoice
        {
            Human,
            Ai,
        }
        #endregion

        #region properties
        /// <summary>
        /// Gets the player choice result.
        /// </summary>
        /// <value>
        /// The player choice result.
        /// </value>
        public PlayerChoice PlayerChoiceResult 
        { 
            get 
            { 
                return playerChoice; 
            } 
        }
        #endregion

        #region PlayerMessageBox
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerMessageBox" /> class.
        /// </summary>
        public PlayerMessageBox()
        {
            InitializeComponent();
        }
        #endregion

        #region methods
        #region privates
        /// <summary>
        /// Handles the Click event of the addHumanButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void addHumanButton_Click(object sender, RoutedEventArgs e)
        {
            playerChoice = PlayerChoice.Human; 
            DialogResult = true;
        }

        /// <summary>
        /// Handles the Click event of the addAiButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void addAiButton_Click(object sender, RoutedEventArgs e)
        {
            playerChoice = PlayerChoice.Ai;
            DialogResult = true;
        }
        #endregion
        #endregion
    }
}
