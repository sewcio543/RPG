using System;
using System.Collections;
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
        ArrayList textboxes;
        public StartWindow(bool creative_ = false)
        {
            InitializeComponent();
            textboxes = new ArrayList() { player1, player2, player3, player4 };
            board = new Board(25, 15);

            player2.IsEnabled = false;
            player3.IsEnabled = false;

            if (creative_) { creative.IsChecked = true; }
        }

        //starting the game
        private void start_Click(object sender, RoutedEventArgs e)
        {
            board.Players.Clear();
            int width_ = 25;
            int height_ = 15;
            try
            {
                width_ = Convert.ToInt32(width.Text);
                height_ = Convert.ToInt32(height.Text);
                board = new Board(width_, height_);

                foreach (TextBox textbox in textboxes)
                {
                    if (textbox.Text != "")
                    {
                        try
                        {
                            if (creative.IsChecked == true)
                                board.addPlayer(new Player(textbox.Text) { Materials = 10000, Level = 8 });
                            else
                                board.addPlayer(new Player(textbox.Text));
                        }
                        catch (Exception ex)
                        { MessageBox.Show(ex.Message, "Impossible", MessageBoxButton.OK, MessageBoxImage.Information); }

                    }
                }
                if (board.Players.Count <= 1)
                    MessageBox.Show("At least two players have to join to start!", "Impossible", MessageBoxButton.OK, MessageBoxImage.Information);
                else
                {
                    MainWindow window = new MainWindow(board);
                    window.Show();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Impossible!", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }

        }

        
        private void player1_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (player1.Text != "")
                player2.IsEnabled = true;
            else
            {
                player2.IsEnabled = false;
                player3.IsEnabled = false;
                player4.IsEnabled = false;
                start.IsEnabled = false;
            }

        }

        private void player2_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (player2.Text != "")
            {
                start.IsEnabled = true;
                player3.IsEnabled = true;
            }
           else
            {
                player3.IsEnabled = false;
                player4.IsEnabled = false;
                start.IsEnabled = false;
            }

        }

        private void player3_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (player3.Text != "")
                player4.IsEnabled = true;
            else
                player4.IsEnabled = false;         
        }

        private void player2_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (player2.IsEnabled && player3.Text != "")
                player3.IsEnabled = true;
        }

        private void player3_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (player3.IsEnabled && player4.Text != "")
                player4.IsEnabled = true;

        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Menu();
            window.Show(); 
            this.Close();   
        }
    }


}