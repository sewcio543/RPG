using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Xml.Serialization;

namespace Game
{
	//
    // class board contains all the characters, buildings, players and map of the game
    [Serializable]
    public class Board
    {
        List<Building> buildings = new List<Building>();
        List<Character> characters = new List<Character>();
        List<Object> objects = new List<Object>();
        List<Player> players = new List<Player>();
        // size of the board
        int height;
        int width;
        // 2-D board
        bool[,] squares;
        // map with different terrains of the same size as board
        Terrain[,] map;
        // player, who has the move
        Player turn;

        // constructors
        public Board() { }
        public Board(int width, int height)
        {
            Width = width;
            Height = height;
            squares = new bool[Width, Height];
            map = new Terrain[Width, Height];
            // generating 10% of map as objects
            generateObjects(width * height / 10);
            // randomly generated terrain
            generateMap();
        }

        // method returns object placed on specific square of the board
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

        // map is generated at random, with proportions:
        // plane: 0.75, mountains: 0.1, water: 0.1, field: 0.05
        public void generateMap()
        {
            for (int i = 0; i < Map.GetLength(0); i++)
                for (int j = 0; j < Map.GetLength(1); j++)
                    Map[i, j] = new Plane();

            int x, y;
            int size = width * height;
            Random random = new Random();

            for (int i = 0; i < size * 0.1; i++)
            {
                do
                {
                    x = random.Next(1, Width - 1);
                    y = random.Next(1, Height - 1);
                } while (!isAvailable(x, y));
                Map[x, y] = new Mountain();
            }

            for (int i = 0; i < size * 0.1; i++)
            {
                do
                {
                    x = random.Next(1, Width - 1);
                    y = random.Next(1, Height - 1);
                } while (!isAvailable(x, y));
                Map[x, y] = new Water();
            }

            for (int i = 0; i < size * 0.05; i++)
            {
                do
                {
                    x = random.Next(1, Width - 1);
                    y = random.Next(1, Height - 1);
                } while (!isAvailable(x, y));
                Map[x, y] = new Field();
            }

        }

        // objects are generated at random, available squares
        public void generateObjects(int amount)
        {
            int x, y, number;
            Random random = new Random();
            for (int i = 0; i < amount; i++)
            {
                number = random.Next(11);
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
        }

        // text format of the board
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

        // move method, changes scharacter's co-ordinates if it's a legal move
        public void move(Character character, int x, int y)
        {
            if (canMove(character, x, y))
            {

                Squares[character.X, character.Y] = false;
                character.X = x;
                character.Y = y;
                Squares[x, y] = true;

                // new land can be discovered around a character
                for (int i = 0; i < Squares.GetLength(0); i++)
                    for (int j = 0; j < Squares.GetLength(1); j++)
                        if (distance(character.X, character.Y, i, j) < 2)
                            character.Player.Charted[i, j] = true;
            }
        }

        // method checks every relevant condition and returns whether the character can move to the specific square
        public bool canMove(Character character, int x, int y)
        {
            return distance(character.X, character.Y, x, y) <= character.Leap && isAvailable(x, y) && Map[x, y].Type == typeOfTerrain.plane && character.Player.Charted[x, y];
        }

        // method checks every relavant condition and returns whether the character can build the building in the specific square
        public bool canBuild(Character character, Building building, int x, int y)
        {
            return character.Role == typeOfCharacter.builder && character.Player.Charted[x, y] && distance(character.X, character.Y, x, y) < 2 && isAvailable(x, y) && Map[x, y].build(building);
        }

        // method checks every relavant condition and returns whether the character can fight with obejct in the specific square
        public bool canFight(Character character, int x, int y)
        {
            if (!character.Player.Charted[x, y])
                return false;
            if (character.Role == typeOfCharacter.wrecker)
                return distance(character.X, character.Y, x, y) <= character.Range && (Buildings.Find(building => building.X == x && building.Y == y && !building.Player.Equals(character.Player)) != null || Characters.Find(character_ => character_.X == x && character_.Y == y && !character_.Player.Equals(character.Player) && character_.Role == typeOfCharacter.wrecker ) != null);
            else if (character.Role == typeOfCharacter.fighter)
                return distance(character.X, character.Y, x, y) <= character.Range && Characters.Find(character_ => character_.X == x && character_.Y == y && character_.Player != character.Player && character_.GetType() != typeof(Wanderer) && character_.Role == typeOfCharacter.fighter) != null;
            return false;
        }

        // method checks every relavant condition and returns whether the character can collect object in the specific square
        public bool canCollect(Character character, int x, int y)
        {
            if (character.Role == typeOfCharacter.builder && character.Player.Charted[x, y])
                return getObjectFromSquare(x, y) != null && distance(character.X, character.Y, x, y) < character.Range && getObjectFromSquare(x, y).GetType().IsSubclassOf(typeof(Object));
            else
                return false;
        }

        // method checks every relavant condition and returns whether the building can place the character in the specific square
        public bool canTrain(Building building, Character character, int x, int y)
        {
            return isAvailable(x, y) && Map[x, y].Type == typeOfTerrain.plane && distance(building.X, building.Y, x, y) < 2 && building.Player.Charted[x, y];
        }

        // methods returns whether square of the board with these co-ordinates is available
        public bool isAvailable(int x, int y)
        {
            if (x > Width || x < 0 || y > Height || y < 0)
                return false;
            return !this.Squares[x, y];
        }

        // adds player to the board
        // at the beginning player posses base and one wanderer
        public void addPlayer(Player player)
        {
            // if player of this name is not yet added
            if (Players.Where(a => a.Equals(player)).ToList().Count == 0)
            {
                // first player, left-upper corner, blue color
                if (Players.Count == 0)
                {
                    this.Players.Add(player);
                    player.Charted = new bool[width, height];
                    for (int i = 0; i < 3; i++)
                        for (int j = 0; j < 3; j++)
                            player.Charted[i, j] = true;
                    player.Color = "Blue";
                    player.Castle = new Castle(player, 0, 0);
                    addBuilding(player.Castle);
                    this.addCharacter(new Wanderer(player, 0, 1));
                    Turn = player;
                }
                // second player, right-bottom corner, red color
                else if (Players.Count == 1)
                {
                    this.Players.Add(player);
                    player.Charted = new bool[width, height];
                    for (int i = width - 1; i > width - 4; i--)
                        for (int j = height - 1; j > height - 4; j--)
                            player.Charted[i, j] = true;
                    player.Color = "Red";
                    player.Castle = new Castle(player, Width - 1, Height - 1);
                    addBuilding(player.Castle);
                    this.addCharacter(new Wanderer(player, Width - 1, Height - 2));
                }
                // third player, left-buttom corner, yellow color
                else if (Players.Count == 2)
                {
                    this.Players.Add(player);
                    player.Charted = new bool[width, height];
                    for (int i = 0; i < 3; i++)
                        for (int j = height - 1; j > height - 4; j--)
                            player.Charted[i, j] = true;
                    player.Color = "Yellow";
                    player.Castle = new Castle(player, 0, Height - 1);
                    addBuilding(player.Castle);
                    this.addCharacter(new Wanderer(player, 0, Height - 2));
                }
                // first player, right-upper corner,purple color
                else if (Players.Count == 3)
                {
                    this.Players.Add(player);
                    player.Charted = new bool[width, height];
                    for (int i = width - 1; i > width - 4; i--)
                        for (int j = 0; j < 3; j++)
                            player.Charted[i, j] = true;
                    player.Color = "Purple";
                    player.Castle = new Castle(player, Width - 1, 0);
                    addBuilding(player.Castle);
                    this.addCharacter(new Wanderer(player, Width - 1, 1));
                }
                else
                    throw new Exception("Only 4 players can join!");
                update();
            }
            else
                throw new Exception("player's already joined");
        }

        // methods upadates list of buildings, characters and objects and removes dead characters, destroyed buildings and collected objects
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

            serialize("board.bin");

        }

        public void addObject(Object object_)
        {
            if (isAvailable(object_.X, object_.Y))
            {
                this.Objects.Add(object_);
                update();
            }
        }

        // methods adds buildng to the board if all the conditions are fulfilled
        // player's level >= building level, player has enough materials the building can be place on board at its co-ordinates
        public void addBuilding(Building building)
        {
            if (isAvailable(building.X, building.Y))
            {
                if (building.Player.Level < building.Min_level)
                    throw new Exception($"Minimum level to build {building.Type} is {building.Min_level}");
                if (building.MaterialsNeeded > building.Player.Materials)
                    throw new Exception($"Minimum materials to build {building.Type} is {building.MaterialsNeeded}");
                if (!Map[building.X, building.Y].build(building))
                    throw new Exception($"You can't build {building.Type} in this place");

                this.Buildings.Add(building);
                building.Player.Materials -= building.MaterialsNeeded;
                update();
            }
        }

        // if player has enough materials, methods adds character to the board
        public void addCharacter(Character character)
        {
            if (isAvailable(character.X, character.Y))
            {
                if (character.MaterialsNeeded > character.Player.Materials)
                    throw new Exception($"Minimum meterials to build this character is {character.MaterialsNeeded}");

                this.Characters.Add(character);
                character.Player.Materials -= character.MaterialsNeeded;
                update();
            }
        }

        // returns distance between two squares
        public double distance(int x1, int y1, int x2, int y2) { return Math.Sqrt(Math.Pow((x1 - x2), 2) + Math.Pow((y1 - y2), 2)); }

        // methods adds due materials and exp to the player and initialize his turn
        public void nextMove(Player player)
        {
            foreach (Building building in Buildings.Where(a => a.Player.Equals(player)))
                player.Exp += building.Exp;

            foreach (Building building in Buildings.Where(a => a.Player.Equals(player)))
                player.Materials += building.Materials;

            // removing player that lose
            foreach (Player player_ in Players)
            {
                if (player_.Castle.Health == 0)
                {
                    Characters.RemoveAll(a => a.Player.Equals(player_));
                    Buildings.RemoveAll(a => a.Player.Equals(player_));
                    break;
                }
            }

            player.nextLevel();
            Turn = player;
            //serialize("board.bin");
            update();
        }

        // serialization to bin
        public void serialize(string path)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                serializer.Serialize(stream, this);
            }
        }

        // deserialization from bin
        public static Board deserialize(string path)
        {
            BinaryFormatter serializer = new BinaryFormatter();
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                return serializer.Deserialize(stream) as Board;
            }
        }

        // properties
        public bool[,] Squares { get => squares; set => squares = value; }
        public List<Player> Players { get => players; set => players = value; }
        public List<Building> Buildings { get => buildings; set => buildings = value; }
        public List<Character> Characters { get => characters; set => characters = value; }
        public List<Object> Objects { get => objects; set => objects = value; }
        public int Height
        {
            get => height;
            set
            {
                if (value < 10 || value > 30)
                    throw new Exception("Height must be a number between 10 and 30");
                else
                    height = value;
            }
        }
        public int Width
        {
            get => width;
            set
            {
                if (value < 10 || value > 50)
                    throw new Exception("Width must be a number between 10 and 50");
                else
                    width = value;
            }
        }

        public Terrain[,] Map { get => map; set => map = value; }
        public Player Turn { get => turn; set => turn = value; }
    }
}
