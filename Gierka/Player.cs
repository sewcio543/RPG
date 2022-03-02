using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Game
{
    // Player's class
    [Serializable]
    public class Player : IComparable<Player>, IEquatable<Player>
    {
        // actual level
        int level = 1;
        // actual experience
        int exp = 0;
        // name of the player
        string name;
        // Base, every player has one at the beginning, the most important building
        // if base falls, player loses
        Base _base;
        // actual materials
        int materials = 100;
        // color of the player
        string color;
        // part of the board that' ve been discovered
        bool[,] charted;

        // constructors
        public Player() { }
        public Player(string name) { this.Name = name; }
             
        // properties
        public int Level
        {
            get => level;
            set
            {
                if (value > 0 && value < 20)
                    level = value;
            }
        }

        public int Exp { get => exp; set => exp = value; }
        public Base Base { get => _base; set => _base = value; }
        public string Name { get => name; set => name = value; }
        public int Materials { get => materials; set => materials = value; }
        public string Color { get => color; set => color = value; }
        public bool[,] Charted { get => charted; set => charted = value; }

        // methods

        // methods return true if actual exp is enough to level up
        public bool nextLevel()
        {
            // with every level threshold raises 
            if (this.Exp >= this.Level * 100 )
            {
                this.Exp = this.Exp % (this.Level * 100);
                this.Level++;
                // base upgrades
                this.Base.Exp += 20;
                this.Base.Health += 10;
                Base.MaxHealth += 10; 
                return true;
            }
            return false;
        }
       

        public override string ToString()
        {
            return $"Name: {Name}\nLevel: {Level}";
        }


        public int CompareTo( Player other)
        {
            if (this.Level == other.Level)
                return this.Exp.CompareTo(other.Exp);
            return this.Level.CompareTo(other.Level);
        }

        public bool Equals( Player other)
        {
            return this.Name == other.Name;
        }
    }
}
