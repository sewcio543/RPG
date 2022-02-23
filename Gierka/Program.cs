using System;

namespace Game
{
    class Program
    {



        static void Main(string[] args)
        {
            Player g = new Player("S");
            Player gg = new Player("S");
            Farm n = new Farm(g);
            Console.WriteLine(n.Min_level);
           // n.Player = gg;



        }
    }
}
