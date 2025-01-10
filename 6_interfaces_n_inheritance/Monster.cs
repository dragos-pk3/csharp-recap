class Monster : Character, IEntity
{
    private const int MIN_DIE_CAP = 1;
    private static readonly int MAX_DIE_CAP = new Random().Next(3) switch { 0 => 7, 1 => 13, _ => 21 };
    //private static readonly int MAX_DIE_CAP = 3; // This is a test to see if the die roll is working.
    private static readonly int HIGHEST_DIE_ROLL = MAX_DIE_CAP - 1;

    private Random diceRoll = new Random(); // This will use time-based seed

    public Monster(string name, int maxHealth, int attackPower) : base(name, maxHealth, attackPower)
    {
        Console.WriteLine($"{Name} has been created with a {HIGHEST_DIE_ROLL} die cap.");
    }

    public override void PerformMovement()
    {
        if (Current_Health <= 0)
        {
            Console.WriteLine($"{Name} is defeated and cannot move!");
            return;
        }

        Console.WriteLine($"{Name} uses the AI Pathfinding System for movement.");
    }

    public void Attack(IEntity target)
    {
        if (Current_Health <= 0)
        {
            Console.WriteLine($"{Name} is defeated and cannot attack!");
            return;
        }

        if (RollDice())
        {
            Console.WriteLine($"{Name} lands a critical hit on {target.Name}!");
            target.TakeDamage(Attack_Power * 2);
        }
        else
        {
            Console.WriteLine($"{Name} attacks {target.Name} for {Attack_Power} damage.");
            target.TakeDamage(Attack_Power);
        }
    }

    public void Heal(int amount)
    {
        if (Current_Health <= 0)
        {
            Console.WriteLine($"{Name} is defeated and cannot perform actions!");
            return;
        }

        Console.WriteLine($"Since {Name} is a monster, it cannot heal.");
        Console.WriteLine($"{Name} is rolling to avoid self damage.");
        if (RollDice())
        {
            Console.WriteLine($"{Name} has rolled a 6 and has avoided self damage successfully.");
        }
        else
        {
            Current_Health -= amount;
            Console.WriteLine($"{Name} will take {amount} damage.");
        }
    }

    public void TakeDamage(int damage)
    {
        if (RollDice())
        {
            Console.WriteLine($"{Name} has rolled a 6 and damage has been halved.");
            Current_Health -= damage / 2;
        }
        else
        {
            Console.WriteLine($"{Name} takes {damage} damage.");
            Current_Health -= damage;
        }
    }

    private bool RollDice()
    {
        return diceRoll.Next(MIN_DIE_CAP, MAX_DIE_CAP) == HIGHEST_DIE_ROLL;
    }
    public override void PrintStats()
    {
        Console.WriteLine($"Name: {Name}\nHealth: ({Current_Health}/{Max_Health})\nAttack Power: {Attack_Power}");
    }
}