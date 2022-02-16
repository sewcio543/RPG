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
        public End(Player player): base()
        {
            winner.Content = $"Player {player.Name} lost!";
        }
    }
}
