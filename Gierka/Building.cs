using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public enum typeOfBuilding { water, mountain, war, general }

    public abstract class Building
    {
        Player player;
        string image;
        typeOfBuilding type;
        int min_level;
        int health;
        int exp;
        bool available;
        int x;
        int y;
        int materialsNeeded;

        public Building() { }

        public Building(Player player, int x, int y)
        {
            this.Player = player;
            this.X = x;
            this.Y = y;
        }

        public bool Available { get => available; set => available = value; }
        public typeOfBuilding Type { get => type; set => type = value; }
        public int Min_level { get => min_level; set => min_level = value; }
        public int Health { get => health; set => health = value; }
        public string Image { get => image; set => image = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int MaterialsNeeded { get => materialsNeeded; set => materialsNeeded = value; }
        public int Exp { get => exp; set => exp = value; }
        public Player Player
        {
            get => player;
            set
            {
                if (value.Level >= this.Min_level)
                    player = value;
                else
                    throw new Exception("too low level!");
            }
        }

        public override string ToString()
        {
            return $"{this.GetType()}\nPlayer: {Player.Name}\nLocation: {x}-{y}\nHealth: {Health}";
        }


    }
}
