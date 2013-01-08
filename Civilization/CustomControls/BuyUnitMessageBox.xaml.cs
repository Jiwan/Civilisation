using System.Windows;
using System.Windows.Controls;

namespace Civilization.CustomControls
{
    /// <summary>
    /// Logique d'interaction pour BuyUnitMessageBox.xaml
    /// </summary>
    public partial class BuyUnitMessageBox : Window
    {
        #region properties
        /// <summary>
        /// Gets or sets the type of the selected unit.
        /// </summary>
        /// <value>
        /// The type of the selected unit.
        /// </value>
        public string SelectedUnitType
        {
            get
            {
                return (string)((ComboBoxItem)unitTypeComboBox.SelectedValue).Content;
            }
        }
        #endregion

        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BuyUnitMessageBox" /> class.
        /// </summary>
        public BuyUnitMessageBox()
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

        /// <summary>
        /// Handles the Click event of the cancelButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
        #endregion
    }
}
