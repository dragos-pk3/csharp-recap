



class Program{
    public static void Main(string[] args){


        Console.Write("Input a number:");

        try{
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine($"\nYou entered: {number}");
        }
        catch(FormatException ex){
            Console.WriteLine($"{ex.Message}");
            //throw;
        }
        Console.WriteLine("What is your name?");
        string name = Console.ReadLine();
        Console.WriteLine($"Hello, {name}!");
    }
}
