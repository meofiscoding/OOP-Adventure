using System;
using oop_advanture.Src.Items;
using oop_advanture.Src.Map;
using oop_advanture.Src.Texts;

namespace oop_advanture.Src.Actions
{
    public class Take : Action
    {
        private readonly House _house;

        public Take(House house)
        {
            _house = house;
        }

        public override ActionType Name => ActionType.Take;

        public override void Execute(int arg)
        {
            var inventory = _house.CurrentRoom;
            // If not take anything then throw err 
            if((ItemType)arg == ItemType.None){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Text.Language.TakeError);
                Console.ResetColor();
            }
            // If take item then add to backpack
            else{
                // convert arg to ItemType and then to string
                var itemName = ((ItemType)arg).ToString();
                var item = inventory.Take(itemName);
                if (item.CanTake)
                {
                    _house.Player.Add(item);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(Text.Language.TookDescription, itemName);
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(Text.Language.CantTakeDescription, itemName);
                    Console.ResetColor();
                }
            }
        }
    }
}
