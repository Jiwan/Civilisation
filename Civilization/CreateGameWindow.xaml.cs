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
using Civilization.ClockWork;
using Civilization.ClockWork.City;
using Civilization.ClockWork.Unit;
using System.Xml.Serialization;
using System.IO;

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

        /// <summary>
        /// The civilizations
        /// </summary>
        private ObservableCollection<Civilization.ClockWork.Civilization> civilizations;

        private static readonly string defaultCivilizationsPath = "/Civilizations/defaults.cxml";
        #endregion

        #region constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateGameWindow" /> class.
        /// </summary>
        public CreateGameWindow()
        {
            InitializeComponent();
            InitializePlayers();
            InitializeCivilizations();
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
        /// Initializes the civilizations.
        /// </summary>
        private void InitializeCivilizations()
        {
            civilizations = new ObservableCollection<ClockWork.Civilization>();

            civilizationComboBox.ItemsSource = civilizations;
            civilizationListBox.ItemsSource = civilizations;
            // Load from a default file.

            if (System.IO.File.Exists(defaultCivilizationsPath))
            {
                LoadCivilizations(defaultCivilizationsPath);
            }
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

        /// <summary>
        /// Handles the Click event of the addCivilizationButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void addCivilizationButton_Click(object sender, RoutedEventArgs e)
        {
            var msgBox = new CivilizationMessageBox();
            
            msgBox.ShowDialog();

            var civ = new Civilization.ClockWork.Civilization(msgBox.CivilizationName, new PrototypeCivilizationFactory());

            civilizations.Add(civ);
        }

        private void removeCivilizationButton_Click(object sender, RoutedEventArgs e)
        {
            if (civilizationListBox.SelectedItem != null)
            {
                civilizations.Remove((Civilization.ClockWork.Civilization)civilizationListBox.SelectedItem);
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveFile = new Microsoft.Win32.SaveFileDialog();
            saveFile.Filter = "Civilization Xml (*.cxml)|*.cxml";

            var result = saveFile.ShowDialog();

            if (result != null)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(civilizations.GetType());

                using (StreamWriter streamWriter = System.IO.File.CreateText(saveFile.FileName))
                {
                    xmlSerializer.Serialize(streamWriter, civilizations);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFile = new Microsoft.Win32.OpenFileDialog();
            openFile.Filter = "Civilization Xml (*.cxml)|*.cxml";

            var result = openFile.ShowDialog();

            if (result != null)
            {
                LoadCivilizations(openFile.FileName);
            }
        }

        private void LoadCivilizations(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(civilizations.GetType());

            using (StreamReader streamReader = System.IO.File.OpenText(path))
            {
                civilizations = (ObservableCollection<Civilization.ClockWork.Civilization>)xmlSerializer.Deserialize(streamReader);
            }
        }
        #endregion
        #endregion
    }
}
