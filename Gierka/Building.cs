using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public abstract class Building
    {
        Player player;
        string image;
        int minLevel;
        int health;
        int exp;
        int x;
        int y;
        int materialsNeeded;
        string type;
        typeOfTerrain terrain;
        int maxHealth;


        public Building(Player player)
        {
            Player = player;
            Image = $"/GUI;component/Resources/{Type}{player.Color}.png";
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

        public string Type { get => type; set => type = value; }
        public typeOfTerrain Terrain { get => terrain; set => terrain = value; }
        public int MaxHealth { get => maxHealth; set => maxHealth = value; }

        public string Tip()
        {
            return $"{Type}\nHealth: {Health}\nMaterials: {MaterialsNeeded}";
        }
        public override string ToString()
        {
            return $"{this.GetType().ToString()[5..]}\nPlayer: {Player.Name}\nLocation: {x}-{y}\nHealth: {Health}";
        }


    }
}
