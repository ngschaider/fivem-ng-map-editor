namespace EssentialsExtended {
    public class InventoryItem {

        public dynamic Raw;
        public string Name => Raw.name;
        public int Count => Raw.count;
        public string Label => Raw.label;
        public double Weight => Raw.weight;
        public bool Usable => Raw.usable;
        public bool Rare => Raw.rare;
        public bool CanRemove => Raw.canRemove;

        public InventoryItem() {
        }

        public InventoryItem(dynamic data) => Raw = data;

    }
}