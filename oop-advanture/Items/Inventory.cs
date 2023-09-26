using System;

namespace oop_advanture.Items
{
    public class Inventory
    {
        private List<Item> Items { get; } = new();
        public int Total => Items.Count;

        public void Add(Item item)
        {
            Items.Add(item);
        }

        public void Remove(Item item)
        {
            Items.Remove(item);
        }

        public Item? Find(string itemName){
            return Items.Find(item => item.Name == itemName);
        }

        public Item? Find(string itemName, bool remove){
            var item = Find(itemName);
            if (remove && item != null)
            {
                Remove(item);
            }
            return item;
        }

        public bool Contains(string itemName){
            return Find(itemName) != null;
        }

        public Item? Take(string itemName){
            return Find(itemName, true);
        }

        public void Use (string itemName, string source){
            var item = Find(itemName);
            if (item != null)
            {
                item.Use(source);
                if (item.IsSingleUse)
                {
                    Remove(item);
                }

                return;
            }
        }
    }
}
