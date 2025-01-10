namespace Task8
{
    public enum ItemType
    {
        Weapon,
        Armor,
        Consumable,
        Quest,
        Misc
    }
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public ItemType Type { get; set; }

    }
}