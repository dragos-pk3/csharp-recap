class Program{
    static void Main(string[] args){
        PlayerStats player = new PlayerStats{Name = "Superhero"};
        PlayerStats player2 = new PlayerStats{Name = "Hero"};
        player2.LoadStats("Hero.txt");
        
        PlayerStats player3 = new PlayerStats{Name = "Legendary Hero"};
        player3.LoadStats("Legendary Hero.json");

        player.Endurance = 5;
        player.Force = 5;
        player.Wisdom = 5;
        player.Agility = 5;

        Console.WriteLine($"Player {player.Name}\n\nStats:\n- Endurance:{player.Endurance}\n- Force: {player.Force}\n- Wisdom: {player.Wisdom}\n- Agility: {player.Agility}");
       
        Console.WriteLine("Player leveling up...");
        player.Endurance += 3;
        player.Force += 1;
        player.Wisdom += 0;
        player.Agility += 10;

        player.SaveStatsToJson();
        player.SaveStatsToFile();
        
        Console.WriteLine($"Player {player2.Name}\n\nStats:\n- Endurance:{player2.Endurance}\n- Force: {player2.Force}\n- Wisdom: {player2.Wisdom}\n- Agility: {player2.Agility}");

        Console.WriteLine($"Player {player3.Name}\n\nStats:\n- Endurance:{player3.Endurance}\n- Force: {player3.Force}\n- Wisdom: {player3.Wisdom}\n- Agility: {player3.Agility}");

    }
}