using System;

namespace Game
{
    class Program
    {



        static void Main(string[] args)
        {

            Board board = new Board();

            Player x = new Player("Wojtek");
            Player y = new Player("Wojtek2");

            board.addPlayer(x);
            board.addPlayer(y);
            Character wanderer1 = board.Characters[0];
            Character wanderer2 = board.Characters[1];
            int r, f;
            //v.move(v.Characters[0], r, f);
            //int r2 = Convert.ToInt32(Console.ReadLine());
            //int f2 = Convert.ToInt32(Console.ReadLine());
            //wanderer1.collect(v.getObjectFromSquare(r2, f2) as Object);
            //v.update();
            //Console.WriteLine((Object)v.getObjectFromSquare(r2, f2).Collected);
            //v.nextMove(y);
            //r = Convert.ToInt32(Console.ReadLine());
            //f = Convert.ToInt32(Console.ReadLine());
            //v.move(v.Characters[1], r, f);

            //v.update();
            //v.Characters.ForEach(a => Console.WriteLine(a));
            ////Console.WriteLine(v);
            //Console.WriteLine(v.isAvailable(49, 19));
            //Console.WriteLine(v.getObjectFromSquare(49, 19));
            //v.update();
            for (int i = 0; i < 50; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    if (board.getObjectFromSquare(i, j) != null)
                    {
                        if (board.getObjectFromSquare(i, j).GetType() == typeof(Wanderer))
                        {
                            Console.WriteLine("FF");
                            Console.WriteLine(i);
                            Console.WriteLine(j);
                        }
                        if (board.getObjectFromSquare(i, j).GetType() == typeof(Base))
                        {
                            Console.WriteLine("FF");

                        }
                    }
                    
                }



            }
        
            


            //while (true)
            //{
            //    string h = Console.ReadLine();
            //    switch (h)
            //    {
            //        case "c":
            //            r = Convert.ToInt32(Console.ReadLine());
            //            f = Convert.ToInt32(Console.ReadLine());
            //            wanderer1.collect(v.getObjectFromSquare(wanderer1.X + r, wanderer1.Y + f) as Object);
            //            v.update();
            //            break;
            //        case "m":
            //            r = Convert.ToInt32(Console.ReadLine());
            //            f = Convert.ToInt32(Console.ReadLine());
            //            v.move(wanderer1, wanderer1.X + r, wanderer1.Y + f);
            //            break;
            //        case "b":
            //            h = Console.ReadLine();
            //            if (h == "b")
            //            {
            //                r = Convert.ToInt32(Console.ReadLine());
            //                f = Convert.ToInt32(Console.ReadLine());
            //                v.addBuilding(new Barrack(x, wanderer1.X + r, wanderer1.Y + f));
            //            }
            //            if (h == "hs")
            //            {
            //                r = Convert.ToInt32(Console.ReadLine());
            //                f = Convert.ToInt32(Console.ReadLine());
            //                v.addBuilding(new Hospital(x, wanderer1.X + r, wanderer1.Y + f));
            //            }
            //            if (h == "h")
            //            {
            //                r = Convert.ToInt32(Console.ReadLine());
            //                f = Convert.ToInt32(Console.ReadLine());
            //                v.addBuilding(new House(x, wanderer1.X + r, wanderer1.Y + f));
            //            }
            //            break;

            //        case "t":
            //            r = Convert.ToInt32(Console.ReadLine());
            //            f = Convert.ToInt32(Console.ReadLine());
            //            Barrack b = v.getObjectFromSquare(wanderer1.X + r, wanderer1.Y + f) as Barrack;
            //            r = Convert.ToInt32(Console.ReadLine());
            //            f = Convert.ToInt32(Console.ReadLine());
            //            v.addCharacter(b.trainWarrior(x, r, f));
            //            break;
            //        case "v":
            //            r = Convert.ToInt32(Console.ReadLine());
            //            f = Convert.ToInt32(Console.ReadLine());
            //            Warrior be = v.getObjectFromSquare(wanderer1.X + r, wanderer1.Y + f) as Warrior;
            //            wanderer1 = be;
            //            break;



            //    }
            //    v.nextMove(x);
            //    Console.WriteLine(x);

            //}



        }
    }
}
