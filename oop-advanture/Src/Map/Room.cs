using System;
using oop_advanture.Src.Texts;

namespace oop_advanture.Src.Map
{
    public class Room
    {
        public string Name { get; set; } = Text.Language.DefaultRoomName;
        public string Description { get; set; } = Text.Language.DefaultRoomDescriptions;

        // Specify how many neighbor room this room has on each direction
        public Dictionary<Direction, int> Neighbors { get; set; } = new Dictionary<Direction, int>(){
            {Direction.None, -1},
            {Direction.North, -1},
            {Direction.East, -1},
            {Direction.South, -1},
            {Direction.West, -1}
        };

        public bool IsVisited { get; set; }
    }
}
