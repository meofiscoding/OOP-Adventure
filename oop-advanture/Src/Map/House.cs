using System;
using oop_advanture.Src.Character;

namespace oop_advanture.Src.Map
{
    // This partial keyword is tell to compiler to look for the other part of this class
    // and its gonna concatinate them together into one class when it compile
    public partial class House
    {
        public Player Player { get; }

        private readonly Random _random = new(1234);

        public int Width { get; set; }
        public int Height { get; set; }
        public Room[] Rooms { get; private set; }

        public House(Player player)
        {
            Player = player;
        }
    }
}
