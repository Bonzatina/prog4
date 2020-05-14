using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OENIK_PROG4_2020_1_A2ETR7_SCE1EH
{
    /// <summary>
    /// Interaction logic for StartGameWindow.xaml
    /// </summary>
    public partial class StartGameWindow : Window
    {
        public StartGameWindow()
        {
            InitializeComponent();
        }

        private void StartNewGame(object sender, RoutedEventArgs e)
        {
            Window gameWindow = new MainWindow();
            gameWindow.ShowDialog();       

        }

        private void LoadGame(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sorry, not implemented yet");
        }

        private void ViewStatistics(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sorry, not implemented yet");
        }
    }
}
