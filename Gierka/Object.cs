using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    [Serializable]
    public abstract class Object
    {
        int materials;
        string image;
        string type;
        bool collected = false;
        int x;
        int y;

        public Object(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public int Materials { get => materials; set => materials = value; }
        public string Image { get => image; set => image = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public bool Collected { get => collected; set => collected = value; }
        public string Type { get => type; set => type = value; }

        public override string ToString()
        {
            return $"{this.GetType().ToString()[5..]}";
        }
    }
    [Serializable]
    public class Tree : Object
    {
        public Tree(int x, int y) : base(x, y)
        {
            Materials = 50;
            Type = "tree";
            Image = $"/GUI;component/Resources/{Type}.png";
        }
    }
    [Serializable]
    public class Stone : Object
    {
        public Stone (int x, int y) : base(x, y)
        {
            Materials = 100;
            Type = "stone";
            Image = $"/GUI;component/Resources/{Type}.png";
        }
    }
    [Serializable]
    public class Gold : Object
    {
        public Gold(int x, int y) : base(x, y)
        {
            Materials = 200;
            Type = "gold";
            Image = $"/GUI;component/Resources/{Type}.png";
        }
    }
}
