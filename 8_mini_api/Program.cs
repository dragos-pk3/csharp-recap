using System;
using System.Linq;
using System.Collections.Generic;
using Task8;

class Program
{
    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Inventory System");
            Console.WriteLine("1. Create Item");
            Console.WriteLine("2. View Inventory");
            Console.WriteLine("3. View Item by ID");
            Console.WriteLine("4. Update Item");
            Console.WriteLine("5. Remove Item");
            Console.WriteLine("6. Exit");

            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    CreateItem();
                    break;
                case "2":
                    ViewInventory();
                    break;
                case "3":
                    ViewItemById();
                    break;
                case "4":
                    UpdateItem();
                    break;
                case "5":
                    RemoveItem();
                    break;
                case "6":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
        }
    }
    static void CreateItem()
    {
        Console.WriteLine("Enter Item Name: ");
        var name = Console.ReadLine();

        Console.WriteLine("Enter Item Quantity: ");
        try
        {
            var quantity = int.Parse(Console.ReadLine());
            if (quantity < 1)
            {
                Console.WriteLine("Quantity must be greater than 0.");
                quantity = 1;
                return;
            }
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"{ex.Message}: Invalid input. Quantity will be set to 1.");
            quantity = 1;
            return;
        }

        Console.WriteLine("Enter Item Price: ");
        try
        {
            var price = int.Parse(Console.ReadLine());
            if (price < 0)
            {
                Console.WriteLine("Price must be greater than 0.");
                price = 0;
                return;
            }
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"{ex.Message}: Invalid input. Price will be set to 0.");
            price = 0;
            return;
        }


        Console.WriteLine("Enter Item Type:\n1.Weapon\n2.Armor\n3.Consumable\n4.Quest\n5.Misc): ");
        var type = Console.ReadLine();

        Console.WriteLine("Enter Item Description: ");
        var description = Console.ReadLine();

        Console.WriteLine("Enter Item Price: ");
        var price = int.Parse(Console.ReadLine());
    }
    static void ViewInventory()
    {
        var inventory = Inventory.GetAllItems();
        if (inventory.Count == 0)
        {
            Console.WriteLine("Inventory is empty.");
            return;
        }

        Console.WriteLine("---Inventory---");
        foreach (var item in inventory)
        {
            Console.WriteLine($"{item.Id}:{item.Name}, {item.Type}\n{item.Quantity}x {item.Price}$\n- {item.Description}\n-------");
        }
    }
    static void ViewItemById()
    {
        Console.WriteLine("Enter Item ID: ");
        var idString = Console.ReadLine();
        if (int.TryParse(idString, out int id))
        {
            var item = Inventory.GetItemById(id);
            if (item == null)
            {
                Console.WriteLine("Item not found.");
            }
            else
            {
                Console.WriteLine($"{item.Id}:{item.Name}, {item.Type}\n{item.Quantity}x {item.Price}$\n- {item.Description}\n-------");
            }
        }
        else
        {
            Console.WriteLine("Invalid ID.");
        }
    }
    static void UpdateItem()
    {
        int item;
        int quantity;

        Console.WriteLine("Enter Item ID: ");
        var idString = Console.ReadLine();
        if (int.TryParse(idString, out int id))
        {
            item = Inventory.GetItemById(id);
            if (item == null)
            {
                Console.WriteLine("Item not found.");
                return;
            }

            Console.WriteLine($"Enter New Item Name (old: {item.Name}): ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Name will be unchanged.");
                name = item.Name;
            }

            Console.WriteLine($"Enter New Item Description (old: {item.Description}): ");
            var description = Console.ReadLine();
            if (string.IsNullOrEmpty(description))
            {
                Console.WriteLine("Description will be unchanged.");
                description = item.Description;
            }

            Console.WriteLine($"Enter New Item Quantity (old: {item.Quantity}): ");
            try
            {
                quantity = int.Parse(Console.ReadLine());
                if (quantity < 1)
                {
                    Console.WriteLine("Quantity must be greater than 0.");
                    quantity = 1;
                    return;
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"{ex.Message}: Invalid input. Quantity will be unchanged.");
                quantity = item.Quantity;
                return;
            }
        }

        Console.WriteLine($"Enter New Item Type (old: {item.Price}): ");
        try
        {
            var price = int.Parse(Console.ReadLine());
            if (price < 0)
            {
                Console.WriteLine("Invalid input. Price will be unchanged.");
                price = item.Price;
                return;
            }
        }
        catch (FormatException ex)
        {
            Console.WriteLine($"{ex.Message}: Invalid input. Price will be be unchanged.");
            price = item.Price;
            return;
        }

        Console.WriteLine($"Enter New Item Type (old: {item.Type}):\n1.Weapon\n2.Armor\n3.Consumable\n4.Quest\n5.Misc): ");
        var type = Console.ReadLine();
        if (string.IsNullOrEmpty(type))
        {
            Console.WriteLine("Type will be unchanged.");
            type = item.Type;
        }
    }
    static void RemoveItem()
    {
        Console.WriteLine("Enter Item ID: ");
        var idString = Console.ReadLine();
        if (int.TryParse(idString, out int id))
        {
            bool success = Inventory.RemoveItem(id);
            Console.WriteLine(success ? "Item removed successfully." : "Item not found.");
        }
        else
        {
            Console.WriteLine("Invalid ID.");
        }
    }
}

