using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public class Skill
    {
        public enum typeOfSkill { water, mountain, war }
        typeOfSkill type;
        string name;
        int min_level;
        bool available;

        public typeOfSkill Type { get => type; set => type = value; }
        public string Name { get => name; set => name = value; }
        public int Min_level { get => min_level; set => min_level = value; }
        public bool Available { get => available; set => available = value; }

        public Skill(string name, int min_level, typeOfSkill type)
        {
            this.name = name;
            this.Min_level = min_level;
            this.Type = type;
        }
        
    }
}
