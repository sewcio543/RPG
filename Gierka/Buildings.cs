using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class Hospital : Building
    {

        public Hospital(Player player) : base(player)
        {
            Type = "hospital";
            Health = 200;
            Min_level = 4;
            Image = $"/GUI;component/Resources/{Type}{player.Number}.png";
            MaterialsNeeded = 300;
        }
        public Hospital(Player player, int x, int y) : this(player)
        {
            X = x;
            Y = y;
        }

    }

    public class House : Building
    {
        public House(Player player) : base(player)
        {
            Type = "house";
            Health = 200;
            Min_level = 2;
            Exp = 50;
            Image = $"/GUI;component/Resources/{Type}{player.Number}.png";

            MaterialsNeeded = 100;

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
            Health = 100;
            Min_level = 2;
            MaterialsNeeded = 100;
            Image = $"/GUI;component/Resources/{Type}{player.Number}.png";

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
            Type = "base";
            this.Min_level = 1;
            this.Health = 10;
            this.Exp = 50;
            X = x;
            Y = y;
            Image = $"/GUI;component/Resources/{Type}{player.Number}.png";

        }

    }
}
