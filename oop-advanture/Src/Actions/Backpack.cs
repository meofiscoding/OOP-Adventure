using System;
using oop_advanture.Src.Items;
using oop_advanture.Src.Texts;

namespace oop_advanture.Src.Actions
{
    public class Backpack : Action
    {
        private readonly IInventory _inventory;

        public Backpack(IInventory inventory)
        {
            _inventory = inventory;
        }

        public override ActionType Name => ActionType.Backpack;

        public override void Execute(int args)
        {
            var items = _inventory.InventoryItems;
            if(items.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Text.Language.BackpackEmpty);
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(Text.Language.BackpackList);
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }
    }
}
