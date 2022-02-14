using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    public abstract class Object
    {
        int materials;
        string image;
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

        public override string ToString()
        {
            return $"{this.GetType()}\nLocation: {x}-{y}\n";
        }
    }

    public class Tree : Object
    {
        public Tree(int x, int y) : base(x, y)
        {
            Materials = 50;
            Image = "";
        }
    }

    public class Stone : Object
    {
        public Stone (int x, int y) : base(x, y)
        {
            Materials = 100;
            Image = "";
        }
    }

    public class Gold : Object
    {
        public Gold(int x, int y) : base(x, y)
        {
            Materials = 200;
            Image = "";
        }
    }
}
