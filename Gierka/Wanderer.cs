using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class Wanderer: Character
    {
        public Wanderer(Player player, int x, int y) : base(player, x, y)
        {
            this.Type = typeOfCharacter.warrior;
            this.Image = "11";
            this.Health = 5;
            this.Damage = 0;
            this.Leap = 3;
        }
    }

    public class Warrior : Character
    {
        public Warrior(Player player, int x, int y) : base(player, x, y)
        {
            this.Type = typeOfCharacter.warrior;
            this.Image = "11";
            this.Health = 5;
            this.Damage = 10;
            this.Leap = 2;
        }
        public void Strike(Character character)
        {
            character.Health -= this.Damage;
        }

        public void Strike(Building building)
        {
            building.Health -= this.Damage;
        }
    }

    public class Medic : Character
    {
        public Medic(Player player, int x, int y) : base(player, x, y)
        {
            this.Type = typeOfCharacter.medic;
            this.Image = "11";
            this.Health = 2;
            this.Damage = 0;
            this.Leap = 1;


        }

        public void cure(Character character)
        {
            character.Health += 10;
        }


    }
}
