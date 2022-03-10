using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Game;

namespace GUI
{
    /// <summary>
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        Board board;
        public Menu()
        {
            InitializeComponent();
        }

        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            StartWindow window = new StartWindow();
            window.Show();
            this.Close();
        }

        // loading last serialized game
        private void continue_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists("board.bin"))
            {
                board = Board.deserialize("board.bin");
                MainWindow window = new MainWindow(board);
                window.Show();
                this.Close();
            }
            else
            { MessageBox.Show("No games saved", " ", MessageBoxButton.OK, MessageBoxImage.Exclamation); }
            
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {
            Window about = new About();
            about.Show();
            this.Close();
        }

    }
}
