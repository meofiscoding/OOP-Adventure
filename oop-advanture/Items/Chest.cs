using System;
using oop_advanture.Src.Map;
using oop_advanture.Src.Texts;

namespace oop_advanture.Items
{
    public class Chest : Item, IInventory
    {
        // reference to House to find player and add item to Player once they take item out of chest
        private readonly House _house;
        private readonly Inventory _inventory = new();

        public override string Name => Text.Language.Chest;
        public static bool IsLocked => true;

        public Chest(House house, List<Item?> items)
        {
            // Avoid player from accidentally take item from the room
            CanTake = false;
            _house = house;
            foreach (var item in items)
            {
                if (item != null)
                {
                    _inventory.Add(item);
                }
            }
        }

        public int Total => ((IInventory)_inventory).Total;

        public List<string> InventoryItems => ((IInventory)_inventory).InventoryItems;

        public override void Use(string source)
        {
            if(source == Text.Language.Key){
                var items = InventoryItems;
                if(IsLocked){
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine(Text.Language.UnlockChest);
                    if(items.Count == 0){
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(Text.Language.EmptyChest);
                        Console.ResetColor();
                    }else{
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(string.Format(Text.Language.ChestFounded, Text.Language.Join(items, Text.Language.And)));
                        Console.ResetColor();
                        // Add item to Player
                        foreach (var itemName in items)
                        {
                            var item = Take(itemName);
                            _house.Player.Add(item);
                        }
                    }
                }
            }
        }

        public void Add(Item item)
        {
            ((IInventory)_inventory).Add(item);
        }

        public bool Contains(string itemName)
        {
            return ((IInventory)_inventory).Contains(itemName);
        }

        public Item? Find(string itemName)
        {
            return ((IInventory)_inventory).Find(itemName);
        }

        public Item? Find(string itemName, bool remove)
        {
            return ((IInventory)_inventory).Find(itemName, remove);
        }

        public void Remove(Item item)
        {
            ((IInventory)_inventory).Remove(item);
        }

        public Item? Take(string itemName)
        {
            return ((IInventory)_inventory).Take(itemName);
        }

        public void Use(string itemName, string source)
        {
            ((IInventory)_inventory).Use(itemName, source);
        }
    }
}
