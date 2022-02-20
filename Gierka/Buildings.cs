using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
   
    public class House : Building
    {
  
        public House(Player player) : base(player)
        {
            Type = "house";
            MaxHealth = 30;
            Health = MaxHealth;
            Min_level = 1;
            Exp = 50;
            Image = $"/GUI;component/Resources/{Type}{player.Color}.png";

            MaterialsNeeded = 10;

        }
        public House(Player player, int x, int y) : this(player)
        {
            X = x;
            Y = y;
        }
    }

    public class Barrack : Building
    {
        public Barrack(Player player) : base(player)
        {
            Type = "barrack";
            MaxHealth = 30;

            Health = MaxHealth;
            Min_level = 1;
            MaterialsNeeded = 10;
            Image = $"/GUI;component/Resources/{Type}{player.Color}.png";

        }

        public Barrack(Player player, int x, int y) : this(player)
        {
            X = x;
            Y = y;
        }

    }

    public class Base : Building
    {
 
        public Base(Player player, int x, int y) : base(player)
        {
            Terrain = typeOfTerrain.plane;
            MaxHealth = 30;
            Type = "base";
            this.Min_level = 1;
            this.Health = MaxHealth;
            this.Exp = 50;
            X = x;
            Y = y;
            Image = $"/GUI;component/Resources/{Type}{player.Color}.png";

        }

    }

    public class Port: Building
    {
        public Port(Player player) : base(player)
        {
            Terrain = typeOfTerrain.water;
            MaxHealth = 30;
            Type = "port";
            Health = MaxHealth;
            Min_level = 1;
            MaterialsNeeded = 100;
            Image = $"/GUI;component/Resources/{Type}{player.Color}.png";

        }

        public Port(Player player, int x, int y) : this(player)
        {
            X = x;
            Y = y;
        }
    }

    public class Mine : Building
    {
        public Mine(Player player) : base(player)
        {
            Terrain = typeOfTerrain.mountain;
            MaxHealth = 30;
            Type = "mine";
            Health = MaxHealth;
            Min_level = 1;
            MaterialsNeeded = 100;
            Image = $"/GUI;component/Resources/{Type}{player.Color}.png";

        }

        public Mine(Player player, int x, int y) : this(player)
        {
            X = x;
            Y = y;
        }
    }

    public class Armory : Building
    {
        public Armory(Player player) : base(player)
        {
            Terrain = typeOfTerrain.plane;
            MaxHealth = 30;
            Type = "armory";
            Health = MaxHealth;
            Min_level = 1;
            MaterialsNeeded = 100;
            Image = $"/GUI;component/Resources/{Type}{player.Color}.png";

        }

        public Armory(Player player, int x, int y) : this(player)
        {
            X = x;
            Y = y;
        }
    }

    public class Farm : Building
    {
        public Farm(Player player) : base(player)
        {
            Terrain = typeOfTerrain.plane;
            MaxHealth = 30;
            Type = "farm";
            Health = MaxHealth;
            Min_level = 1;
            MaterialsNeeded = 100;
            Image = $"/GUI;component/Resources/{Type}{player.Color}.png";

        }

        public Farm(Player player, int x, int y) : this(player)
        {
            X = x;
            Y = y;
        }
    }
}
