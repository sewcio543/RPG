using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for About.xaml
    /// </summary>
    public partial class About : Window
    {
        public About()
        {
            InitializeComponent();
        }

        private void play_Click(object sender, RoutedEventArgs e)
        {
            Window window = new StartWindow();
            window.Show();
            this.Close();
        }

        private void play_creative_Click(object sender, RoutedEventArgs e)
        {
            Window window = new StartWindow(true);
            window.Show();
            this.Close();

        }

        private void menu_Click(object sender, RoutedEventArgs e)
        {
            Window window = new Menu();
            window.Show();
            this.Close();
        }
    }
}
