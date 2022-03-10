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


    }
}
