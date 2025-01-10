class Program
{
    static void Main(string[] args)
    {
        Player player = new Player("Hero", 100, 12);
        Monster monster = new Monster("Goblin", 50, 15);

        player.AddItem("Sword");
        player.Attack_Power += 8; // Sword gives 10 attack power
        player.AddItem("Potion");


        Console.WriteLine("-------------Movement-------------");
        player.PerformMovement();
        monster.PerformMovement();

        Console.WriteLine($"{player.Name} has encountered a {monster.Name}!");
        Console.WriteLine("----------------------------------");
        player.PrintStats();
        Console.WriteLine("----------------VS----------------");
        monster.PrintStats();

        Console.WriteLine("--------------Battle--------------");
        player.Attack(monster);
        monster.Attack(player);
        player.PrintInventory();
        player.UseItem("Potion");
        player.Current_Health += 10;
        player.PrintInventory();
        monster.Heal(10);
        player.Attack(monster);
        Console.WriteLine($"{monster.Name} is enraged and will perform a powerful attack!");
        monster.Attack_Power = 50;
        monster.Attack(player);

        Console.WriteLine("-----------HealthStatus-----------");
        Console.WriteLine($"{player.Name} has ({player.Current_Health}/{player.Max_Health}) health.");
        Console.WriteLine($"{monster.Name} has ({monster.Current_Health}/{monster.Max_Health}) health.");

    }
}