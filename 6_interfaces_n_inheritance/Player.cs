class Player : Character, IEntity
{
    private List<string> inventory;

    public Player(string name, int maxHealth, int attackPower) : base(name, maxHealth, attackPower)
    {
        inventory = new List<string>();
    }

    public override void PerformMovement()
    {
        if (Current_Health <= 0)
        {
            Console.WriteLine($"{Name} is defeated and cannot move!");
            return;
        }

        Console.WriteLine($"{Name} uses the Player Movement Controller for movement.");
    }

    public void AddItem(string item)
    {
        inventory.Add(item);
    }

    public void UseItem(string item)
    {
        if (Current_Health <= 0)
        {
            Console.WriteLine($"{Name} is defeated and cannot use items!");
            return;
        }

        Console.WriteLine($"{Name} uses {item}");
        inventory.Remove(item);
    }

    public void PrintInventory()
    {
        Console.WriteLine($"{Name} has the following items in their inventory:");
        foreach (string item in inventory)
        {
            Console.WriteLine($"- {item}");
        }
    }
    public void TakeDamage(int damage)
    {
        Console.WriteLine($"{Name} takes {damage} damage.");
        Current_Health -= damage;
        if (Current_Health < 0)
        {
            Console.WriteLine($"{Name} has been defeated.");
            Current_Health = 0;
        }
    }

    public void Heal(int amount)
    {
        Console.WriteLine($"{Name} has been healed by {amount} points.");
        Current_Health += amount;
        if (Current_Health > Max_Health)
        {
            Console.WriteLine($"{Name} has been healed to full health.");
            Current_Health = Max_Health;
        }
    }

    public void Attack(IEntity target)
    {
        if (Current_Health <= 0)
        {
            Console.WriteLine($"{Name} is defeated and cannot attack!");
            return;
        }

        Console.WriteLine($"{Name} attacks {target.Name} for {Attack_Power} damage.");
        target.TakeDamage(Attack_Power);
    }

    public override void PrintStats()
    {
        Console.WriteLine($"Name: {Name}\nHealth: ({Current_Health}/{Max_Health})\nAttack Power: {Attack_Power}");
    }
}