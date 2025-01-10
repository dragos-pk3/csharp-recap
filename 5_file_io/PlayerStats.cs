using Newtonsoft.Json;

public class PlayerStats
{

    public required string Name { get; set; }
    public int Endurance { get; set; }
    public int Force { get; set; }
    public int Wisdom { get; set; }
    public int Agility { get; set; }


    private Dictionary<string, int> PlayerStatsToDictionary()
    {
        return new Dictionary<string, int>(){
                {"Endurance", Endurance},
                {"Force", Force},
                {"Wisdom", Wisdom},
                {"Agility", Agility}
            };
    }

    private void LoadStatsFromDictionary(Dictionary<string, int> stats)
    {
        Endurance = stats["Endurance"];
        Force = stats["Force"];
        Wisdom = stats["Wisdom"];
        Agility = stats["Agility"];
    }
    public void SaveStatsToFile()
    {
        string filename = Name + ".txt";
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var stat in PlayerStatsToDictionary())
            {
                writer.WriteLine($"{stat.Key}: {stat.Value}");
            }
        }
    }

    public void SaveStatsToJson()
    {
        string json = JsonConvert.SerializeObject(PlayerStatsToDictionary());
        File.WriteAllText(Name + ".json", json);
    }

    public void LoadStats(string filename)
    {
        try
        {
            Dictionary<string, int> stats = new Dictionary<string, int>();
            
            if (filename.EndsWith(".json"))
            {
                string jsonContent = File.ReadAllText(filename);
                LoadStatsFromDictionary(JsonConvert.DeserializeObject<Dictionary<string, int>>(jsonContent));
            }
            else if (filename.EndsWith(".txt"))
            {
                string[] lines = File.ReadAllLines(filename);

                foreach (string line in lines)
                {
                    string[] parts = line.Split(':');
                    if (parts.Length == 2)
                    {
                        string key = parts[0].Trim();
                        if( int.TryParse(parts[1].Trim(), out int value)){
                            stats[key] = value;
                        }
                    }
                }
                LoadStatsFromDictionary(stats);
            }
            else
            {
                throw new Exception("Invalid file format");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading stats: {ex.Message}");
        }
    }

}