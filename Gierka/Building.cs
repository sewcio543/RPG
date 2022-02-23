using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Serialization;

namespace Game
{
    [Serializable]
    public abstract class Building: IEquatable<Building>
    {
        Player player;
        string image;
        int minLevel;
        int maxHealth;
        int health;
        int exp;
        int x;
        int y;
        int materialsNeeded;
        int materials;
        string type;
        typeOfTerrain terrain;


        public Building(Player player)
        {
            Player = player;
            Image = $"/GUI;component/Resources/{Type}{player.Color}.png";
        }

        public string Tip() { return $"{Type}\nHealth: {Health}\nMaterials: {MaterialsNeeded}\nMin Level: {Min_level}"; }
        public override string ToString() { return $"{this.GetType().ToString()[5..]}\nPlayer: {Player.Name}\nHealth: {Health}"; }

        public bool Equals(Building other)
        {
            return X == other.X && Y == other.Y;
        }

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
