using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for StartWindow.xaml
    /// </summary>
    public partial class StartWindow : Window
    {
        Board board;
        public StartWindow()
        {
            InitializeComponent();

        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            if (board.Players.Count > 1)
            {
                MainWindow window = new MainWindow(board);
                window.Show();
                this.Close();
            }
            else
                MessageBox.Show(this, "At least two players have to join to start!", "Impossible", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void join_Click(object sender, RoutedEventArgs e)
        {
            try
            { board.addPlayer(new Player(playerName.Text)); }
            catch (Exception error)
            { MessageBox.Show(error.Message, $"Can't add the player with name {playerName.Text}", MessageBoxButton.OK, MessageBoxImage.Exclamation); }
            playersList.ItemsSource = new ObservableCollection<Player>(board.Players);
        }

        private void size_Click(object sender, RoutedEventArgs e)
        {
            if (width.Text != "" && height.Text != "")
            {
                int width_ = 0, height_ = 0;
                try
                {
                    width_ = Convert.ToInt32(width.Text);
                    width.Background = Brushes.White;
                }
                catch (Exception error)
                {
                    width.Background = Brushes.Red;
                    MessageBox.Show(error.Message, "Impossible!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }

                try
                {
                    height_ = Convert.ToInt32(height.Text);
                    height.Background = Brushes.White; 
                }
                catch (Exception error)
            {
                height.Background = Brushes.Red;
                MessageBox.Show(error.Message, "Impossible!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            if (width_ != 0 && height_ != 0)
            {
                try
                {
                    board = new Board(width_, height_);
                    playerName.Visibility = Visibility.Visible;
                    join.Visibility = Visibility.Visible;
                    start.Visibility = Visibility.Visible;
                }
                catch (Exception error)
                { MessageBox.Show(error.Message, "Impossible!", MessageBoxButton.OK, MessageBoxImage.Exclamation); }


            }
        }

    }

}
}