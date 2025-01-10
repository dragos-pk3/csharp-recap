using System;
using System.Collections.Generic;
using System.Linq;
using Task3;

namespace Task3
{

    public class Program
    {
        public static void Main(string[] args)
        {
            List<Item> items = new List<Item>
            {
                new Item{Name = "Sword", Type = ItemType.Weapon, Price = 100},
                new Item{Name = "Bow", Type = ItemType.Weapon, Price = 150},
                new Item{Name = "Quiver", Type = ItemType.Special, Price = 300},
                new Item{Name = "Arrow", Type = ItemType.Consumable, Quantity = 99, Price = 10},
                new Item{Name = "Shield", Type = ItemType.Armor, Price = 15},
                new Item{Name = "Chainmail", Type = ItemType.Armor, Price = 50},
                new Item{Name = "Potion", Type = ItemType.Consumable, Quantity = 99, Price = 5},
                new Item{Name = "Quest Scroll", Type = ItemType.Special, Price = 5},
                new Item{Name = "Compass", Type = ItemType.Special, Price = 5}
            };

            var itemsByType = items
                .GroupBy(item => item.Type)
                .ToDictionary(group => group.Key, group => group.ToList());

            PrintDictionary(itemsByType);

            var consumableItems = items
                .Where(item => item.Type == ItemType.Consumable)
                .ToList();
            PrintItems(consumableItems);
        }

        private static void PrintItems(List<Item> items)
        {
            foreach (var item in items)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private static void PrintDictionary<TKey, TValue>(Dictionary<TKey, TValue> dictionary)
        {
            foreach (var kvp in dictionary)
            {
                Console.WriteLine($"{kvp.Key}:");
                foreach (var item in (IEnumerable<Item>)kvp.Value)
                {
                    Console.WriteLine($" - {item}");
                }
            }
        }
    }

}