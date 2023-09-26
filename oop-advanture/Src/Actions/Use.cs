using System;
using oop_advanture.Src.Items;
using oop_advanture.Src.Map;
using oop_advanture.Src.Texts;

namespace oop_advanture.Src.Actions
{
    public class Use : Action
    {
        private readonly House _house;

        public Use(House house)
        {
            _house = house;
        }

        public override ActionType Name => ActionType.Use;

        public override void Execute(int arg)
        {
            if (arg == (int)ItemType.None)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Text.Language.UseError);
                Console.ResetColor();
            }else{
                var itemName = ((ItemType)arg).ToString();
                var item = _house.Player.Take(itemName);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(string.Format(Text.Language.UseSuccess, itemName));
                Console.ResetColor();
                item.Use(itemName);
            }
        }
    }
}
