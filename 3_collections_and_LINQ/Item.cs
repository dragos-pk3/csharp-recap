namespace Task3{

    public enum ItemType{
        Weapon,
        Armor,
        Consumable,
        Special
    }

    public class Item{

        private int _quantity;

        public string Name {get; set;}
        public int Quantity {
            get => _quantity;
            set {
                if (Type == ItemType.Consumable)
                    _quantity = value;
                else
                    _quantity = 0;
            }
        }
        public ItemType Type {get; set;}
        public int Price {get; set;}

        public override string ToString(){
            return $"{Name}({Type}): ({Quantity}x) - {Price} gold";
        }

    }
}