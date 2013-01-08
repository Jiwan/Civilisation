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
using System.Windows.Navigation;
using System.Windows.Shapes;

using Civilization.World.Map;
using Civilization.World.Square;
using Civilization.Utils.Logs;
using Civilization.Player;
using Civilization.ClockWork.Unit;
using Civilization.ClockWork.City;
using Civilization.CustomControls;
using Civilization.Fight;

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
        private CreateGameWindow window;

        /// <summary>
        /// The players.
        /// </summary>
        private List<IPlayer> players;

        /// <summary>
        /// The current player index
        /// </summary>
        private int currentPlayerIndex;

        /// <summary>
        /// The selected unit
        /// </summary>
        private IUnit selectedUnit;

        private ContextMenu pickedMenu;
        #endregion
        
        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            Log.Instance.WriteFunction = WriteLog;
            pickedMenu = new ContextMenu();            
        }
        #endregion

        #region methods

        #region private

        #region internal
        /// <summary>
        /// Inits the game.
        /// </summary>
        private void InitGame()
        {
            currentPlayerIndex = 0;

            Log.Instance.Write("Positionnement des unités des joueurs.");
            List<Point> usedPoints = new List<Point>();

            // Initialisation des unités de chaque joueur
            for(int i = 0; i < players.Count; i++)
            {
                Random random = new Random();
                
                int coordx = random.Next(0, (int)mapViewer.Map.Size.X - 1);
                int coordy = random.Next(0, (int)mapViewer.Map.Size.Y - 1);
                bool found = false;

                // Search a place without water.
                while (!found)
                {
                    if (!(mapViewer.Map.SquareMatrix[coordx, coordy] is Water) && !usedPoints.Contains(new Point(coordx, coordy)))
                        found = true;

                    coordx = random.Next(0, (int)mapViewer.Map.Size.X - 1);
                    coordy = random.Next(0, (int)mapViewer.Map.Size.Y - 1);
                }

                usedPoints.Add(new Point(coordx, coordy));

                // Création des joueurs
                IUnit teacher = players[i].PlayedCivilization.Factory.CreateTeacher();                
                teacher.Position = new Point(coordx, coordy);

                IUnit student = players[i].PlayedCivilization.Factory.CreateStudent();
                student.Position = new Point(coordx, coordy);

                // Ajout à la liste des unités de chaque joueur
                players[i].AddUnit(student);
                players[i].AddUnit(teacher);
            }
        }

        /// <summary>
        /// Writes the log.
        /// </summary>
        /// <param name="info">The info you want to write.</param>
        private void WriteLog(string info)
        {
            logTextBlock.Text = info + "\n" + logTextBlock.Text;
        }
        #endregion

        #region events
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
                this.players = new List<IPlayer>(window.Players);

                Log.Instance.Write("Chargement de la carte...");
                Log.Instance.Write("Chargement des joueurs...");
                Log.Instance.Write("Début de la partie.");

                InitGame();

                Log.Instance.Write("Le joueur [" + players[currentPlayerIndex].Name + "] commence son tour.");
            }
        }

        /// <summary>
        /// Handles the Click event of the aboutMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void aboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(@"Ce projet a été crée par J.Guegant et R.Lagrange dans le cadre d'un cours de POO à l'Institut National des Sciences Appliquées de Rennes.
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
            pickedMenu.Items.Clear();

            if (players[currentPlayerIndex].HasUnit(position))
            {
                var units = players[currentPlayerIndex].GetUnits(position);

                foreach (IUnit unit in units)
                {
                    MenuItem menuItem = new MenuItem();
                    menuItem.DataContext = unit;
                    menuItem.Header = unit.Name;
                    menuItem.Click += MenuItem_Click;
                    pickedMenu.Items.Add(menuItem);
                    mapViewer.ContextMenu = pickedMenu;
                }
            }

            if (players[currentPlayerIndex].HasCity(position))
            {
                var city = players[currentPlayerIndex].GetCity(position);

                MenuItem menuItem = new MenuItem();
                menuItem.DataContext = city;
                menuItem.Header = "Ville";
                menuItem.Click += MenuItem_Click;
                pickedMenu.Items.Add(menuItem);
                mapViewer.ContextMenu = pickedMenu;
            }

            if (pickedMenu.Items.Count > 0)
            {
                pickedMenu.IsOpen = true;
            }
            else
            {
                squarePositionStackPanel.DataContext = mapViewer;
                pickContentControl.DataContext = mapViewer.Map.SquareMatrix[(int)position.X, (int)position.Y];
            }            
        }

        /// <summary>
        /// Handles the Click event of the nextTurnButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void nextTurnButton_Click(object sender, RoutedEventArgs e)
        {
            Log.Instance.Write("Fin du tour du joueur [" + players[currentPlayerIndex].Name + "]");
            players[currentPlayerIndex].NextTurn();

            currentPlayerIndex = (++currentPlayerIndex % players.Count);
        }


        /// <summary>
        /// Numbers the units on square.
        /// </summary>
        /// <param name="position">The position.</param>
        /// <returns></returns>
        public int numberUnitsOnSquare(Point position)
        {
            int number = 0;
            foreach (IPlayer player in players)
            {
                foreach (IUnit unit in player.Units)
                {
                    if (unit.Position.Equals(position))
                    {
                        number++;
                    }
                }
            }
            return number;
        }

        private void createCityButton_Click(object sender, RoutedEventArgs e)
        {
            bool hasCity = false;
            foreach(IPlayer player in players)
            {
                foreach (ICity city in player.Cities)
                {
                    if (city.isAtPosition(selectedUnit.Position))
                    {
                        hasCity = true;
                    }
                }
            }
            Log.Instance.Write("Détermination si la case est occupée ou pas.");

            if (!hasCity)
            {
                ITeacher selectedTeacher = selectedUnit as ITeacher;
                ICity City = selectedTeacher.CreateCity(selectedTeacher.Position, players[currentPlayerIndex].Game.Map);
                players[currentPlayerIndex].Cities.Add(City);
                selectedTeacher.HP = 0;
                selectedTeacher.Movement = 0;
                players[currentPlayerIndex].Units.Remove(selectedUnit);
            }
            Log.Instance.Write("Ville créée à l'emplacement.");
        }

        // Attaquer des unités avec le click droit
        private void attackButton_RightClick(object sender, RoutedEventArgs e)
        {
            if (selectedUnit.Attack == 0)
            {
                Log.Instance.Write("Cette unité ne peut attaquer!");
                return;
            }

            // Initialiser attackedUnit avec l'unité qu'on veut attaquer !!
            IUnit attackedUnit = null;
            if (numberUnitsOnSquare(attackedUnit.Position) > 1)
            {
                new XVXFight(selectedUnit, attackedUnit);
                // ajouter les autres unités
                foreach (IUnit unit in players[currentPlayerIndex].Units)
                {
                    if (unit.Position.Equals(selectedUnit.Position))
                    {

                    }
                }
            }
            else
            {
                new _1V1Fight(selectedUnit, attackedUnit);
            }
        }

        private void drawIdealLocationButton_Click(object sender, RoutedEventArgs e)
        {
            mapViewer.EnableIdealLocation = !mapViewer.EnableIdealLocation;
        }

        private void mapViewer_RenderMap(object sender, DrawingContext drawingContext)
        {
            // Dessine toutes les unités et cités du joueur courant.            
            players[currentPlayerIndex].Render((MapViewer)sender, drawingContext);
            
            // Dessine les unités des autres visibles par celle du joueur courant.
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            pickedMenu.IsOpen = false;

            MenuItem menuItem = (MenuItem)sender;

            pickContentControl.DataContext = menuItem.DataContext;
        }


        #endregion
        #endregion
        #endregion
    }
}
