using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Xml.Serialization;

namespace Game
{
    // purpose of the character
    // builders can collect objects and place buildings on the map
    // fighters can fight with each others
    // wreckers can destroy buildings and other wreckers 
    public enum typeOfCharacter { builder, fighter, wrecker }

    [Serializable]
    // With characters player can explore map, build and fight
    public abstract class Character : IEquatable<Character>
    {
        // actual health
        int health;
        // damge given by one strike
        int damage;
        // maximum squares that character can leap with a single move
        int leap;
        // relative path to character png
        string image;
        // co-ordinates on the map, character's position
        int x;
        int y;
        // materials needed to build a character
        int materialsNeeded;
        // player that owns a character
        Player player;
        // maximum squares' distance to fight other character
        int range;
        // role, like builder, fighter, wrecker
        typeOfCharacter role;
        // maximum, inicial health
        int maxHealth;

        // constructor
        public Character(Player player) { Player = player; }

        // methods
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

        // summary of the character, used in WPF
        public string Tip()
        {
            string tip = $"Role: {Role}\nHealth: {Health}\nLeap: {Leap}\nRange: {Range}\nMaterials: {MaterialsNeeded}";
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

        // properties
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
        public int Range { get => range; set => range = value; }
        public typeOfCharacter Role { get => role; set => role = value; }
        public int MaxHealth { get => maxHealth; set => maxHealth = value; }

    }


}
