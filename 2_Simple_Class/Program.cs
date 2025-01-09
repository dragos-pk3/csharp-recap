using System;
using Task2;

class Program
{
    static void Main(string[] args)
    {
        Player player = new Player("John", 9001);

        player.TakeDamage(5);

        player.ReadStats(player.PlayerStats());
    }
}
