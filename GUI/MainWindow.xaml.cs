using System;
using System.Collections;
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
        Building chosenBuilding;
        int x, y;
        double squareWidth;
        double squareHeight;
        double widthDifference;
        double maxMenuWidth;
        double maxMenuHeight;
        Dictionary<Panel, Thickness> panels;
        ArrayList labels, images, buttons;

        public MainWindow(Board board_)
        {
            InitializeComponent();

            board = board_;

            panels = new Dictionary<Panel, Thickness>() { { upperGrid, upperGrid.Margin }, { levelPanel, levelPanel.Margin }, { actualPlayer, actualPlayer.Margin }, { materialsGrid, materialsGrid.Margin }, { actionMenu, actionMenu.Margin }, { buildMenu, buildMenu.Margin }, { barrackMenu, barrackMenu.Margin }, { armoryMenu, armoryMenu.Margin } };
            images = new ArrayList() { blackCircle7, soldierImage, farmImage, nextImage, levelImage, buildImage, fightImage, moveImage, collectImage, goldImage, stoneImage, treeImage, barrackImage, houseImage, blackCircle1, blackCircle2, blackCircle3, blackCircle4, blackCircle5, blackCircle6, warriorImage, archerImage, armoryImage, riderImage, batteringRamImage, catapultImage, cannonImage, mineImage, portImage };
            buttons = new ArrayList() { soldier, farmButton, nextButton, moveButton, collectButton, fightButton, buildButton, houseButton, barrackButton, warrior, archer, rider, batteringRam, catapult, cannon, mineButton, portButton, armoryButton };
            labels = new ArrayList() { levelTextbox, levelText, matsLabel, playerName };

            maxMenuHeight = SystemParameters.MaximizedPrimaryScreenHeight / 10;
            maxMenuWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            widthDifference = SystemParameters.MaximizedPrimaryScreenWidth - SystemParameters.VirtualScreenWidth;

            this.SizeChanged += WindowSizeChanged;
            this.WindowState = WindowState.Maximized;

            player = board.Turn;
            setPlayer();

            barrackButton.ToolTip = new Barrack(player).Tip();
            houseButton.ToolTip = new House(player).Tip();
            farmButton.ToolTip = new Farm(player).Tip();
            portButton.ToolTip = new Port(player).Tip();
            mineButton.ToolTip = new Mine(player).Tip();
            armoryButton.ToolTip = new Armory(player).Tip();

            warrior.ToolTip = new Warrior(player).Tip();
            archer.ToolTip = new Archer(player).Tip();
            rider.ToolTip = new Rider(player).Tip();
            soldier.ToolTip = new Soldier(player).Tip();

            batteringRam.ToolTip = new BatteringRam(player).Tip();
            catapult.ToolTip = new BatteringRam(player).Tip();
            cannon.ToolTip = new BatteringRam(player).Tip();
        }

        public void t(double x)
        { Title = $"{x}"; }

        public void setTextLabel(Label label)
        {
            double size = label.Width * label.Height;
            label.Width = label.MaxWidth / maxMenuWidth * upperGrid.Width;
            label.Height = label.MaxHeight / maxMenuHeight * upperGrid.Height;
            label.FontSize *= 1 + ((label.Width * label.Height / size) - 1) * 0.7;
        }

        public void setUpperGrid()
        {
            upperGrid.Height = 0.1 * ActualHeight;
            upperGrid.Width = ActualWidth;
            mainGrid.Height = 0.9 * ActualHeight;
            mainGrid.Width = ActualWidth;

            foreach (Panel panel in panels.Keys)
                panel.Margin = new Thickness(panels[panel].Left / maxMenuWidth * upperGrid.Width, panels[panel].Top / maxMenuHeight * upperGrid.Height, 0, 0);

            foreach (Label label in labels)
                setTextLabel(label);

            levelBar.Width = levelBar.MaxWidth / maxMenuWidth * upperGrid.Width;
            levelBar.Height = levelBar.MaxHeight / maxMenuHeight * upperGrid.Height;
            levelBar.Margin = new Thickness(25 / maxMenuWidth * upperGrid.Width, 45 / maxMenuHeight * upperGrid.Height, 0, 0);

            levelTextbox.Margin = new Thickness(70 / maxMenuWidth * upperGrid.Width, 0, 0, 0);

            foreach (Button i in buttons)
            {
                i.Height = i.MaxHeight / maxMenuHeight * upperGrid.Height;
                i.Width = i.MaxWidth / maxMenuWidth * upperGrid.Width;
            }

            foreach (Image i in images)
            {
                i.Width = i.MaxWidth / maxMenuWidth * upperGrid.Width;
                i.Height = i.MaxHeight / maxMenuHeight * upperGrid.Height;
            }

            matsLabel.Margin = new Thickness(0, 40 / maxMenuHeight * upperGrid.Height, 0, 0);

            mainGrid.Margin = new Thickness(0, upperGrid.Height, 0, 0);
        }

        private void WindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            setUpperGrid();
            squareWidth = (ActualWidth - widthDifference) / board.Squares.GetLength(0);
            // caption bar
            squareHeight = (mainGrid.Height - SystemParameters.CaptionHeight - SystemParameters.MenuBarHeight) / board.Squares.GetLength(1);
            layout();
            place(player);
        }

        public void nextPlayer()
        {
            foreach (Player player_ in board.Players)
            {
                if (player_.Base.Health == 0)
                {
                    board.Characters.RemoveAll(a => a.Player.Equals(player_));
                    board.Buildings.RemoveAll(a => a.Player.Equals(player_));
                    board.Players.Remove(player_);

                    if (board.Players.Count == 1)
                    {
                        End endWindow = new End(player_, true);
                        bool? response = endWindow.ShowDialog();
                        if (response == true)
                        {
                            StartWindow window = new StartWindow();
                            window.Show();
                            this.Close();
                        }
                    }
                    else
                    {
                        End endWindow = new End(player_);
                        endWindow.ShowDialog();
                    }
                    break;
                }
            }


            if (board.Players.FindIndex(a => a.Equals(player)) == board.Players.Count - 1)
                player = board.Players[0];
            else
                player = board.Players[board.Players.FindIndex(a => a.Equals(player)) + 1];


            board.nextMove(player);
            board.serialize("board.bin");
            setPlayer();
            chosenChanged();

        }

        public void setPlayer()
        {
            levelBar.ToolTip = $"{player.Exp}/{player.Level * 100}";
            levelBar.Value = player.Exp;
            levelBar.Maximum = player.Level * 100;
            levelText.Content = Convert.ToString(player.Level);
            matsLabel.Content = player.Materials;

            if (player.Level >= 2)
                barrackButton.IsEnabled = true;
            if (player.Level >= 3)
                houseButton.IsEnabled = true;
            if (player.Level >= 4)
                armoryButton.IsEnabled = true;
            if (player.Level >= 5)
                portButton.IsEnabled = true;
            if (player.Level >= 6)
                mineButton.IsEnabled = true;
            if (player.Level >= 8)
                farmButton.IsEnabled = true;

            place(player);
            playerName.Content = player.Name;

            if (player.Color == "Blue")
                playerName.Foreground = new SolidColorBrush(Color.FromRgb((byte)0, (byte)70, (byte)204));

            else if (player.Color == "Red")
                playerName.Foreground = Brushes.Red;

            else if (player.Color == "Yellow")
                playerName.Foreground = new SolidColorBrush(Color.FromRgb((byte)204, (byte)180, (byte)0));

            else
                playerName.Foreground = Brushes.Purple;

        }

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
        }

        public void setImg(int i, int j, string url, string type = "", bool button_ = true, bool border_ = false, string color = "")
        {
            Border border = new Border();
            border.BorderThickness = new Thickness(2);
            if (color == "red")
                border.BorderBrush = Brushes.Red;
            if (color == "green")
                border.BorderBrush = Brushes.LawnGreen;
            if (color == "black")
                border.BorderBrush = Brushes.Black;
            if (!border_)
                border.BorderThickness = new Thickness(0);

            StackPanel stackPanel = new StackPanel();
            stackPanel.VerticalAlignment = VerticalAlignment.Center;
            stackPanel.HorizontalAlignment = HorizontalAlignment.Center;
            Image image = new Image();
            image.Width = squareWidth;
            image.Height = squareHeight;

            ProgressBar pb = new ProgressBar();
            pb.Background = Brushes.Green;
            pb.Width = squareWidth;
            pb.Height = 0.2 * squareHeight;
            pb.Maximum = 100;
            pb.Value = 0;

            Button button = new Button();
            button.Background = Brushes.Transparent;
            button.Width = squareWidth;
            button.Height = squareHeight;

            if (button_)
            {
                if (type == "character")
                    button.Click += new RoutedEventHandler(characterClick);

                if (type == "barrack")
                    button.Click += new RoutedEventHandler(barrackClick);

                if (type == "armory")
                    button.Click += new RoutedEventHandler(armoryClick);

                border.Child = button;
                button.Content = stackPanel;
                mainGrid.Children.Add(border);
                Grid.SetColumn(border, i);
                Grid.SetRow(border, j);
            }
            else
            {
                border.Child = stackPanel;
                mainGrid.Children.Add(border);
                Grid.SetColumn(border, i);
                Grid.SetRow(border, j);
            }
            if (type == "unknown")
                stackPanel.Background = Brushes.DarkGray;

            else if (board.getObjectFromSquare(i, j) != null && board.getObjectFromSquare(i, j).GetType().IsSubclassOf(typeof(Character)))
            {
                pb.Maximum = board.Characters.Find(a => a.X == i && a.Y == j).MaxHealth;
                pb.Value = board.Characters.Find(a => a.X == i && a.Y == j).Health;
                stackPanel.Children.Add(pb);
                image.Width = 0.8 * squareWidth;
                image.Height = 0.8 * squareHeight;
            }

            else if (board.getObjectFromSquare(i, j) != null && board.getObjectFromSquare(i, j).GetType().IsSubclassOf(typeof(Building)))
            {
                pb.Maximum = board.Buildings.Find(a => a.X == i && a.Y == j).MaxHealth;
                pb.Value = board.Buildings.Find(a => a.X == i && a.Y == j).Health;
                stackPanel.Children.Add(pb);
                image.Width = 0.8 * squareWidth;
                image.Height = 0.8 * squareHeight;
            }

            if (pb.Value / pb.Maximum > 0.8)
                pb.Foreground = Brushes.LawnGreen;
            else if (pb.Value / pb.Maximum > 0.5)
                pb.Foreground = Brushes.Yellow;
            else if (pb.Value / pb.Maximum > 0.2)
                pb.Foreground = Brushes.Orange;
            else
                pb.Foreground = Brushes.Red;

            if (board.getObjectFromSquare(i, j) != null)
                image.ToolTip = board.getObjectFromSquare(i, j).ToString();
            else if (board.Map[i, j].Type != typeOfTerrain.plane)
                image.ToolTip = board.Map[i, j].ToString();


            stackPanel.Children.Add(image);
            BitmapImage bitmapImage = new BitmapImage(new Uri(url, UriKind.Relative));
            image.Source = bitmapImage;

        }

        public void place(Player player)
        {
            mainGrid.Children.Clear();

            for (int i = 0; i < board.Map.GetLength(0); i++)
                for (int j = 0; j < board.Map.GetLength(1); j++)
                {
                    if (player.Charted[i, j])
                        setImg(i, j, board.Map[i, j].Image, "", false);
                    else
                        setImg(i, j, "", "unknown", false);

                }

            foreach (Game.Object obj in board.Objects)
            {
                if (player.Charted[obj.X, obj.Y])
                    setImg(obj.X, obj.Y, obj.Image, "", false);
            }

            foreach (Building building in board.Buildings)
            {
                if (player.Charted[building.X, building.Y])
                {
                    if (building.Player.Equals(player))
                        setImg(building.X, building.Y, building.Image, building.Type);
                    else
                        setImg(building.X, building.Y, building.Image, building.Type, false);
                }
            }

            foreach (Character character in board.Characters)
            {
                if (player.Charted[character.X, character.Y])
                {
                    if (chosenCharacter != null && character.Equals(chosenCharacter))
                        setImg(chosenCharacter.X, chosenCharacter.Y, chosenCharacter.Image, "character", true, true, "black");
                    else if (character.Player.Equals(player))
                        setImg(character.X, character.Y, character.Image, "character");
                    else
                        setImg(character.X, character.Y, character.Image, "character", false);
                }
            }


        }

        public void chosenChanged()
        {
            chosenCharacter = null;
            chosenBuilding = null;
            buildMenu.Visibility = Visibility.Hidden;
            barrackMenu.Visibility = Visibility.Hidden;
            armoryMenu.Visibility = Visibility.Hidden;
            fightButton.IsEnabled = false;
            moveButton.IsEnabled = false;
            buildButton.IsEnabled = false;
            collectButton.IsEnabled = false;
            mainGrid.MouseDown -= new MouseButtonEventHandler(build);
            mainGrid.MouseDown -= new MouseButtonEventHandler(train);
            mainGrid.MouseDown -= new MouseButtonEventHandler(moveTo);
            mainGrid.MouseDown -= new MouseButtonEventHandler(fight);
            mainGrid.MouseDown -= new MouseButtonEventHandler(collect);

            place(player);
        }

        public void optionChanged()
        {
            place(player);
            chooseCharacter(chosenCharacter);
            mainGrid.MouseDown -= new MouseButtonEventHandler(build);
            mainGrid.MouseDown -= new MouseButtonEventHandler(train);
            mainGrid.MouseDown -= new MouseButtonEventHandler(moveTo);
            mainGrid.MouseDown -= new MouseButtonEventHandler(fight);
            mainGrid.MouseDown -= new MouseButtonEventHandler(collect);
            buildMenu.Visibility = Visibility.Hidden;
            barrackMenu.Visibility = Visibility.Hidden;
            armoryMenu.Visibility = Visibility.Hidden;
        }

        public void createFighter(object sender, RoutedEventArgs e)
        {
            Point position = Mouse.GetPosition(this);

            if (position.X < warrior.PointToScreen(new Point(0d, 0d)).X + warrior.Width)
                chosenCharacter = new Warrior(player);

            else if (position.X < archer.PointToScreen(new Point(0d, 0d)).X + archer.Width)
                chosenCharacter = new Archer(player);

            else if (position.X < rider.PointToScreen(new Point(0d, 0d)).X + rider.Width)
                chosenCharacter = new Rider(player);
            else
                chosenCharacter = new Soldier(player);

            mainGrid.MouseDown += new MouseButtonEventHandler(train);

            for (int i = 0; i < board.Squares.GetLength(0); i++)
                for (int j = 0; j < board.Squares.GetLength(1); j++)
                    if (board.canTrain(chosenBuilding, chosenCharacter, i, j))
                        setImg(i, j, $"/GUI;component/Resources/greenCircle.png", "", false);

        }

        public void createMachine(object sender, RoutedEventArgs e)
        {
            Point position = Mouse.GetPosition(this);
            if (position.X < batteringRam.PointToScreen(new Point(0d, 0d)).X + batteringRam.Width)
                chosenCharacter = new BatteringRam(player);

            else if (position.X < catapult.PointToScreen(new Point(0d, 0d)).X + catapult.Width)
                chosenCharacter = new Catapult(player);

            else
                chosenCharacter = new Cannon(player);

            mainGrid.MouseDown += new MouseButtonEventHandler(train);

            for (int i = 0; i < board.Squares.GetLength(0); i++)
                for (int j = 0; j < board.Squares.GetLength(1); j++)
                    if (board.canTrain(chosenBuilding, chosenCharacter, i, j))
                        setImg(i, j, $"/GUI;component/Resources/greenCircle.png", "", false);

        }

        public void chooseBuilding(object sender, RoutedEventArgs e)
        {
            place(player);
            Point position = Mouse.GetPosition(this);


            if (position.X < barrackButton.PointToScreen(new Point(0d, 0d)).X + barrackButton.Width)
                chosenBuilding = new Barrack(player);

            else if (position.X < houseButton.PointToScreen(new Point(0d, 0d)).X + houseButton.Width)
                chosenBuilding = new House(player);

            else if (position.X < armoryButton.PointToScreen(new Point(0d, 0d)).X + armoryButton.Width)
                chosenBuilding = new Armory(player);

            else if (position.X < portButton.PointToScreen(new Point(0d, 0d)).X + portButton.Width)
                chosenBuilding = new Port(player);

            else if (position.X < mineButton.PointToScreen(new Point(0d, 0d)).X + mineButton.Width)
                chosenBuilding = new Mine(player);

            else
                chosenBuilding = new Farm(player);

            mainGrid.MouseDown += new MouseButtonEventHandler(build);

            for (int i = 0; i < board.Squares.GetLength(0); i++)
                for (int j = 0; j < board.Squares.GetLength(1); j++)
                    if (board.canBuild(chosenCharacter, chosenBuilding, i, j))
                        setImg(i, j, $"", "", false, true, "green");

        }

        public void chooseCharacter(Character character)
        {
            chosenChanged();
            chosenCharacter = character;
            place(player);


            if (chosenCharacter.Role == typeOfCharacter.builder)
            {
                buildButton.IsEnabled = true;
                collectButton.IsEnabled = true;
            }
            if (chosenCharacter.Role == typeOfCharacter.fighter || chosenCharacter.Role == typeOfCharacter.wrecker)
                fightButton.IsEnabled = true;

            moveButton.IsEnabled = true;

        }

        private void barrackClick(object sender, RoutedEventArgs e)
        {
            chosenChanged();
            barrackMenu.Visibility = Visibility.Visible;
            getMouseLocation();
            chosenBuilding = board.getObjectFromSquare(x, y) as Barrack;
            setImg(chosenBuilding.X, chosenBuilding.Y, chosenBuilding.Image, chosenBuilding.Type, true, true, "black");

        }

        private void armoryClick(object sender, RoutedEventArgs e)
        {

            chosenChanged();
            armoryMenu.Visibility = Visibility.Visible;
            getMouseLocation();
            chosenBuilding = board.getObjectFromSquare(x, y) as Armory;
            setImg(chosenBuilding.X, chosenBuilding.Y, chosenBuilding.Image, chosenBuilding.Type, true, true, "black");
        }

        public void characterClick(object sender, RoutedEventArgs r)
        {
            getMouseLocation();
            chooseCharacter(board.getObjectFromSquare(x, y) as Character);
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
            else
                place(player);
        }

        public void train(object sender, MouseEventArgs e)
        {
            getMouseLocation();
            if (board.canTrain(chosenBuilding, chosenCharacter, x, y))
            {
                chosenCharacter.X = x;
                chosenCharacter.Y = y;
                try
                {
                    board.addCharacter(chosenCharacter);

                    for (int i = 0; i < board.Squares.GetLength(0); i++)
                        for (int j = 0; j < board.Squares.GetLength(1); j++)
                            if (board.distance(x, y, i, j) < 2)
                                player.Charted[i, j] = true;

                    mainGrid.MouseDown -= new MouseButtonEventHandler(train);
                    chosenCharacter = null;

                }
                catch (Exception error)
                { MessageBox.Show(error.Message, "Impossible", MessageBoxButton.OK, MessageBoxImage.Exclamation); }

                matsLabel.Content = Convert.ToString(player.Materials);
                mainGrid.MouseDown -= new MouseButtonEventHandler(train);
                place(player);
            }
            else
            {
                place(player);

            }
            setImg(chosenBuilding.X, chosenBuilding.Y, chosenBuilding.Image, chosenBuilding.Type, true, true, "black");
        }

        public void build(object sender, MouseEventArgs e)
        {
            getMouseLocation();

            if (board.canBuild(chosenCharacter, chosenBuilding, x, y))
            {
                chosenBuilding.X = x;
                chosenBuilding.Y = y;

                try
                {
                    board.addBuilding(chosenBuilding);
                    board.Map[x, y] = new Plane();
                    for (int i = 0; i < board.Squares.GetLength(0); i++)
                        for (int j = 0; j < board.Squares.GetLength(1); j++)
                            if (board.distance(x, y, i, j) < 2)
                                player.Charted[i, j] = true;

                }
                catch (Exception error)
                { MessageBox.Show(error.Message, "Impossible", MessageBoxButton.OK, MessageBoxImage.Exclamation); }

                chosenBuilding = null;
                matsLabel.Content = Convert.ToString(player.Materials);
                mainGrid.MouseDown -= new MouseButtonEventHandler(build);
            }
            place(player);
        }

        public void fight(object sender, MouseEventArgs e)
        {
            getMouseLocation();

            if (board.canFight(chosenCharacter, x, y) && board.getObjectFromSquare(x, y).GetType().IsSubclassOf(typeof(Building)))
            {
                chosenCharacter.Strike(board.getObjectFromSquare(x, y) as Building);
                mainGrid.MouseDown -= new MouseButtonEventHandler(fight);
                nextPlayer();
            }
            else if (board.canFight(chosenCharacter, x, y) && board.getObjectFromSquare(x, y).GetType().IsSubclassOf(typeof(Character)))
            {
                chosenCharacter.Strike(board.getObjectFromSquare(x, y) as Character);
                mainGrid.MouseDown -= new MouseButtonEventHandler(fight);
                nextPlayer();
            }
            else
                place(player);

        }

        public void collect(object sender, MouseEventArgs e)
        {
            getMouseLocation();
            if (board.canCollect(chosenCharacter, x, y))
            {
                chosenCharacter.collect(board.getObjectFromSquare(x, y) as Game.Object);
                mainGrid.MouseDown -= new MouseButtonEventHandler(collect);
                board.update();
                matsLabel.Content = Convert.ToString(player.Materials);
            }
            place(player);
        }

        private void moveButton_Click(object sender, RoutedEventArgs e)
        {
            optionChanged();
            for (int i = 0; i < board.Squares.GetLength(0); i++)
                for (int j = 0; j < board.Squares.GetLength(1); j++)
                    if (board.canMove(chosenCharacter, i, j))
                        setImg(i, j, "/GUI;component/Resources/greenCircle.png", "", false);

            mainGrid.MouseDown += new MouseButtonEventHandler(moveTo);
        }

        private void buildButton_Click(object sender, RoutedEventArgs e)
        {
            optionChanged();
            buildMenu.Visibility = Visibility.Visible;
        }

        private void fightButton_Click(object sender, RoutedEventArgs e)
        {
            optionChanged();

            for (int i = 0; i < board.Squares.GetLength(0); i++)
                for (int j = 0; j < board.Squares.GetLength(1); j++)
                    if (board.canFight(chosenCharacter, i, j))
                        setImg(i, j, "", "", false, true, "red");

            mainGrid.MouseDown += new MouseButtonEventHandler(fight);
        }

        private void collectButton_Click(object sender, RoutedEventArgs e)
        {
            optionChanged();
            for (int i = 0; i < board.Squares.GetLength(0); i++)
                for (int j = 0; j < board.Squares.GetLength(1); j++)
                    if (board.canCollect(chosenCharacter, i, j))
                        setImg(i, j, "", "", false, true, "green");

            mainGrid.MouseDown += new MouseButtonEventHandler(collect);

        }

        private void nextButton_Click(object sender, RoutedEventArgs e) { nextPlayer(); }


    }
}