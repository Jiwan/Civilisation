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
        public PlayerChoice PlayerChoiceResult 
        { 
            get 
            { 
                return playerChoice; 
            } 
        }
        #endregion

        #region PlayerMessageBox
        public PlayerMessageBox()
        {
            InitializeComponent();
        }
        #endregion

        #region methods
        #region privates
        private void addHumanButton_Click(object sender, RoutedEventArgs e)
        {
            playerChoice = PlayerChoice.Human; 
            DialogResult = true;
        }

        private void addAiButton_Click(object sender, RoutedEventArgs e)
        {
            playerChoice = PlayerChoice.Ai;
            DialogResult = true;
        }
        #endregion
        #endregion
    }
}
