using System;
using Task2;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            string name = args.Length > 0 ? args[0] : GetUserName();
            
            Console.WriteLine($"Hello, {name}!");
          
            Console.WriteLine("We are glad to see you, " + name + "!");
          
            Console.Write("Enter your power level:");
            
            int powerLevel = args.Length > 1 ? int.Parse(args[1]) : int.Parse(Console.ReadLine() ?? string.Empty); // will throw an error if the input is not a number

            Console.WriteLine($"\nYou claim your power level is {powerLevel}!");

            Player player = new Player(name, powerLevel);

            player.ReadStats(player.PlayerStats());

            Console.WriteLine(powerLevel > 9000 && powerLevel < 10000 ? "Indeed, you are powerful!" : "You're either weak or you're lying!");

        }

        static string GetUserName(){
            Console.Write("Enter your name:");
            return Console.ReadLine() ?? string.Empty; // ?? string.Empty is a null-coalescing operator that returns the right side if the left side is null  
            
        }
    }
}