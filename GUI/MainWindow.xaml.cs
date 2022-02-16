using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        Player player;
        Character chosenCharacter;
        Game.Object chosenObject;
        Building chosenBuilding;
        int x, y;
        bool canCollect = false;
        bool canFight = false;
        double squareWidth;
        double squareHeight;
        double widthDifference;


        public MainWindow()
        {
            InitializeComponent();

            MinWidth = 1000;
            MinHeight = 600;
            board = new Board(30, 20);

            widthDifference = SystemParameters.MaximizedPrimaryScreenWidth - SystemParameters.VirtualScreenWidth;
            this.PreviewMouseLeftButtonDown += MainWindow_PreviewMouseLeftButtonDown1;
            this.SizeChanged += WindowSizeChanged;
            this.WindowState = WindowState.Maximized;

            board.addPlayer(createPlayer("Wojtek"));
            board.addPlayer(createPlayer("Mateusz"));
            board.Players[1].Exp -= 50;
            player = board.Players[0];
            place(player);

            barrackButton.ToolTip = new Barrack(player).Tip();
            hospitalButton.ToolTip = new Hospital(player).Tip();
            houseButton.ToolTip = new House(player).Tip();

            warrior.ToolTip = new Warrior(player).Tip();
            archer.ToolTip = new Archer(player).Tip();
            rider.ToolTip = new Rider(player).Tip();

            chosenCharacter = board.Characters[0];
            //t(ActualWidth);
        }
        public void t(double x)
        { Title = $"{x}"; }


        public void setUpperGrid()
        {
            upperGrid.Height = 0.1 * ActualHeight;
            upperGrid.Width = ActualWidth;

            mainGrid.Height = 0.9 * ActualHeight;
            mainGrid.Width = ActualWidth;

            upperGrid.Margin = new Thickness(0.015 * upperGrid.Width, 0, 0, 0);
            levelPanel.Margin = new Thickness(0, 0.075 * upperGrid.Height, 0, 0);
            levelBar.Width = 0.093 * upperGrid.Width;
            levelBar.Height = 0.3 * upperGrid.Height;

            levelTextbox.Width = levelBar.Width;
            levelTextbox.Height = levelBar.Height;

            levelTextbox.FontSize = levelTextbox.Height / 1.5 ;

            levelCircle.Margin = new Thickness( -0.012 * ActualWidth, -0.02* upperGrid.Height, 0, 0);

            levelImage.Height = 0.6 * upperGrid.Height;
            levelImage.Width = 0.03 * upperGrid.Width;

            levelText.FontSize = levelImage.Height/2;
            levelText.Width = levelImage.Width;
            levelText.Height = levelImage.Height;
        
            Canvas.SetLeft(actionMenu, levelBar.Width + 10);
            fightButton.Margin = new Thickness(0.01 * ActualWidth, 0, 0, 0);
            buildButton.Margin = new Thickness(0.01 * ActualWidth, 0, 0, 0);
            collectButton.Margin = new Thickness(0.01 * ActualWidth, 0, 0, 0);

            moveButton.Height = upperGrid.Height;
            collectButton.Height = upperGrid.Height;
            fightButton.Height = upperGrid.Height;
            buildButton.Height = upperGrid.Height;

            moveButton.Width = 0.05 * upperGrid.Width;
            collectButton.Width = 0.05 * upperGrid.Width;
            fightButton.Width = 0.05 * upperGrid.Width;
            buildButton.Width = 0.05 * upperGrid.Width;


            collectImage.Width = 0.8 * collectButton.Height;
            moveImage.Width = 0.8 * moveButton.Height;
            fightImage.Width = 0.8 * fightButton.Height;
            buildImage.Width = 0.8 * buildButton.Height;

            collectImage.Height = 0.8 * collectButton.Width;
            moveImage.Height = 0.8 * moveButton.Width;
            fightImage.Height = 0.8 * fightButton.Width;
            buildImage.Height = 0.8 * buildButton.Width;

            actionMenu.Width = moveButton.Width + fightButton.Width + buildButton.Width + collectButton.Width + 0.03 * ActualWidth;
           
            materialsStack.Margin = new Thickness(levelBar.Width + actionMenu.Width + 0.02 * ActualWidth, 0, 0, 0);
            goldImage.Width = 0.3 * upperGrid.Height;
            stoneImage.Width = 0.3 * upperGrid.Height;
            treeImage.Width = 0.3 * upperGrid.Height;

            matsLabel.Margin = new Thickness(materialsStack.Margin.Left, 0.4 * upperGrid.Height, 0, 0);
            matsLabel.Width = 0.9 * upperGrid.Height;
            matsLabel.Height = 0.6 * upperGrid.Height;
            matsLabel.FontSize = matsLabel.Height / 2;
            
            materialsStack.Width = matsLabel.Width;
            Canvas.SetLeft(buildMenu, materialsStack.Margin.Left + materialsStack.Width + 0.02 * ActualWidth);
    

            hospitalButton.Width = 0.05 * upperGrid.Width;
            houseButton.Width = 0.05 * upperGrid.Width;
            barrackButton.Width = 0.05 * upperGrid.Width;
            hospitalButton.Height = upperGrid.Height;
            houseButton.Height = upperGrid.Height;
            barrackButton.Height = upperGrid.Height;

            barrackImage.Width = 0.046 * upperGrid.Width;
            barrackImage.Height= 0.9 * upperGrid.Height;

            houseImage.Width = 0.05 * upperGrid.Width;
            houseImage.Height = upperGrid.Height;

            hospitalImage.Width = 0.041 * upperGrid.Width;
            hospitalImage.Height = 0.8 * upperGrid.Height;


            hospitalButton.Margin = new Thickness(0.005 * ActualWidth, 0, 0, 0);
            houseButton.Margin = new Thickness(0.005 * ActualWidth, 0, 0, 0);

            barrackImage.Margin = new Thickness(0.077 * barrackImage.Width, 0, 0, 0);
            houseImage.Margin = new Thickness(0.087 * houseImage.Width, 0, 0, 0);
            hospitalImage.Margin = new Thickness(0.037 * hospitalImage.Width, -0.025 * hospitalImage.Height, 0, 0);

            Canvas.SetLeft(barrackMenu, materialsStack.Margin.Left + materialsStack.Width + 0.02 * ActualWidth);

            warrior.Width = 0.05 * upperGrid.Width;
            archer.Width = 0.05 * upperGrid.Width;
            rider.Width = 0.05 * upperGrid.Width;
            warrior.Height = upperGrid.Height;
            archer.Height = upperGrid.Height;
            rider.Height = upperGrid.Height;

            blackCircle1.Width = 0.062 * upperGrid.Width;
            blackCircle1.Height = 1.2 * upperGrid.Height;

            blackCircle2.Width = 0.062 * upperGrid.Width;
            blackCircle2.Height = 1.2 * upperGrid.Height;

            blackCircle3.Width = 0.062 * upperGrid.Width;
            blackCircle3.Height = 1.2 * upperGrid.Height;

            rider.Margin = new Thickness(0.005 * ActualWidth, 0, 0, 0);
            archer.Margin = new Thickness(0.005 * ActualWidth, 0, 0, 0);

            warriorImage.Width = 0.039 * ActualWidth;
            warriorImage.Height = 0.75 * upperGrid.Height;

            archerImage.Width = 0.044 * ActualWidth;
            archerImage.Height = 0.85 * upperGrid.Height;

            riderImage.Width = 0.9 * upperGrid.Height;
            riderImage.Height = 0.046 * ActualWidth;

            warriorImage.Margin = new Thickness(0.09 * warriorImage.Width, 0, 0, 0);
            archerImage.Margin = new Thickness(0.08 * archerImage.Width, 0, 0, 0);
            riderImage.Margin = new Thickness(0.03 * riderImage.Width, -0.02 * riderImage.Height, 0, 0);

            mainGrid.Margin = new Thickness(0, upperGrid.Height, 0, 0);
        }

        private void WindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            setUpperGrid();
            squareWidth = (ActualWidth - widthDifference) / board.Squares.GetLength(0);
            squareHeight = (mainGrid.Height - SystemParameters.CaptionHeight - SystemParameters.MenuBarHeight) / board.Squares.GetLength(1);
            layout();
            place(player);
            

        }
        private void MainWindow_PreviewMouseLeftButtonDown1(object sender, MouseButtonEventArgs e)
        {
            //getMouseLocation();
            //if (board.getObjectFromSquare(x, y) != null)
            //    Title = $"{board.getObjectFromSquare(x, y).GetType()}";
        }

        public void nextPlayer()
        {
            if (board.Players.FindIndex(a => a.Name == player.Name) == board.Players.Count - 1)
                player = board.Players[0];
            else
                player = board.Players[board.Players.FindIndex(a => a.Name == player.Name) + 1];
            if (player.Base.Health == 0)
            {
                End endWindow = new End(player);
                endWindow.Show();
            }

            board.nextMove(player);
            levelBar.Value = player.Exp;
            levelBar.Maximum = player.Level * 100;
            levelText.Text = Convert.ToString(player.Level);
            matsLabel.Content = player.Materials;
            place(player);
            chosenChanged();
        }

        public Player createPlayer(string name) { return new Player(name); }



        public void layout()
        {
            mainGrid.RowDefinitions.Clear();
            mainGrid.ColumnDefinitions.Clear();
            mainGrid.ShowGridLines = true;
            for (int i = 0; i < board.Squares.GetLength(0); i++)
            {
                ColumnDefinition c = new ColumnDefinition();
                c.Width = new GridLength(squareWidth);
                mainGrid.ColumnDefinitions.Add(c);
            }

            for (int i = 0; i < board.Squares.GetLength(1); i++)
            {
                RowDefinition r = new RowDefinition();
                r.Height = new GridLength(squareHeight);
                mainGrid.RowDefinitions.Add(r);
            }
        }

        public void getMouseLocation()
        {
            Point position = Mouse.GetPosition(this);
            x = (int)Math.Floor(position.X / squareWidth);
            y = (int)Math.Floor((position.Y - upperGrid.Height) / squareHeight);
            Title = $"{position.X} {position.Y}";
        }



        public void setImg(int i, int j, string url, string type, bool button_ = true, bool hightlight = false)
        {
            Image image = new Image();
            image.Width = squareWidth;
            image.Height = squareHeight;
            image.VerticalAlignment = VerticalAlignment.Center;
            image.HorizontalAlignment = HorizontalAlignment.Center;
            StackPanel stackPanel = new StackPanel();
            stackPanel.VerticalAlignment = VerticalAlignment.Center;
            stackPanel.HorizontalAlignment = HorizontalAlignment.Center;

            if (board.getObjectFromSquare(i, j) != null)
                image.ToolTip = board.getObjectFromSquare(i, j).ToString();


            stackPanel.Children.Add(image);
            if (button_)
            {
                Button button = new Button();
                button.Background = Brushes.Transparent;
                if (!hightlight)
                    button.BorderThickness = new Thickness(0);
                else
                {
                    button.BorderThickness = new Thickness(3);
                    button.BorderBrush = Brushes.Black;
                }

                button.Width = squareWidth;
                button.Height = squareHeight;
                button.Focusable = false;
                button.Content = stackPanel;

                //
                //button.ToolTip = board.getObjectFromSquare(i, j).ToString();
                mainGrid.Children.Add(button);
                Grid.SetColumn(button, i);
                Grid.SetRow(button, j);
                if (type == "character")
                    button.Click += new RoutedEventHandler(characterClick);
                if (type == "object")
                    button.Click += new RoutedEventHandler(objectClick);
                if (type == "barrack")
                    button.Click += new RoutedEventHandler(barrackClick);
            }

            else
            {
                mainGrid.Children.Add(stackPanel);
                Grid.SetColumn(stackPanel, i);
                Grid.SetRow(stackPanel, j);
            }
            BitmapImage bitmapImage = new BitmapImage(new Uri(url, UriKind.Relative));
            image.Source = bitmapImage;

        }

        public void chosenChanged()
        {
            chosenCharacter = null;
            chosenObject = null;
            chosenBuilding = null;
            buildMenu.Visibility = Visibility.Hidden;
            barrackMenu.Visibility = Visibility.Hidden;
            fightButton.IsEnabled = false;
            moveButton.IsEnabled = false;
            buildButton.IsEnabled = false;
            collectButton.IsEnabled = false;
            mainGrid.MouseDown -= new MouseButtonEventHandler(build);
            mainGrid.MouseDown -= new MouseButtonEventHandler(train);
            mainGrid.MouseDown -= new MouseButtonEventHandler(moveTo);
            mainGrid.MouseDown -= new MouseButtonEventHandler(fight);
            place(player);
        }

        public void optionChanged()
        {
            place(player);
            mainGrid.MouseDown -= new MouseButtonEventHandler(build);
            mainGrid.MouseDown -= new MouseButtonEventHandler(train);
            mainGrid.MouseDown -= new MouseButtonEventHandler(moveTo);
            mainGrid.MouseDown -= new MouseButtonEventHandler(fight);
            buildMenu.Visibility = Visibility.Hidden;
            barrackMenu.Visibility = Visibility.Hidden;

        }



        public void place(Player player)
        {
            mainGrid.Children.Clear();

            foreach (Game.Object obj in board.Objects)
                setImg(obj.X, obj.Y, obj.Image, obj.Type);

            foreach (Building building in board.Buildings.Where(a => a.Player.Name == player.Name))
                setImg(building.X, building.Y, building.Image, building.Type);

            foreach (Building building in board.Buildings.Where(a => a.Player.Name != player.Name))
                setImg(building.X, building.Y, building.Image, building.Type, false);

            foreach (Character character in board.Characters.Where(a => a.Player.Name == player.Name))
                setImg(character.X, character.Y, character.Image, "character");

            foreach (Character character in board.Characters.Where(a => a.Player.Name != player.Name))
                setImg(character.X, character.Y, character.Image, "character", false);
        }



        public void train(object sender, MouseEventArgs e)
        {
            getMouseLocation();
            if (board.isAvailable(x, y))
            {
                chosenCharacter.X = x;
                chosenCharacter.Y = y;
                try { board.addCharacter(chosenCharacter); }
                catch (Exception error)
                { MessageBox.Show(error.Message, "Impossible", MessageBoxButton.OK, MessageBoxImage.Exclamation); }
                chosenChanged();
                matsLabel.Content = Convert.ToString(player.Materials);
                mainGrid.MouseDown -= new MouseButtonEventHandler(train);
                barrackMenu.Visibility = Visibility.Hidden;
            }
        }
        public void createFighter(object sender, RoutedEventArgs e)
        {
            Point position = Mouse.GetPosition(this);
            if (position.X < ActualWidth * 0.462)
            {
                chosenCharacter = new Warrior(player);
                mainGrid.MouseDown += new MouseButtonEventHandler(train);
            }
            else if (position.X < ActualWidth * 0.517)
            {
                chosenCharacter = new Archer(player);
                mainGrid.MouseDown += new MouseButtonEventHandler(train);
            }
            else if (position.X < ActualWidth * 0.572)
            {
                chosenCharacter = new Rider(player);
                mainGrid.MouseDown += new MouseButtonEventHandler(train);
            }
            else { }
        }

        private void barrackClick(object sender, RoutedEventArgs e)
        {
            chosenChanged();
            barrackMenu.Visibility = Visibility.Visible;
            getMouseLocation();
            chosenBuilding = board.getObjectFromSquare(x, y) as Barrack;
            for (int i = 0; i < board.Squares.GetLength(0); i++)
                for (int j = 0; j < board.Squares.GetLength(1); j++)
                    if (board.distance(chosenBuilding.X, chosenBuilding.Y, i, j) < 2 && board.isAvailable(i, j))
                        setImg(i, j, $"/GUI;component/Resources/greenCircle.png", "", false);
        }

        public void chooseBuilding(object sender, RoutedEventArgs e)
        {
            Point position = Mouse.GetPosition(this);

            if (position.X < ActualWidth * 0.462)
            {
                chosenBuilding = new Barrack(player);
                mainGrid.MouseDown += new MouseButtonEventHandler(build);
            }
            else if (position.X < ActualWidth * 0.517)
            {
                chosenBuilding = new House(player);
                mainGrid.MouseDown += new MouseButtonEventHandler(build);
            }
            else if (position.X < ActualWidth * 0.572)
            {
                chosenBuilding = new Hospital(player);
                mainGrid.MouseDown += new MouseButtonEventHandler(build);
            }
            else { }

        }


        public void build(object sender, MouseEventArgs e)
        {
            getMouseLocation();

            if (board.isAvailable(x, y))
            {
                chosenBuilding.X = x;
                chosenBuilding.Y = y;

                try
                { board.addBuilding(chosenBuilding); }
                catch (Exception error)
                { MessageBox.Show(error.Message, "Impossible", MessageBoxButton.OK, MessageBoxImage.Exclamation); }

                chosenBuilding = null;
                matsLabel.Content = Convert.ToString(player.Materials);
                mainGrid.MouseDown -= new MouseButtonEventHandler(build);
                buildMenu.Visibility = Visibility.Hidden;
                place(player);
            }
        }

        private void objectClick(object sender, RoutedEventArgs e)
        {
            getMouseLocation();
            chosenObject = board.getObjectFromSquare(x, y) as Game.Object;

            if (canCollect && board.distance(chosenCharacter.X, chosenCharacter.Y, x, y) < 2)
            {
                chosenCharacter.collect(chosenObject);
                board.update();
                chosenChanged();
                canCollect = false;
                matsLabel.Content = Convert.ToString(player.Materials);
            }
        }

        public void characterClick(object sender, RoutedEventArgs r)
        {
            getMouseLocation();
            chosenChanged();
            chosenCharacter = board.getObjectFromSquare(x, y) as Character;
            setImg(x, y, chosenCharacter.Image, "character", true, true);
            if (chosenCharacter.Role == typeOfCharacter.builder)
            {
                buildButton.IsEnabled = true;
                collectButton.IsEnabled = true;
            }
            if (chosenCharacter.Role == typeOfCharacter.fighter || chosenCharacter.Role == typeOfCharacter.wrecker)
                fightButton.IsEnabled = true;

            moveButton.IsEnabled = true;
            getMouseLocation();
        }



        public void moveTo(object sender, MouseEventArgs e)
        {
            getMouseLocation();
            board.move(chosenCharacter, x, y);
            if (board.distance(chosenCharacter.X, chosenCharacter.Y, x, y) == 0)
            {
                nextPlayer();
                mainGrid.MouseDown -= new MouseButtonEventHandler(moveTo);
            }
        }


        private void moveButton_Click(object sender, RoutedEventArgs e)
        {
            optionChanged();
            for (int i = 0; i < board.Squares.GetLength(0); i++)
                for (int j = 0; j < board.Squares.GetLength(1); j++)
                    if (board.distance(chosenCharacter.X, chosenCharacter.Y, i, j) <= chosenCharacter.Leap && board.isAvailable(i, j))
                        setImg(i, j, "/GUI;component/Resources/greenCircle.png", "", false);


            mainGrid.MouseDown += new MouseButtonEventHandler(moveTo);
        }

        public void fight(object sender, MouseEventArgs e)
        {
            getMouseLocation();
            if (board.Buildings.Find(a => a.X == x && a.Y == y && board.distance(chosenCharacter.X, chosenCharacter.Y, x, y) <= chosenCharacter.Range && a.Player != player) != null)
            {
                chosenCharacter.Strike(board.getObjectFromSquare(x, y) as Building);
                mainGrid.MouseDown -= new MouseButtonEventHandler(fight);
                nextPlayer();
            }

            if (board.Characters.Find(a => a.X == x && a.Y == y && board.distance(chosenCharacter.X, chosenCharacter.Y, x, y) <= chosenCharacter.Range && a.Player != player && a.GetType() != typeof(Medic)) != null)
            {
                chosenCharacter.Strike(board.getObjectFromSquare(x, y) as Character);
                mainGrid.MouseDown -= new MouseButtonEventHandler(fight);
                nextPlayer();
            }
        }


        private void fightButton_Click(object sender, RoutedEventArgs e)
        {
            optionChanged();
            canFight = true;
            for (int i = 0; i < board.Squares.GetLength(0); i++)
                for (int j = 0; j < board.Squares.GetLength(1); j++)
                    if (board.distance(chosenCharacter.X, chosenCharacter.Y, i, j) <= chosenCharacter.Range && (board.Characters.Find(a => a.X == i && a.Y == j && a.Player != player && a.GetType() != typeof(Medic)) != null || board.Buildings.Find(a => a.X == i && a.Y == j && a.Player != player) != null))
                        setImg(i, j, "/GUI;component/Resources/greenCircle.png", "character", false);

            mainGrid.MouseDown += new MouseButtonEventHandler(fight);

        }

        private void buildButton_Click(object sender, RoutedEventArgs e)
        {
            optionChanged();
            for (int i = 0; i < board.Squares.GetLength(0); i++)
                for (int j = 0; j < board.Squares.GetLength(1); j++)
                    if (board.distance(chosenCharacter.X, chosenCharacter.Y, i, j) < 2 && board.isAvailable(i, j))
                        setImg(i, j, "/GUI;component/Resources/greenCircle.png", "", false);

            buildMenu.Visibility = Visibility.Visible;
        }



        private void collectButton_Click(object sender, RoutedEventArgs e)
        {
            optionChanged();
            canCollect = true;
            for (int i = 0; i < board.Squares.GetLength(0); i++)
                for (int j = 0; j < board.Squares.GetLength(1); j++)
                    if (board.getObjectFromSquare(i, j) != null && board.distance(chosenCharacter.X, chosenCharacter.Y, i, j) < 2 && board.getObjectFromSquare(i, j).GetType().IsSubclassOf(typeof(Game.Object)))
                        setImg(i, j, "/GUI;component/Resources/greenCircle.png", "object");

        }


    }
}