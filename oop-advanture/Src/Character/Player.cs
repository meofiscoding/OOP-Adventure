using System;
using oop_advanture.Items;

namespace oop_advanture.Src.Character
{
    public class Player : Character, IInventory
    {
        private readonly IInventory _inventory;
        public Player(string name) : base(name)
        {
            _inventory = new Inventory();
        }

        public int Total => _inventory.Total;

        public List<string> InventoryItems => _inventory.InventoryItems;

        public void Add(Item item)
        {
            _inventory.Add(item);
        }

        public bool Contains(string itemName)
        {
            return _inventory.Contains(itemName);
        }

        public Item? Find(string itemName)
        {
            return _inventory.Find(itemName);
        }

        public Item? Find(string itemName, bool remove)
        {
            return _inventory.Find(itemName, remove);
        }

        public void Remove(Item item)
        {
            _inventory.Remove(item);
        }

        public Item? Take(string itemName)
        {
            return _inventory.Take(itemName);
        }

        public void Use(string itemName, string source)
        {
            _inventory.Use(itemName, source);
        }
    }
}
