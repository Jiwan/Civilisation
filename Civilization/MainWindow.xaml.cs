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

namespace Civilization
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Map map = (new SmallMap()).CreateMap(null);
           // mapControl.ItemsSource = map.SquareMatrix.Cast<Square>();
        }

        private void closeMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void createMenuItem_Click(object sender, RoutedEventArgs e)
        {
            CreateGameWindow window = new CreateGameWindow();
            
            var result = window.ShowDialog();

            if (result.HasValue && result.Value)
            {
                //!TODO : Traiter la création de la partie.
            }
        }
    }
}
