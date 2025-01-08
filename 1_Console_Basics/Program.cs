using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine() ?? string.Empty; // ?? string.Empty is a null-coalescing operator that returns the right side if the left side is null  

            Console.WriteLine($"Hello, {name}!");
            Console.WriteLine("We are glad to see you, " + name + "!");

            Console.WriteLine("Enter your power level:");
            
            int powerLevel = int.Parse(Console.ReadLine() ?? string.Empty);

            Console.WriteLine($"You claim your power level is {powerLevel}!");

            Console.WriteLine(powerLevel > 9000 && powerLevel < 10000 ? "Indeed, you are powerfull!" : "You're either weak or you're lying!");
        }
    }
}