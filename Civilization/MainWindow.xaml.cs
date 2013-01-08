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
using System.Xml.Serialization;
using System.IO;
using Civilization.Utils.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

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

        /// <summary>
        /// The selected city
        /// </summary>
        private ICity selectedCity;

        /// <summary>
        /// The picked menu
        /// </summary>
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
            selectedUnit = null;

            Log.Instance.Write("Positionnement des unités des joueurs.");
            List<Point> usedPoints = new List<Point>();

            // Initialisation des unités de chaque joueur
            for(int i = 0; i < players.Count; ++i)
            {
                Random random = new Random();
                
                int coordx = random.Next(0, (int)mapViewer.Map.Size.X - 1);
                int coordy = random.Next(0, (int)mapViewer.Map.Size.Y - 1);
                bool found = false;

                // Search a place without water.
                while (!found)
                {
                    if (!(mapViewer.Map.SquareMatrix[coordx, coordy] is Water) && !usedPoints.Contains(new Point(coordx, coordy)))
                    {
                        found = true;
                        break;
                    }

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

        private void Fight(List<IUnit> attackers, List<IUnit> defenders, IPlayer otherPlayer)
        {
            if (attackers.Count == 1 && defenders.Count == 1)
            {
                _1V1Fight fight = new _1V1Fight(attackers[0], defenders[0]);
                fight.StartFight();
            }
            else
            {
                XVXFight fight = new XVXFight();
            
                foreach (IUnit unit in attackers)
                {                
                    fight.addAttacker(unit);
                    if (unit is IDepartDirector)
                    {
                        fight.AddSupportToAttack();
                    }
                }

                foreach (IUnit unit in defenders)
                {
                    fight.addDefender(unit);
                    if (unit is IDepartDirector)
                    {
                        fight.AddSupportToDefence();
                    }
                }

                fight.StartFight();
            }

            foreach (IUnit unit in attackers)
            {
                if (unit.IsDead)
                {
                    players[currentPlayerIndex].Units.Remove(unit);
                }
            }

            foreach (IUnit unit in defenders)
            {
                if (unit.IsDead)
                {
                    otherPlayer.Units.Remove(unit);
                }
            }
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
            for (int i = 0; i < players.Count; ++i)
            {
                if (players[i].IsDead())
                {
                    players.RemoveAt(i);
                }
            }

            if (players.Count == 1)
            {
                MessageBox.Show("Félicitations [" + players[0].Name + "]  vous avez gagné");
            }

            Log.Instance.Write("Fin du tour du joueur [" + players[currentPlayerIndex].Name + "]");
            players[currentPlayerIndex].NextTurn();

            currentPlayerIndex = (++currentPlayerIndex % players.Count);

            mapViewer.Redraw();
            selectedUnit = null;
            selectedCity = null;
            pickContentControl.DataContext = null;
            Log.Instance.Write("Debut du tour du joueur [" + players[currentPlayerIndex].Name + "]");
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

        /// <summary>
        /// Handles the Click event of the drawIdealLocationButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void drawIdealLocationButton_Click(object sender, RoutedEventArgs e)
        {
            mapViewer.EnableIdealLocation = !mapViewer.EnableIdealLocation;
        }

        /// <summary>
        /// Maps the viewer_ render map.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="drawingContext">The drawing context.</param>
        private void mapViewer_RenderMap(object sender, DrawingContext drawingContext)
        {
            // Dessine toutes les unités et cités du joueur courant.            
            players[currentPlayerIndex].Render((MapViewer)sender, drawingContext, null);
            
            var viewPoints = players[currentPlayerIndex].GetAllViewPoint();
            
            // Dessine les unités des autres visibles par celle du joueur courant.
            foreach (IPlayer player in players)
            {
                if (player != players[currentPlayerIndex])
                    player.Render((MapViewer)sender, drawingContext, viewPoints);
            }
        }

        /// <summary>
        /// Handles the Click event of the MenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            pickedMenu.IsOpen = false;
            MenuItem menuItem = (MenuItem)sender;

            pickContentControl.DataContext = menuItem.DataContext;

            if (pickContentControl.DataContext is IUnit)
            {
                selectedUnit = (IUnit)pickContentControl.DataContext;
                selectedCity = null;
            }

            if (pickContentControl.DataContext is ICity)
            {
                selectedCity = (ICity)pickContentControl.DataContext;
                selectedUnit = null;
            }
        }

        /// <summary>
        /// Handles the KeyDown event of the Window control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;

            if (selectedUnit != null)
            {
                if (e.Key == Key.Up)
                {
                    if (selectedUnit.Position.Y == 0)
                        return;

                    if (mapViewer.Map.SquareMatrix[(int)selectedUnit.Position.X, (int)selectedUnit.Position.Y - 1] is Water)
                    {
                        Log.Instance.Write("Impossible de bouger sur une case de type eau.");
                    }
                    else
                    {
                        if (selectedUnit.CanMove())
                        {
                            foreach (IPlayer player in players)
                            {
                                if (player != players[currentPlayerIndex])
                                {
                                    if (player.HasUnit(new Point((int)selectedUnit.Position.X, (int)selectedUnit.Position.Y - 1)))
                                    {
                                        if (MessageBox.Show("Voulez vous combattre l'unité adversaire du joueur [" + player.Name + "]", "Combat", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                                        {
                                            Fight(players[currentPlayerIndex].GetUnits(
                                                selectedUnit.Position), 
                                                player.GetUnits(new Point((int)selectedUnit.Position.X, (int)selectedUnit.Position.Y - 1)),
                                                player);

                                            if (player.GetUnits(new Point((int)selectedUnit.Position.X, (int)selectedUnit.Position.Y - 1)).Count < 1)
                                            {
                                                selectedUnit.MoveUp();                                                
                                                // Traiter le cas ou on va sur une ville
                                            }
                                            else
                                            {
                                                mapViewer.Redraw();
                                                selectedUnit = null;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            return;
                                        }
                                    }
                                    else if (player.HasCity(new Point((int)selectedUnit.Position.X, (int)selectedUnit.Position.Y - 1)))
                                    {
                                        ICity city = player.GetCity(new Point((int)selectedUnit.Position.X, (int)selectedUnit.Position.Y - 1));
                                        player.RemoveCity(city);
                                        players[currentPlayerIndex].AddCity(city);
                                        Log.Instance.Write("Vous avez pris une ville de l'adversaire.");
                                        mapViewer.Redraw();
                                        selectedUnit = null;
                                        return;
                                    }
                                }


                            }

                            selectedUnit.MoveUp();
                            mapViewer.Redraw();
                        }
                        else
                        {
                            Log.Instance.Write("Cette unité ne possède plus de points de mouvement.");
                        }
                    }
                }
                else if (e.Key == Key.Down)
                {
                    if (selectedUnit.Position.Y == (mapViewer.Map.Size.Y - 1))
                        return;

                    if (mapViewer.Map.SquareMatrix[(int)selectedUnit.Position.X, (int)selectedUnit.Position.Y + 1] is Water)
                    {
                        Log.Instance.Write("Impossible de bouger sur une case de type eau.");
                    }
                    else
                    {
                        if (selectedUnit.CanMove())
                        {
                            foreach (IPlayer player in players)
                            {
                                if (player != players[currentPlayerIndex])
                                {
                                    if (player.HasUnit(new Point((int)selectedUnit.Position.X, (int)selectedUnit.Position.Y + 1)))
                                    {
                                        if (MessageBox.Show("Voulez vous combattre l'unité adversaire du joueur [" + player.Name + "]", "Combat", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                                        {
                                            Fight(players[currentPlayerIndex].GetUnits(
                                                selectedUnit.Position),
                                                player.GetUnits(new Point((int)selectedUnit.Position.X, (int)selectedUnit.Position.Y + 1)),
                                                player);

                                            if (player.GetUnits(new Point((int)selectedUnit.Position.X, (int)selectedUnit.Position.Y + 1)).Count < 1)
                                            {
                                                selectedUnit.MoveUp();
                                                // Traiter le cas ou on va sur une ville
                                            }
                                            else
                                            {
                                                mapViewer.Redraw();
                                                selectedUnit = null;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            return;
                                        }
                                    }
                                    else if (player.HasCity(new Point((int)selectedUnit.Position.X, (int)selectedUnit.Position.Y + 1)))
                                    {
                                        ICity city = player.GetCity(new Point((int)selectedUnit.Position.X, (int)selectedUnit.Position.Y + 1));
                                        player.RemoveCity(city);
                                        players[currentPlayerIndex].AddCity(city);
                                        Log.Instance.Write("Vous avez pris une ville de l'adversaire.");
                                        mapViewer.Redraw();
                                        selectedUnit = null;
                                        return;
                                    }
                                }

                            }

                            selectedUnit.MoveDown();
                            mapViewer.Redraw();
                        }
                        else
                        {
                            Log.Instance.Write("Cette unité ne possède plus de points de mouvement.");
                        }
                    }
                }
                else if (e.Key == Key.Right)
                {
                    if (selectedUnit.Position.X == (mapViewer.Map.Size.X - 1))
                        return;

                    if (mapViewer.Map.SquareMatrix[(int)selectedUnit.Position.X + 1, (int)selectedUnit.Position.Y] is Water)
                    {
                        Log.Instance.Write("Impossible de bouger sur une case de type eau.");
                    }
                    else
                    {
                        if (selectedUnit.CanMove())
                        {
                            foreach (IPlayer player in players)
                            {
                                if (player != players[currentPlayerIndex])
                                {
                                    if (player.HasUnit(new Point((int)selectedUnit.Position.X + 1, (int)selectedUnit.Position.Y)))
                                    {
                                        if (MessageBox.Show("Voulez vous combattre l'unité adversaire du joueur [" + player.Name + "]", "Combat", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                                        {

                                            Fight(players[currentPlayerIndex].GetUnits(
                                               selectedUnit.Position),
                                               player.GetUnits(new Point((int)selectedUnit.Position.X + 1, (int)selectedUnit.Position.Y)),
                                               player);

                                            if (player.GetUnits(new Point((int)selectedUnit.Position.X + 1, (int)selectedUnit.Position.Y)).Count < 1)
                                            {
                                                selectedUnit.MoveUp();
                                                // Traiter le cas ou on va sur une ville
                                            }
                                            else
                                            {
                                                mapViewer.Redraw();
                                                selectedUnit = null;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            return;
                                        }
                                    }
                                    else if (player.HasCity(new Point((int)selectedUnit.Position.X + 1, (int)selectedUnit.Position.Y)))
                                    {
                                        ICity city = player.GetCity(new Point((int)selectedUnit.Position.X + 1, (int)selectedUnit.Position.Y));
                                        player.RemoveCity(city);
                                        players[currentPlayerIndex].AddCity(city);
                                        Log.Instance.Write("Vous avez pris une ville de l'adversaire.");
                                        mapViewer.Redraw();
                                        selectedUnit = null;
                                        return;
                                    }
                                }

                            }

                            selectedUnit.MoveRight();
                            mapViewer.Redraw();
                        }
                        else
                        {
                            Log.Instance.Write("Cette unité ne possède plus de points de mouvement.");
                        }
                    }
                }
                else if (e.Key == Key.Left)
                {
                    if (selectedUnit.Position.X == 0)
                        return;

                    if (mapViewer.Map.SquareMatrix[(int)selectedUnit.Position.X - 1, (int)selectedUnit.Position.Y] is Water)
                    {
                        Log.Instance.Write("Impossible de bouger sur une case de type eau.");
                    }
                    else
                    {
                        if (selectedUnit.CanMove())
                        {
                            foreach (IPlayer player in players)
                            {
                                if (player != players[currentPlayerIndex])
                                {
                                    if (player.HasUnit(new Point((int)selectedUnit.Position.X - 1, (int)selectedUnit.Position.Y)))
                                    {
                                        if (MessageBox.Show("Voulez vous combattre l'unité adversaire du joueur [" + player.Name + "]", "Combat", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                                        {

                                            Fight(players[currentPlayerIndex].GetUnits(
                                                selectedUnit.Position),
                                                player.GetUnits(new Point((int)selectedUnit.Position.X - 1, (int)selectedUnit.Position.Y)),
                                                player);

                                            if (player.GetUnits(new Point((int)selectedUnit.Position.X - 1, (int)selectedUnit.Position.Y)).Count < 1)
                                            {
                                                selectedUnit.MoveUp();
                                                // Traiter le cas ou on va sur une ville
                                            }
                                            else
                                            {
                                                mapViewer.Redraw();
                                                selectedUnit = null;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            return;
                                        }
                                    }
                                    else if (player.HasCity(new Point((int)selectedUnit.Position.X - 1, (int)selectedUnit.Position.Y)))
                                    {
                                        ICity city = player.GetCity(new Point((int)selectedUnit.Position.X - 1, (int)selectedUnit.Position.Y));
                                        player.RemoveCity(city);
                                        players[currentPlayerIndex].AddCity(city);
                                        Log.Instance.Write("Vous avez pris une ville de l'adversaire.");
                                        mapViewer.Redraw();
                                        selectedUnit = null;
                                        return;
                                    }
                                }


                            }

                            selectedUnit.MoveLeft();
                            mapViewer.Redraw();
                        }
                        else
                        {
                            Log.Instance.Write("Cette unité ne possède plus de points de mouvement.");
                        }
                    }
                }

                mapViewer.PickedSquare = selectedUnit.Position;
            }
        }

        /// <summary>
        /// Handles the 1 event of the createCityButton_Click control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void createCityButton_Click_1(object sender, RoutedEventArgs e)
        {
            if (selectedUnit is ITeacher)
            {
                bool hasCity = false;
                foreach (IPlayer player in players)
                {
                    foreach (ICity city in player.Cities)
                    {
                        if (city.IsAtPosition(selectedUnit.Position))
                        {
                            hasCity = true;
                        }
                    }
                }

                if (!hasCity)
                {
                    ITeacher selectedTeacher = selectedUnit as ITeacher;
                    ICity City = selectedTeacher.CreateCity(selectedTeacher.Position, mapViewer.Map, players[currentPlayerIndex]);
                    players[currentPlayerIndex].Cities.Add(City);
                    selectedTeacher.HP = 0;
                    selectedTeacher.Movement = 0;
                    players[currentPlayerIndex].Units.Remove(selectedUnit);
                }
                else
                {
                    Log.Instance.Write("Une ville possède déjà cette case.");
                }
            }
            mapViewer.Redraw();
        }

        /// <summary>
        /// Handles the Click event of the createUnitButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void createUnitButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCity != null)
            {
                BuyUnitMessageBox buyMsgBox = new BuyUnitMessageBox();

                var result = buyMsgBox.ShowDialog();

                if ((result != null) && result == true)
                {
                    switch (buyMsgBox.SelectedUnitType)
                    {
                        case "Etudiant":
                            selectedCity.CreateUnit(UnitType.U_STUDENT, players[currentPlayerIndex]);
                            break;
                        case "Directeur":
                            selectedCity.CreateUnit(UnitType.U_DIRECTOR, players[currentPlayerIndex]);
                            break;
                        case "Enseignant":
                            selectedCity.CreateUnit(UnitType.U_TEACHER, players[currentPlayerIndex]);
                            break;
                    }
                }
            }

            this.mapViewer.Redraw();
        }

        /// <summary>
        /// Handles the Click event of the loadMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void loadMenuItem_Click(object sender, RoutedEventArgs e)
        {
            /*
            Microsoft.Win32.OpenFileDialog openFile = new Microsoft.Win32.OpenFileDialog();
            openFile.Filter = "Party Xml (*.pxml)|*.pxml";

            var result = openFile.ShowDialog();

            if (result != null && result == true)
            {
                

                using (StreamReader streamReader = System.IO.File.OpenText(openFile.FileName))
                {
                   // mapViewer.Map = (Map)xmlSerializer.Deserialize(streamReader);
                }
            }*/
        }


        /// <summary>
        /// Handles the Click event of the saveMenuItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs" /> instance containing the event data.</param>
        private void saveMenuItem_Click(object sender, RoutedEventArgs e)
        {
            /*
            Microsoft.Win32.SaveFileDialog saveFile = new Microsoft.Win32.SaveFileDialog();
            saveFile.Filter = "Partie Xml (*.pxml)|*.pxml";

            var result = saveFile.ShowDialog();

            if (result != null && result == true)
            {
                BinaryFormatter bformatter = new BinaryFormatter();
                Party p = new Party();
                List<XmlAnything<IPlayer>> savedPlayers = new List<XmlAnything<IPlayer>>();

                foreach (IPlayer player in players)
                {
                    savedPlayers.Add(new XmlAnything<IPlayer>(player));
                }

                p.Map = mapViewer.Map;
                p.Players = savedPlayers;

                using (Stream streamWriter = System.IO.File.Open(saveFile.FileName, FileMode.Create))
                {
                    bformatter.Serialize(streamWriter, p);
                }
            }
             * */
        }
        #endregion
        #endregion
        #endregion
    }
}
