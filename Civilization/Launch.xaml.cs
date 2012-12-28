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

namespace Civilization
{
    /// <summary>
    /// Interaction logic for Launch.xaml
    /// </summary>
    public partial class Launch : Window
    {
        public Launch()
        {
            InitializeComponent();
        }

        private void smallMap_checked(object sender, RoutedEventArgs e)
        {
            btnSmallMap.Foreground = Brushes.Blue;
            btnSmallMap.Background = Brushes.Yellow;

            btnBigMap.Foreground = Brushes.Black;
            btnBigMap.Background = Brushes.White;
        }

        private void bigMap_checked(object sender, RoutedEventArgs e)
        {
            btnBigMap.Foreground = Brushes.Blue;
            btnBigMap.Background = Brushes.Yellow;

            btnSmallMap.Foreground = Brushes.Black;
            btnSmallMap.Background = Brushes.White;
        }

        private void LaunchGame(object sender, RoutedEventArgs e)
        {
            //A finir d'implémenter
            
            //choix de la taille de carte et création de celle-ci
            if (btnBigMap.isChecked == true)
            {
                Console.WriteLine("Big Map chosen.");
                MapDisplay map = new MapDisplay(100);
            }
            else
            {
                Console.WriteLine("Small Map chosen.");
                MapDisplay map = new MapDisplay(25);
            }
            
            //Créer un Game
            //Ajouter le joueur
            
            Game.Game();
        }
    }
}
