class Program
{
        private static bool isKeyDisabled = false;
        static async Task Main(string[] args)
        {
            Console.WriteLine("Press A or D.");
            Console.WriteLine("Press R to disable A for 5 seconds.");
            Console.WriteLine("Press Escape to exit.");
            Console.WriteLine();

            while (true)
            {
                if (!Console.KeyAvailable)
                {
                    await Task.Delay(100);
                    continue;
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept:true);
                
                if (keyInfo.Key == ConsoleKey.Escape)
                    break;

                switch(keyInfo.Key)
                {
                    case ConsoleKey.A:
                        if (!isKeyDisabled)
                            Console.WriteLine("A pressed");
                        else
                            Console.WriteLine("A is disabled");
                        break;
                    case ConsoleKey.D:
                        Console.WriteLine("D pressed");
                        break;
                    case ConsoleKey.R:
                        Console.WriteLine("R pressed -> A is disabled for 5 seconds");
                        _ = DisableAKey();
                        break;
                }
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey(true);
        }

        private static async Task DisableAKey()
        {
            isKeyDisabled = true;
            await Task.Delay(5000);
            isKeyDisabled = false;
            Console.WriteLine("A is ready to go");
        }
}
