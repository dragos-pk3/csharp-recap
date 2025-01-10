using System.Collections.Generic;
using System.Linq;

namespace Task8
{
    public static class Inventory
    {
        private static List<Item> _items = new List<Item>();

        private static int _nextId = 1;

        public static List<Item> Items => _items;
        #region CREATE
        public static void AddItem(Item item)
        {
            item.Id = _nextId++;
            _items.Add(item);
            return item;
        }
        #endregion
        #region READ

        public static Item GetItemById(int id)
        {
            return _items.FirstOrDefault(i => i.Id == id);
        }

        public static List<Item> GetAllItems()
        {
            return _items;
        }
        #endregion
        #region UPDATE
        public static bool UpdateItem(Item updatedItem)
        {
            var existingItem = GetItemById(updatedItem.Id);
            if (existingItem == null) return false;
            existingItem.Name = updatedItem.Name;
            existingItem.Quantity = updatedItem.Quantity;
            existingItem.Price = updatedItem.Price;
            existingItem.Description = updatedItem.Description;
            existingItem.Type = updatedItem.Type;
            return true;
        }
        #endregion
        #region DELETE
        public static bool RemoveItem(int id)
        {
            var itemToRemove = GetItemById(id);
            if (itemToRemove == null) return false;
            _items.Remove(itemToRemove);
            return true;
        }
        #endregion
    }
}