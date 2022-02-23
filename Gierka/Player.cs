using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Game
{
    [Serializable]
    public class Player : IComparable<Player>, IEquatable<Player>
    {
        int level = 1;
        int exp = 0;
        string name;
        Base _base;
        int materials = 100;
        string color;
        bool[,] charted;

        public Player() { }
        public Player(string name) { this.Name = name; }
             
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

        public bool nextLevel()
        {
            if (this.Exp >= this.Level * 100 )
            {
                this.Exp = this.Exp % (this.Level * 100);
                this.Level++;
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
