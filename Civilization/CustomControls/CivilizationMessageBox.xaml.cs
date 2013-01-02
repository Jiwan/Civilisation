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
    /// Logique d'interaction pour CivilizationMessageBox.xaml
    /// </summary>
    public partial class CivilizationMessageBox : Window
    {
        #region properties
        /// <summary>
        /// Gets the name of the civilization.
        /// </summary>
        /// <value>
        /// The name of the civilization.
        /// </value>
        public string CivilizationName
        {
            get
            {
                return nameTextBox.Text;
            }
        }
        #endregion

        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="CivilizationMessageBox" /> class.
        /// </summary>
        public CivilizationMessageBox()
        {
            InitializeComponent();
        }
        #endregion

        #region methods
        /// <summary>
        /// Handles the Click event of the okButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }
        #endregion
    }
}
