using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Game
{
    public class Board
    {
        List<Building> buildings = new List<Building>();
        List<Character> characters = new List<Character>();
        List<Object> objects = new List<Object>();
        List<Player> players = new List<Player>();
        int height;
        int width;
        bool[,] squares;

        public Board(int width, int height)
        {
            Width = width;
            Height = height;
            squares = new bool[Width, Height];
            for (int i = 0; i < 100; i++)
                generateObject();
        }

        public object getObjectFromSquare(int x, int y)
        {
            if (Characters.Find(a => a.X == x && a.Y == y) != null)
            { return Characters.Find(a => a.X == x && a.Y == y); }
            else if (Buildings.Find(a => a.X == x && a.Y == y) != null)
            { return Buildings.Find(a => a.X == x && a.Y == y); }
            else if (Objects.Find(a => a.X == x && a.Y == y) != null)
            { return Objects.Find(a => a.X == x && a.Y == y); }
            else return null;

        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 50; j++)
                {
                    var obj = getObjectFromSquare(j, i);
                    if (obj != null)
                    {
                        if (j == 49)
                            sb.Append($"{obj.GetType().ToString()[5..]}");
                        else
                            sb.Append($"{obj.GetType().ToString()[5..]},");
                    }
                    else
                    {
                        if (j == 49)
                            sb.Append("*");
                        else
                            sb.Append("*,");
                    }
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public bool[,] Squares { get => squares; set => squares = value; }
        public List<Player> Players { get => players; set => players = value; }
        public List<Building> Buildings { get => buildings; set => buildings = value; }
        public List<Character> Characters { get => characters; set => characters = value; }
        public List<Object> Objects { get => objects; set => objects = value; }
        public int Height { get => height; set => height = value; }
        public int Width { get => width; set => width = value; }

        public void move(Character character, int x, int y)
        {
            if (isAvailable(x, y) && character.Leap >= distance(character.X, character.Y, x, y))
            {
                Squares[character.X, character.Y] = false;
                character.X = x;
                character.Y = y;
                Squares[x, y] = true;
            }
        }


        public void generateObject()
        {
            int x, y;
            Random random = new Random();
            int number = random.Next(11);
            do
            {
                x = random.Next(1, Width - 1);
                y = random.Next(1, Height - 1);
            } while (!isAvailable(x, y));

            if (number < 5)
                addObject(new Tree(x, y));
            else if (number <= 8 && number >= 6)
                addObject(new Stone(x, y));
            else
                addObject(new Gold(x, y));


            Squares[x, y] = true;
        }


        public bool isAvailable(int x, int y)
        {
            if (x > Width || x < 0 || y > Height || y < 0)
                return false;
            return !this.Squares[x, y];
        }

        public void addPlayer(Player player)
        {
            if (Players.Where(a => a.Name == player.Name).ToList().Count == 0)
            {
                if (Players.Count == 0)
                {
                    this.Players.Add(player);
                    player.Number = 1;
                    player.Base = new Base(player, 0, 0);
                    addBuilding(player.Base);
                    this.addCharacter(new Wanderer(player, 0, 1));
                }
                else if (Players.Count == 1)
                {
                    this.Players.Add(player);
                    player.Number = 2;
                    player.Base = new Base(player, Width - 1, Height - 1);
                    addBuilding(player.Base);
                    this.addCharacter(new Wanderer(player, Width - 1, Height - 2));
                }
                update();
            }
        }

        public void update()
        {
            foreach (Building building in Buildings.Where(a => a.Health == 0))
                Squares[building.X, building.Y] = false;

            foreach (Building building in Buildings.Where(a => a.Health != 0))
                Squares[building.X, building.Y] = true;

            Buildings.RemoveAll(a => a.Health == 0);

            foreach (Character character in Characters.Where(a => a.Health == 0))
                Squares[character.X, character.Y] = false;

            foreach (Character character in Characters.Where(a => a.Health != 0))
                Squares[character.X, character.Y] = true;

            Characters.RemoveAll(a => a.Health == 0);

            foreach (Object object_ in Objects.Where(a => a.Collected))
                Squares[object_.X, object_.Y] = false;

            foreach (Object object_ in Objects.Where(a => !a.Collected))
                Squares[object_.X, object_.Y] = true;

            Objects.RemoveAll(a => a.Collected);

            using (StreamWriter writer = new StreamWriter("board.csv"))
                writer.Write(ToString());

        }
        public void addObject(Object object_)
        {
            if (isAvailable(object_.X, object_.Y))
            {
                this.Objects.Add(object_);
                update();
            }
        }

        public void addBuilding(Building building)
        {
            if (isAvailable(building.X, building.Y))
            {
                if (building.Player.Level < building.Min_level)
                    throw new Exception($"Minimum level to build {building.Type} is {building.Min_level}");
                if (building.MaterialsNeeded > building.Player.Materials)
                    throw new Exception($"Minimum materials to build {building.Type} is {building.MaterialsNeeded}");

                this.Buildings.Add(building);
                building.Player.Materials -= building.MaterialsNeeded;
                update();
            }
        }

        public void addCharacter(Character character)
        {
            if (isAvailable(character.X, character.Y))
            {
                if (character.MaterialsNeeded > character.Player.Materials)
                    throw new Exception($"Minimum meterials to build {character.Type} is {character.MaterialsNeeded}");

                this.Characters.Add(character);
                character.Player.Materials -= character.MaterialsNeeded;
                update();
            }
        }

        public double distance(int x1, int y1, int x2, int y2) { return Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2)); }
    
        public void nextMove(Player player)
        {
            foreach (Building building in Buildings.Where(a => a.Player.Name == player.Name && a.Exp != 0))
                player.Exp += building.Exp;

            player.nextLevel();
            update();
        }

    }
}
