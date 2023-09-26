namespace oop_advanture.Src.Items
{
    public interface IInventory
    {
        int Total { get; }
        public List<string> InventoryItems { get; }
        void Add(Item item);
        bool Contains(string itemName);
        Item? Find(string itemName);
        Item? Find(string itemName, bool remove);
        void Remove(Item item);
        Item? Take(string itemName);
        void Use(string itemName, string source);
    }
}