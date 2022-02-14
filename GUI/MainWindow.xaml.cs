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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Game;

namespace GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Board board;
        public MainWindow()
        {
            InitializeComponent();
            layout();
            board = new Board();
            board.addPlayer(createPlayer("Wojtek"));
            board.addPlayer(createPlayer("Mateusz"));
            place();


        }

        public Player createPlayer(string name) { return new Player(name); }


        public void layout()
        {
            for (int i = 0; i < 50; i++)
            {
                ColumnDefinition c = new ColumnDefinition();
                c.Width = new GridLength(36);
                mainGrid.ColumnDefinitions.Add(c);

                RowDefinition r = new RowDefinition();
                r.Height = new GridLength(36);
                mainGrid.RowDefinitions.Add(r);
            }

            for (int i = 0; i < 20; i++)
            {
                RowDefinition r = new RowDefinition();
                r.Height = new GridLength(50);
                mainGrid.RowDefinitions.Add(r);
            }

        }


        public void place()
        {
            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (board.getObjectFromSquare(i, j) != null)
                    {
                        Image image = new Image();
                        image.Width = 36;
                        image.Height = 36;
                        //image.VerticalAlignment = VerticalAlignment.Top;
                        //image.HorizontalAlignment = HorizontalAlignment.Left;
                        StackPanel stackPanel = new StackPanel();
                        mainGrid.Children.Add(stackPanel);
                        stackPanel.Children.Add(image);
                        Grid.SetColumn(stackPanel, i);
                        Grid.SetRow(stackPanel, j);

                        if (board.getObjectFromSquare(i, j).GetType() == typeof(Wanderer))
                        {
                            image.Source = new BitmapImage(new Uri(@"C:\\Users\xxx\Desktop\Gierka\GUI\Resources\wanderer.png"));
                            image.MouseEnter += new MouseEventHandler(tipWanderer);
                        }


                        if (board.getObjectFromSquare(i, j).GetType() == typeof(Base))
                            image.Source = new BitmapImage(new Uri(@"C:\\Users\xxx\Desktop\Gierka\GUI\Resources\base.png"));

                        if (board.getObjectFromSquare(i, j).GetType() == typeof(Barrack))
                            image.Source = new BitmapImage(new Uri(@"C:\\Users\xxx\Desktop\Gierka\GUI\Resources\barrack.png"));

                        if (board.getObjectFromSquare(i, j).GetType() == typeof(Stone))
                            image.Source = new BitmapImage(new Uri(@"C:\\Users\xxx\Desktop\Gierka\GUI\Resources\stone.jpg"));

                        if (board.getObjectFromSquare(i, j).GetType() == typeof(Gold))
                            image.Source = new BitmapImage(new Uri(@"C:\\Users\xxx\Desktop\Gierka\GUI\Resources\gold.png"));

                        if (board.getObjectFromSquare(i, j).GetType() == typeof(Tree))
                            image.Source = new BitmapImage(new Uri(@"C:\\Users\xxx\Desktop\Gierka\GUI\Resources\tree.png"));
                    }
                }
            }
        }

        public void tipWanderer(object sender, MouseEventArgs e)
        {
            Point position = e.GetPosition(this);
            int x = (int)Math.Floor(position.X / 36);
            int y = (int)Math.Floor(position.Y / 36);

            Wanderer wanderer = board.getObjectFromSquare(x, y) as Wanderer;
            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (board.distance(wanderer.X, wanderer.Y, i, j) < wanderer.Leap && board.isAvailable(i,j))
                    {
                        Image image = new Image();
                        image.Width = 36;
                        image.Height = 36;
                        //image.VerticalAlignment = VerticalAlignment.Top;
                        //image.HorizontalAlignment = HorizontalAlignment.Left;
                        StackPanel stackPanel = new StackPanel();
                        stackPanel.Background = Brushes.Green;
                        mainGrid.Children.Add(stackPanel);
                        stackPanel.Children.Add(image);
                        Grid.SetColumn(stackPanel, i);
                        Grid.SetRow(stackPanel, j);
                        image.Source = new BitmapImage(new Uri(@"C:\\Users\xxx\Desktop\Gierka\GUI\Resources\circle.png"));


                    }
                }
            }
        }
    }
}
