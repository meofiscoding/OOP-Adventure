using System;
using System.Text;
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

        public override string ToString()
        {
            var sb = new StringBuilder();
            if(IsVisited){
                sb.AppendFormat(Text.Language.RoomOld, Name);
            }else{
                sb.AppendFormat(Text.Language.RoomNew, Name);
            }

            var directions = Enum.GetValues(typeof(Direction))
                .Cast<Direction>()
                .Where(t => Neighbors[t] != -1)
                .Select(t => Text.Language.Directions[t])
                .ToList();

            var description = string.Format(Description, Text.Language.Join(directions, Text.Language.And));
            sb.Append(description);
            return sb.ToString();
        }
    }
}
