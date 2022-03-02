using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    // child classes of Character's class, different characters

    [Serializable]  
    public class Wanderer : Character
    {
        public Wanderer(Player player) : base(player)
        {
            MaxHealth = 5;
            Health = MaxHealth;
            Leap = 3;
            Image = $"/GUI;component/Resources/wanderer{player.Color}.png";
            Range = 2;
            Role = typeOfCharacter.builder;

        }

        public Wanderer(Player player, int x, int y) : this(player)
        {
            X = x;
            Y = y;
        }
    }
    [Serializable]

    public class Warrior : Character
    {
        public Warrior(Player player) : base(player)
        {
            MaxHealth = 10;
            Health = MaxHealth;
            Damage = 5;
            Leap = 2;
            MaterialsNeeded = 100;
            Image = $"/GUI;component/Resources/warrior{player.Color}.png";
            Range = 2;
            Role = typeOfCharacter.fighter;

        }

        public Warrior(Player player, int x, int y) : this(player)
        {
            X = x;
            Y = y;
        }

    }
    [Serializable]
    public class Soldier : Character
    {
        public Soldier(Player player) : base(player)
        {
            MaxHealth = 20;
            Health = MaxHealth;
            Damage = 8;
            Leap = 2;
            MaterialsNeeded = 500;
            Image = $"/GUI;component/Resources/soldier{player.Color}.png";
            Range = 4;
            Role = typeOfCharacter.fighter;

        }

        public Soldier(Player player, int x, int y) : this(player)
        {
            X = x;
            Y = y;
        }

    }
    [Serializable]
    public class Archer : Character
    {
        public Archer(Player player) : base(player)
        {
            MaxHealth = 8;
            Health = MaxHealth;
            Damage = 3;
            Leap = 3;
            MaterialsNeeded = 200;
            Image = $"/GUI;component/Resources/archer{player.Color}.png";
            Range = 4;
            Role = typeOfCharacter.fighter;

        }

        public Archer(Player player, int x, int y) : this(player)
        {
            X = x;
            Y = y;
        }

       
    }
    [Serializable]
    public class Rider : Character
    {
        public Rider(Player player) : base(player)
        {
            MaxHealth = 10;
            Health = MaxHealth;
            Damage = 5;
            Leap = 6;
            MaterialsNeeded = 300;
            Image = $"/GUI;component/Resources/rider{player.Color}.png";
            Range = 2;
            Role = typeOfCharacter.fighter;
        }

        public Rider(Player player, int x, int y) : this(player)
        {
            X = x;
            Y = y;
        }
    }

    [Serializable]
    public class BatteringRam : Character
    {
        public BatteringRam(Player player) : base(player)
        {
            MaxHealth = 200;
            Health = MaxHealth;
            Leap = 1;
            MaterialsNeeded = 300;
            Damage = 50;
            Image = $"/GUI;component/Resources/batteringRam{player.Color}.png";
            Role = typeOfCharacter.wrecker;
            Range = 2;
        }

        public BatteringRam(Player player, int x, int y) : this(player)
        {
            X = x;
            Y = y;
        }
    }
    [Serializable]
    public class Catapult : Character
    {
        public Catapult(Player player) : base(player)
        {
            MaxHealth = 100;
            Health = MaxHealth;
            Leap = 3;
            MaterialsNeeded = 400;
            Image = $"/GUI;component/Resources/catapult{player.Color}.png";
            Role = typeOfCharacter.wrecker;
            Range = 4;
            Damage = 80;
        }

        public Catapult(Player player, int x, int y) : this(player)
        {
            X = x;
            Y = y;
        }
    }

    [Serializable]
    public class Cannon : Character
    {
        public Cannon(Player player) : base(player)
        {
            MaxHealth = 300;
            Health = MaxHealth;
            Leap = 3;
            MaterialsNeeded = 700;
            Image = $"/GUI;component/Resources/cannon{player.Color}.png";
            Role = typeOfCharacter.wrecker;
            Damage = 120;
            Range = 5;
        }

        public Cannon(Player player, int x, int y) : this(player)
        {
            X = x;
            Y = y;
        }
    }
}
