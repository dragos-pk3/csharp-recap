public abstract class Character
{
    public string Name { get; set; }

    public int Max_Health { get; set; }

    public int Current_Health { get; set; }

    public int Attack_Power { get; set; }
    
    /// <summary>
    /// Constructor for the Character class
    /// </summary>
    /// <param name="name"></param>
    /// <param name="maxHealth"></param>
    /// <param name="attackPower"></param>
    protected Character(string name, int maxHealth, int attackPower)
    {

        Name = name;
        Max_Health = maxHealth;
        Current_Health = Max_Health;
        Attack_Power = attackPower;
    }

    public abstract void PerformMovement();
    public virtual void PrintStats()
    {
        Console.WriteLine($"Name: {Name}\nMax Health: {Max_Health}\nCurrent Health: {Current_Health}\nAttack Power: {Attack_Power}");
    }

}