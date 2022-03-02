using System;
using System.Collections.Generic;
using System.Text;

namespace Game
{
    [Serializable]
    // Objects are items on the board, that can be collected by the player's character of type builder.
    // When collected, they increase player's materials
    public abstract class Object
    {
        // how many materials it gives
        int materials;
        // relative path to object's png
        string image;
        bool collected = false;
        // co-ordinates on the board, object's position
        int x;
        int y;

        // constructor
        public Object(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        // properties
        public int Materials { get => materials; set => materials = value; }
        public string Image { get => image; set => image = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }
        public bool Collected { get => collected; set => collected = value; }


        public override string ToString() { return $"{this.GetType().ToString()[5..]}"; }
    }
    // child classes, different objects

    [Serializable]
    public class Tree : Object
    {
        public Tree(int x, int y) : base(x, y)
        {
            Materials = 50;
            Image = $"/GUI;component/Resources/tree.png";
        }
    }
    [Serializable]
    public class Stone : Object
    {
        public Stone (int x, int y) : base(x, y)
        {
            Materials = 100;
            Image = $"/GUI;component/Resources/stone.png";
        }
    }
    [Serializable]
    public class Gold : Object
    {
        public Gold(int x, int y) : base(x, y)
        {
            Materials = 200;
            Image = $"/GUI;component/Resources/gold.png";
        }
    }
}
