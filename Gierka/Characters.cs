using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class Wanderer : Character
    {
        public Wanderer(Player player) : base(player)
        {
            Type = "wanderer";
            MaxHealth = 5;
            Health = MaxHealth;
            Damage = 0;
            Leap = 3;
            Image = $"/GUI;component/Resources/{Type}{player.Color}.png";
            MaterialsNeeded = 0;
            Range = 2;
            Role = typeOfCharacter.builder;

        }

        public Wanderer(Player player, int x, int y) : this(player)
        {
            X = x;
            Y = y;
        }
    }


    public class Warrior : Character
    {
        public Warrior(Player player) : base(player)
        {
            MaxHealth = 20;
            Health = MaxHealth;
            Damage = 5;
            Leap = 2;
            MaterialsNeeded = 10;
            Type = "warrior";
            Image = $"/GUI;component/Resources/{Type}{player.Color}.png";
            Range = 2;
            Role = typeOfCharacter.fighter;

        }

        public Warrior(Player player, int x, int y) : this(player)
        {
            X = x;
            Y = y;
        }

    }

    public class Soldier : Character
    {
        public Soldier(Player player) : base(player)
        {
            MaxHealth = 20;
            Health = MaxHealth;
            Damage = 5;
            Leap = 2;
            MaterialsNeeded = 10;
            Type = "soldier";
            Image = $"/GUI;component/Resources/{Type}{player.Color}.png";
            Range = 2;
            Role = typeOfCharacter.fighter;

        }

        public Soldier(Player player, int x, int y) : this(player)
        {
            X = x;
            Y = y;
        }

    }
    public class Archer : Character
    {
        public Archer(Player player) : base(player)
        {
            MaxHealth = 5;
            Health = MaxHealth;
            Damage = 5;
            Leap = 3;
            MaterialsNeeded = 20;
            Type = "archer";
            Image = $"/GUI;component/Resources/{Type}{player.Color}.png";
            Range = 4;
            Role = typeOfCharacter.fighter;

        }

        public Archer(Player player, int x, int y) : this(player)
        {
            X = x;
            Y = y;
        }

       
    }

    public class Rider : Character
    {
        public Rider(Player player) : base(player)
        {
            MaxHealth = 5;
            Health = MaxHealth;
            Damage = 7;
            Leap = 6;
            MaterialsNeeded = 30;
            Type = "rider";
            Image = $"/GUI;component/Resources/{Type}{player.Color}.png";
            Range = 2;
            Role = typeOfCharacter.fighter;
        }

        public Rider(Player player, int x, int y) : this(player)
        {
            X = x;
            Y = y;
        }
    }


    public class BatteringRam : Character
    {
        public BatteringRam(Player player) : base(player)
        {
            MaxHealth = 5;
            Health = MaxHealth;
            Leap = 3;
            MaterialsNeeded = 50;
            Type = "batteringRam";
            Image = $"/GUI;component/Resources/{Type}{player.Color}.png";
            Role = typeOfCharacter.wrecker;
            Aid = 10;
            Range = 5;
        }

        public BatteringRam(Player player, int x, int y) : this(player)
        {
            X = x;
            Y = y;
        }
    }

    public class Catapult : Character
    {
        public Catapult(Player player) : base(player)
        {
            MaxHealth = 5;
            Health = MaxHealth;
            Leap = 3;
            MaterialsNeeded = 0;
            Type = "catapult";
            Image = $"/GUI;component/Resources/{Type}{player.Color}.png";
            Role = typeOfCharacter.wrecker;
            Aid = 10;
            Range = 5;
            Damage = 100;
        }

        public Catapult(Player player, int x, int y) : this(player)
        {
            X = x;
            Y = y;
        }
    }

    public class Miner : Character
    {
        public Miner(Player player) : base(player)
        {
            MaxHealth = 5;
            Health = MaxHealth;
            Leap = 3;
            MaterialsNeeded = 100;
            Type = "miner";
            Image = $"/GUI;component/Resources/{Type}{player.Color}.png";
            Role = typeOfCharacter.builder;
            Aid = 10;
            Range = 5;
        }

        public Miner(Player player, int x, int y) : this(player)
        {
            X = x;
            Y = y;
        }
    }

    public class Cannon : Character
    {
        public Cannon(Player player) : base(player)
        {
            MaxHealth = 5;
            Health = MaxHealth;
            Leap = 3;
            MaterialsNeeded = 0;
            Type = "cannon";
            Image = $"/GUI;component/Resources/{Type}{player.Color}.png";
            Role = typeOfCharacter.wrecker;
            Aid = 10;
            Damage = 100;
            Range = 10;
        }

        public Cannon(Player player, int x, int y) : this(player)
        {
            X = x;
            Y = y;
        }
    }
}
