using System;
using oop_advanture.Src.Texts;

namespace oop_advanture.Items
{
    public class Gold : Item
    {
        public int Value { get; private set; }

        public Gold(int value)
        {
            Value = value;
            CanTake = true;
        }

        public override string Name
        {
            get
            {
                var ending = Value == 1 ? Text.Language.Coin : Text.Language.Coins;
                return string.Format(Text.Language.Gold, Value.ToString(), ending);
            }
        }
    }
}
