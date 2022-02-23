using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for End.xaml
    /// </summary>
    public partial class End : Window
    {
        public End()
        {
            InitializeComponent();
        }
        public End(Player player, bool won = false) : this()
        {
            winner.Content = $"Player {player.Name} {(won == true ? "won :D" : "lost :(")}";
            if (won)
            {
                nextButton.Content = "Next Game";
                Width += 100;
                File.Delete("board.bin");
            }
        }


        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void nextButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void nextButton_MouseEnter(object sender, MouseEventArgs e)
        {
            nextButton.FontSize = 40;
            nextButton.Foreground = Brushes.Black;
            nextButton.Width = 550;
        }

        private void nextButton_MouseLeave(object sender, MouseEventArgs e)
        {
            nextButton.FontSize = 30;
            nextButton.Foreground = Brushes.Green;
            nextButton.Width = 500;
        }

        private void exit_MouseEnter(object sender, MouseEventArgs e)
        {
            exitButton.FontSize = 40;
            exitButton.Foreground = Brushes.Black;
            exitButton.Width = 550;
        }

        private void exit_MouseLeave(object sender, MouseEventArgs e)
        {
            exitButton.FontSize = 30;
            exitButton.Foreground = Brushes.Green;
            exitButton.Width = 500;
        }

    }
}
