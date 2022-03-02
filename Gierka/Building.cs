using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Serialization;

namespace Game
{
    [Serializable]
    // buildings can give the a player materials, experience's points or can be used to train characters
    public abstract class Building : IEquatable<Building>
    {
        // player who owns the building
        Player player;
        // relative path to png
        string image;
        // minimum level to build
        int minLevel;
        // maximum, inicial health
        int maxHealth;
        // actual health
        int health;
        // exp that player benefits every round
        int exp;
        // co-ordinates on  the map, buidling's position
        int x;
        int y;
        // materials needed to build
        int materialsNeeded;
        // materials that players benefits every round
        int materials;
        // type of building
        string type;
        // terrain, on which building can be placed
        typeOfTerrain terrain;

        // constructor
        public Building(Player player) { Player = player; }

        // methods

        // building's description used in WPF
        public string Tip() { return $"{Type}\nHealth: {Health}\nMaterials: {MaterialsNeeded}\nMin Level: {Min_level}"; }
        public override string ToString() { return $"{this.GetType().ToString()[5..]}\nPlayer: {Player.Name}\nHealth: {Health}"; }

        public bool Equals(Building other)
        {
            return X == other.X && Y == other.Y;
        }

        // properties
        public int Min_level { get => minLevel; set => minLevel = value; }
        public int Health
        {
            get => health;
            set
            {
                if (value > 1000)
                    health = 1000;
                else if (value < 0)
                    health = 0;
                else
                    health = value;
            }
        }
        public string Image { get => image; set => image = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public int MaterialsNeeded { get => materialsNeeded; set => materialsNeeded = value; }
        public int Exp { get => exp; set => exp = value; }
        public string Type { get => type; set => type = value; }
        public typeOfTerrain Terrain { get => terrain; set => terrain = value; }
        public int MaxHealth { get => maxHealth; set => maxHealth = value; }
        public int Materials { get => materials; set => materials = value; }
        public Player Player { get => player; set => player = value; }
    }
}
