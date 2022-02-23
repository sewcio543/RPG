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


        private void new_MouseEnter(object sender, MouseEventArgs e)
        {
            newButton.FontSize = 40;
            newButton.Foreground = Brushes.Black;
            newButton.Width = 360;
        }

        private void new_MouseLeave(object sender, MouseEventArgs e)
        {
            newButton.FontSize = 30;
            newButton.Foreground = Brushes.Green;
            newButton.Width = 330;
        }
        private void newButton_Click(object sender, RoutedEventArgs e)
        {
            StartWindow window = new StartWindow();
            window.Show();
            this.Close();
        }

        private void continue_MouseEnter(object sender, MouseEventArgs e)
        {
            continueButton.FontSize = 40;
            continueButton.Foreground = Brushes.Black;
            continueButton.Width = 360;
        }

        private void continue_MouseLeave(object sender, MouseEventArgs e)
        {
            continueButton.FontSize = 30;
            continueButton.Foreground = Brushes.Green;
            continueButton.Width = 330;
        }

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

        private void about_MouseEnter(object sender, MouseEventArgs e)
        {
            aboutButton.FontSize = 40;
            aboutButton.Foreground = Brushes.Black;
            aboutButton.Width = 360;
        }

        private void about_MouseLeave(object sender, MouseEventArgs e)
        {
            aboutButton.FontSize = 30;
            aboutButton.Foreground = Brushes.Green;
            aboutButton.Width = 330;
        }

        private void about_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
