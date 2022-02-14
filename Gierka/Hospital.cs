using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class Hospital: Building 
    {
        public Hospital(Player player, int x, int y) : base(player, x, y)
        {
            Image = "1";
            Health = 200;
            Type = typeOfBuilding.general;
            Min_level = 4;
            MaterialsNeeded = 300;

        }

        public Medic trainMedic(Player player, int x, int y)
        {
            return new Medic(player, x, y);
        }

    }
     
    public class House: Building
    {
        public House(Player player, int x, int y) : base(player, x, y)
        {
            Image = "1";
            Health = 200;
            Min_level = 2;
            Exp = 50;
            MaterialsNeeded = 100;

        }
    }

    public class Barrack : Building
    {
        public Barrack(Player player, int x, int y) : base(player, x, y)
        {
            Image = "1";
            Type = typeOfBuilding.war;
            Health = 100;
            Min_level = 2;
            MaterialsNeeded = 100;
        }

        public Warrior trainWarrior(Player player, int x, int y)
        {
            return new Warrior(player, x, y);
        }

    }

    public class Base : Building
    {
        public Base(Player player)
        {
            this.Player = player;
            this.Min_level = 1;
            this.Image = "11";
            this.Health = 10;
            this.Type = typeOfBuilding.general;
            this.Exp = 50;
        }

    }
}
