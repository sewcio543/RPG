using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public enum typeOfCharacter { wanderer, warrior, medic }
    public abstract class Character
    {
        int health;
        int damage;
        int leap;
        string image;
        typeOfCharacter type;
        int x;
        int y;
        int materialsNeeded;
        Player player;

        public Character() { }
        public Character(Player player, int x, int y)
        {
            this.Player = player;
            this.X = x;
            this.Y = y;
        }

        public void collect(Object object_)
        {
            object_.Collected = true;
            this.Player.Materials += object_.Materials;
        }


        public int Health
        {
            get => health;
            set
            {
                if (value > 20)
                    health = 20;
                else if (value < 0)
                    health = 0;
                else
                    health = value;
            }
        }

        public int Damage
        {
            get => damage;
            set
            {
                if (value > 20)
                    damage = 20;
                else if (value < 0)
                    damage = 0;
                else
                    damage = value;
            }
        }
        public int Leap
        {
            get => leap;
            set
            {
                if (value > 20)
                    leap = 20;
                else if (value < 0)
                    leap = 0;
                else
                    leap = value;
            }
        }
        public typeOfCharacter Type { get => type; set => type = value; }
        public string Image { get => image; set => image = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public Player Player { get => player; set => player = value; }
        public int MaterialsNeeded { get => materialsNeeded; set => materialsNeeded = value; }

  

        public override string ToString()
        {
            return $"{this.GetType()}\nPlayer: {Player.Name}\nLocation: {X}-{Y}\nHealth: {Health}\n";
        }


    }


}
