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
            Health = 5;
            Damage = 0;
            Leap = 3;
            Image = $"/GUI;component/Resources/{Type}{player.Number}.png";
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
            Health = 10;
            Damage = 5;
            Leap = 2;
            MaterialsNeeded = 100;
            Type = "warrior";
            Image = $"/GUI;component/Resources/{Type}{player.Number}.png";
            Range = 2;
            Role = typeOfCharacter.fighter;

        }

        public Warrior(Player player, int x, int y) : this(player)
        {
            X = x;
            Y = y;
        }

    }

    public class Archer : Character
    {
        public Archer(Player player) : base(player)
        {
            Health = 8;
            Damage = 5;
            Leap = 3;
            MaterialsNeeded = 200;
            Type = "archer";
            Image = $"/GUI;component/Resources/{Type}{player.Number}.png";
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
            Health = 15;
            Damage = 7;
            Leap = 6;
            MaterialsNeeded = 300;
            Type = "rider";
            Image = $"/GUI;component/Resources/{Type}{player.Number}.png";
            Range = 2;
            Role = typeOfCharacter.fighter;
        }

        public Rider(Player player, int x, int y) : this(player)
        {
            X = x;
            Y = y;
        }
    }

    public class Medic : Character
    {
        public Medic(Player player) : base(player)
        {
            Health = 2;
            Leap = 3;
            MaterialsNeeded = 400;
            Type = "medic";
            Image = $"/GUI;component/Resources/{Type}{player.Number}.png";
            Role = typeOfCharacter.curer;
            Aid = 10;
            Range = 5;
        }

        public Medic(Player player, int x, int y) : this(player)
        {
            X = x;
            Y = y;
        }
    }
}
