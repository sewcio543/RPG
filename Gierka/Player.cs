using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Game
{
    public class Player
    {
        int level = 1;
        int exp = 0;
        string name;
        List<Skill> skills = new List<Skill>() { };
        Base _base;
        int materials = 100;

        public Player() { }
        public Player(string name)
        {
            this.Name = name;
            this.Base = new Base(this);
        }



        public int Level
        {
            get => level;
            set
            {
                if (value > 0 && value < 20)
                    level = value;
            }
        }

        public List<Skill> Skills { get => skills; set => skills = value; }
        public int Exp { get => exp; set => exp = value; }
        public Base Base { get => _base; set => _base = value; }
        public string Name { get => name; set => name = value; }
        public int Materials { get => materials; set => materials = value; }

        public void addSkill(Skill skill)
        {
            if (this.Level >= skill.Min_level)
                this.Skills.Add(skill);
        }

        public void nextLevel()
        {
            if (this.Exp >= this.Level * 100 )
            {
                this.Exp = this.Exp % (this.Level * 100);
                this.Level++;
                Console.WriteLine($"Level {Level}");
            }
        }
       
        public void win()
        {
            Console.WriteLine("You won!");
        }

        public void lose()
        {
            Console.WriteLine("You lost!");
        }


        public override string ToString()
        {
            return $"Name: {Name}\nLevel: {Level}\nExp: {Exp}\nMaterials: {Materials}";
        }

    }
}
