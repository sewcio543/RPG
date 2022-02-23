using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    [Serializable]
    public class House : Building
    {
  
        public House(Player player) : base(player)
        {
            Type = "house";
            MaxHealth = 200;
            Health = MaxHealth;
            Min_level = 3;
            Materials = 50;
            Exp = 50;
            Image = $"/GUI;component/Resources/{Type}{player.Color}.png";
            MaterialsNeeded = 200;
        }
        public House(Player player, int x, int y) : this(player)
        {
            X = x;
            Y = y;
        }
    }
    [Serializable]
    public class Barrack : Building
    {
        public Barrack(Player player) : base(player)
        {
            Type = "barrack";
            MaxHealth = 300;
            Health = MaxHealth;
            Min_level = 2;
            MaterialsNeeded = 100;
            Image = $"/GUI;component/Resources/{Type}{player.Color}.png";
        }

        public Barrack(Player player, int x, int y) : this(player)
        {
            X = x;
            Y = y;
        }

    }
    [Serializable]
    public class Base : Building
    {
 
        public Base(Player player, int x, int y) : base(player)
        {
            MaxHealth = 400;
            Type = "base";
            Health = MaxHealth;
            Exp = 50;
            X = x;
            Y = y;
            Image = $"/GUI;component/Resources/{Type}{player.Color}.png";
        }

    }
    [Serializable]
    public class Port: Building
    {
        public Port(Player player) : base(player)
        {
            Terrain = typeOfTerrain.water;
            MaxHealth = 300;
            Type = "port";
            Health = MaxHealth;
            Min_level = 5;
            MaterialsNeeded = 400;
            Exp = 50;
            Materials = 100;
            Image = $"/GUI;component/Resources/{Type}{player.Color}.png";

        }

        public Port(Player player, int x, int y) : this(player)
        {
            X = x;
            Y = y;
        }
    }
    [Serializable]
    public class Mine : Building
    {
        public Mine(Player player) : base(player)
        {
            Terrain = typeOfTerrain.mountain;
            MaxHealth = 300;
            Type = "mine";
            Health = MaxHealth;
            Min_level = 6;
            MaterialsNeeded = 500;
            Materials = 150;
            Exp = 50;
            Image = $"/GUI;component/Resources/{Type}{player.Color}.png";

        }

        public Mine(Player player, int x, int y) : this(player)
        {
            X = x;
            Y = y;
        }
    }
    [Serializable]
    public class Armory : Building
    {
        public Armory(Player player) : base(player)
        {
            MaxHealth = 300;
            Type = "armory";
            Health = MaxHealth;
            Min_level = 4;
            MaterialsNeeded = 100;
            Image = $"/GUI;component/Resources/{Type}{player.Color}.png";
        }

        public Armory(Player player, int x, int y) : this(player)
        {
            X = x;
            Y = y;
        }
    }
    [Serializable]
    public class Farm : Building
    {
        public Farm(Player player) : base(player)
        {
            Terrain = typeOfTerrain.field;
            MaxHealth = 200;
            Type = "farm";
            Health = MaxHealth;
            Min_level = 8;
            MaterialsNeeded = 600;
            Materials = 200;
            Exp = 100;
            Image = $"/GUI;component/Resources/{Type}{player.Color}.png";
        }

        public Farm(Player player, int x, int y) : this(player)
        {
            X = x;
            Y = y;
        }
    }
}
