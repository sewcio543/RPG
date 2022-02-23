using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Serialization;

namespace Game
{
    public enum typeOfCharacter { builder, fighter, wrecker }

    [Serializable]
    public abstract class Character : IEquatable<Character>
    {
        int health;
        int damage;
        int leap;
        string image;
        int x;
        int y;
        int materialsNeeded;
        Player player;
        string type;
        int range;
        typeOfCharacter role;
        int aid;
        int maxHealth;

        public Character(Player player) { Player = player; }


        public void collect(Object object_)
        {
            if (Role == typeOfCharacter.builder)
            {
                object_.Collected = true;
                Player.Materials += object_.Materials;
            }
        }

        public void Strike(Character character)
        {
            if (Role == typeOfCharacter.fighter && character.Role == typeOfCharacter.fighter)
                character.Health -= Damage;

            if (Role == typeOfCharacter.wrecker && character.Role == typeOfCharacter.wrecker)
                character.Health -= Damage;

        }

        public void Strike(Building building)
        {
            if (Role == typeOfCharacter.wrecker)
                building.Health -= Damage;
        }



        public string Tip()
        {
            string tip = $"{Type}\nRole: {Role}\nHealth: {Health}\nLeap: {Leap}\nRange: {Range}\nMaterials: {MaterialsNeeded}";
            if (Role == typeOfCharacter.fighter && Role == typeOfCharacter.wrecker)
                tip += $"\nDamage: {Damage}";
            return tip;
        }

        public override string ToString()
        {
            return $"{this.GetType().ToString()[5..]}\nPlayer: {Player.Name}\nHealth: {Health}\n";
        }

        public bool Equals(Character other)
        {
            return (this.X == other.X && this.Y == other.Y);
        }

        public int Health
        {
            get => health;
            set
            {
                if (value > 300)
                    health = 300;
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
                if (value > 100)
                    damage = 100;
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
                if (value > 10)
                    leap = 10;
                else if (value < 0)
                    leap = 0;
                else
                    leap = value;
            }
        }
        public string Image { get => image; set => image = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public Player Player { get => player; set => player = value; }
        public int MaterialsNeeded { get => materialsNeeded; set => materialsNeeded = value; }
        public string Type { get => type; set => type = value; }
        public int Range { get => range; set => range = value; }
        public typeOfCharacter Role { get => role; set => role = value; }
        public int Aid { get => aid; set => aid = value; }
        public int MaxHealth { get => maxHealth; set => maxHealth = value; }

    }


}
