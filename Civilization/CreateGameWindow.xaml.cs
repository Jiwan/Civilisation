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

using CivilizationAlgorithms;

namespace Civilization
{
    /// <summary>
    /// Logique d'interaction pour CreateGameWindow.xaml
    /// </summary>
    public partial class CreateGameWindow : Window
    {
        #region fields
        /// <summary>
        /// The max points for the current unit.
        /// </summary>
        private double maxPoints;

        /// <summary>
        /// The players.
        /// </summary>
        private ObservableCollection<IPlayer> players;

        /// <summary>
        /// The civilizations.
        /// </summary>
        private ObservableCollection<Civilization.ClockWork.Civilization> civilizations;

        /// <summary>
        /// The default civilizations file path.
        /// </summary>
        private static readonly string defaultCivilizationsPath = "/Civilizations/defaults.cxml";

        /// <summary>
        /// The selected unit property.
        /// </summary>
        public static readonly DependencyProperty SelectedUnitProperty = DependencyProperty.Register("SelectedUnit", typeof(IUnit), typeof(CreateGameWindow));

        public static readonly DependencyProperty RemainingPointsProperty = DependencyProperty.Register(
            "RemainingPoints", 
            typeof(double), 
            typeof(CreateGameWindow),
            new PropertyMetadata(0.0, OnRemainingPointChanged));

        /// <summary>
        /// The attack max point property
        /// </summary>
        public static readonly DependencyProperty AttackMaxPointProperty = DependencyProperty.Register("AttackMaxPoint", typeof(double), typeof(CreateGameWindow));

        /// <summary>
        /// The defence max point property
        /// </summary>
        public static readonly DependencyProperty DefenceMaxPointProperty = DependencyProperty.Register("DefenceMaxPoint", typeof(double), typeof(CreateGameWindow));

        /// <summary>
        /// The hp max point property
        /// </summary>
        public static readonly DependencyProperty HpMaxPointProperty = DependencyProperty.Register("HpMaxPoint", typeof(double), typeof(CreateGameWindow));

        /// <summary>
        /// The movement max point property
        /// </summary>
        public static readonly DependencyProperty MovementMaxPointProperty = DependencyProperty.Register("MovementMaxPoint", typeof(double), typeof(CreateGameWindow));
        #endregion

        #region properties
        /// <summary>
        /// The selected unit.
        /// </summary>
        public IUnit SelectedUnit
        {
            get
            {
                return (IUnit)this.GetValue(SelectedUnitProperty);
            }
            set
            {
                this.SetValue(SelectedUnitProperty, value);
            }
        }

        public Map CreatedMap
        {
            get
            {
                return mapViewer.Map;
            }
        }
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
            double total = waterSlider.Value + fieldSlider.Value + mountainSlider.Value + desertSlider.Value;
            double waterQuantity = (waterSlider.Value / total) * 100;
            double desertQuantity = waterQuantity + ((desertSlider.Value / total) * 100);
            double fieldQuantity = desertQuantity + ((fieldSlider.Value / total) * 100);
            // Moutain is the rest.

            PerlinNoise.UpdateQuantities(waterQuantity, desertQuantity, fieldQuantity);

            if (((ComboBoxItem)sizeComboBox.SelectedValue).Content.Equals("Petite"))
            {
                mapViewer.Map = SmallMap.Instance.CreateMap(null);
            }
            else
            {
                mapViewer.Map = MediumMap.Instance.CreateMap(null);
            }
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

        /// <summary>
        /// Handles the Click event of the removeCivilizationButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void removeCivilizationButton_Click(object sender, RoutedEventArgs e)
        {
            if (civilizationListBox.SelectedItem != null)
            {
                civilizations.Remove((Civilization.ClockWork.Civilization)civilizationListBox.SelectedItem);
            }
        }

        /// <summary>
        /// Handles the Click event of the saveButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog saveFile = new Microsoft.Win32.SaveFileDialog();
            saveFile.Filter = "Civilization Xml (*.cxml)|*.cxml";

            var result = saveFile.ShowDialog();

            if (result != null && result == true)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(civilizations.GetType());

                using (StreamWriter streamWriter = System.IO.File.CreateText(saveFile.FileName))
                {
                    xmlSerializer.Serialize(streamWriter, civilizations);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the loadButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void loadButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFile = new Microsoft.Win32.OpenFileDialog();
            openFile.Filter = "Civilization Xml (*.cxml)|*.cxml";

            var result = openFile.ShowDialog();

            if (result != null && result == true)
            {
                LoadCivilizations(openFile.FileName);
            }
        }

        /// <summary>
        /// Loads the civilizations from a file.
        /// </summary>
        /// <param name="path">The path of the file.</param>
        private void LoadCivilizations(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(civilizations.GetType());

            using (StreamReader streamReader = System.IO.File.OpenText(path))
            {
                civilizations = (ObservableCollection<Civilization.ClockWork.Civilization>)xmlSerializer.Deserialize(streamReader);
            }

            civilizationComboBox.ItemsSource = civilizations;
            civilizationListBox.ItemsSource = civilizations;
        }

        /// <summary>
        /// Handles the Selected event of the departDirectorListBoxItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void departDirectorListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            if (civilizationListBox.SelectedItem != null)
            {
                SelectedUnit = ((Civilization.ClockWork.Civilization)civilizationListBox.SelectedItem).Factory.DepartDirectorPrototype;
                this.maxPoints = 10;
                UpdateRemainingPoints();
            }
        }

        /// <summary>
        /// Handles the Selected event of the teacherListBoxItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void teacherListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            if (civilizationListBox.SelectedItem != null)
            {
                SelectedUnit = ((Civilization.ClockWork.Civilization)civilizationListBox.SelectedItem).Factory.TeacherPrototype;
                this.maxPoints = 5;
                UpdateRemainingPoints();
            }
        }

        /// <summary>
        /// Handles the Selected event of the studentListBoxItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void studentListBoxItem_Selected(object sender, RoutedEventArgs e)
        {
            if (civilizationListBox.SelectedItem != null)
            {
                SelectedUnit = ((Civilization.ClockWork.Civilization)civilizationListBox.SelectedItem).Factory.StudentPrototype;
                this.maxPoints = 18;
                UpdateRemainingPoints();
            }
        }

        /// <summary>
        /// Handles the SelectionChanged event of the civilizationListBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs" /> instance containing the event data.</param>
        private void civilizationListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            unitListBox.SelectedIndex = 0;
        }

        /// <summary>
        /// Called when [remaining point changed].
        /// </summary>
        /// <param name="d">The UserControl d.</param>
        /// <param name="e">The <see cref="DependencyPropertyChangedEventArgs" /> instance containing the event data.</param>
        private static void OnRemainingPointChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CreateGameWindow window = (CreateGameWindow)d;
            window.UpdateSliders();            
        }

        /// <summary>
        /// Updates the remaining points.
        /// </summary>
        private void UpdateRemainingPoints()
        {
            this.SetValue(RemainingPointsProperty, maxPoints - (attackSlider.Value + defenceSlider.Value + hpSlider.Value + movementSlider.Value));
        }

        /// <summary>
        /// Updates the sliders.
        /// </summary>
        private void UpdateSliders()
        {
            this.SetValue(AttackMaxPointProperty, attackSlider.Value + (double)this.GetValue(RemainingPointsProperty));
            this.SetValue(DefenceMaxPointProperty, defenceSlider.Value + (double)this.GetValue(RemainingPointsProperty));
            this.SetValue(HpMaxPointProperty, hpSlider.Value + (double)this.GetValue(RemainingPointsProperty));
            this.SetValue(MovementMaxPointProperty, movementSlider.Value + (double)this.GetValue(RemainingPointsProperty));
        }

        /// <summary>
        /// Defences the slider_ value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void defenceSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateRemainingPoints();
        }

        /// <summary>
        /// Hps the slider_ value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void hpSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateRemainingPoints();
        }

        /// <summary>
        /// Movements the slider_ value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void movementSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateRemainingPoints();
        }

        /// <summary>
        /// Attacks the slider_ value changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void attackSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateRemainingPoints();
        }

        /// <summary>
        /// Handles the Click event of the saveMapButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void saveMapButton_Click(object sender, RoutedEventArgs e)
        {
            if (mapViewer.Map == null)
                return;

            Microsoft.Win32.SaveFileDialog saveFile = new Microsoft.Win32.SaveFileDialog();
            saveFile.Filter = "Map Xml (*.mxml)|*.mxml";

            var result = saveFile.ShowDialog();

            if (result != null && result == true)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(mapViewer.Map.GetType());

                using (StreamWriter streamWriter = System.IO.File.CreateText(saveFile.FileName))
                {
                    xmlSerializer.Serialize(streamWriter, mapViewer.Map);
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the loadMapButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void loadMapButton_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog openFile = new Microsoft.Win32.OpenFileDialog();
            openFile.Filter = "Map Xml (*.mxml)|*.mxml";

            var result = openFile.ShowDialog();

            if (result != null && result == true)
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Map));

                using (StreamReader streamReader = System.IO.File.OpenText(openFile.FileName))
                {
                    mapViewer.Map = (Map)xmlSerializer.Deserialize(streamReader);
                }
            }
        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            if (players.Count < 2)
            {
                MessageBox.Show("Une partie nécéssite au moins la présence de 2 joueurs");
                return;
            }

            if (mapViewer.Map == null)
            {
                MessageBox.Show("Veuillez choisir votre carte avant de pouvoir lancer votre partie");
                return;
            }

            foreach (var player in players)
            {
                if (player.Color == null)
                {
                    MessageBox.Show("Vous devez choisir une couleur pour le joueur " + player.Name);
                    return;
                }

                if (player.PlayedCivilization == null)
                {
                    MessageBox.Show("Vous devez choisir une civilisation pour le joueur " + player.Name);
                    return;
                }
            }

            DialogResult = true;
        }
        #endregion
        #endregion
    }
}
