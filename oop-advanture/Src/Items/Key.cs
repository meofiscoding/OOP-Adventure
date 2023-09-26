using System;
using oop_advanture.Src.Map;
using oop_advanture.Src.Texts;

namespace oop_advanture.Src.Items
{
    public class Key : Item
    {
        private readonly House _house;

        public Key(House house)
        {
            _house = house;
            // Ensure when user pick the key up and then key will disappear right after
            CanTake = true;
            IsSingleUse = true;
        }

        public override string Name => Text.Language.Key;

        public override void Use(string source)
        {
            _house.CurrentRoom.Use(Text.Language.Chest, Name);
        }
    }
}
