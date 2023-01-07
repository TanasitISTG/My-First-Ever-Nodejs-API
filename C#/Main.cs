using System;

namespace ConsoleApplication1
{
    public class Main
    {
        public static void MainMenu(string args)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the game, " + args + "!");
            Console.WriteLine("You are in a dark room.");
            Console.WriteLine("There is a door to your right and left.");
            Console.WriteLine("Which one do you take?");
            Console.WriteLine("=====================");
            Console.WriteLine("Type 'left' or 'right' and press Enter.");
            Console.WriteLine("If you don't want to choose a door just press Enter.");
            Console.Write("So which door do you take? : ");
            
            var input = Console.ReadLine();
            
            switch (input)
            {
                case "left":
                    Console.WriteLine("You chose left!");
                    break;
                case "right":
                    Console.WriteLine("You chose right!");
                    break;
                default:
                    Console.WriteLine("You didn't choose left or right!");
                    break;
            }

            Console.ReadLine();
        }
    }
}
