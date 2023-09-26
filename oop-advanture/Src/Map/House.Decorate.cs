using System;
using oop_advanture.Src.Texts;

namespace oop_advanture.Src.Map
{
    public partial class House
    {
        public void DecorateRooms(){
            // Iterate through all rooms in the house
            foreach (var room in Rooms)
            {
                var roomDescription = Text.Language.RoomDescriptions[_random.Next(Text.Language.RoomDescriptions.Count)];
                room.Description = String.Format(Text.Language.DefaultRoomDescriptions, roomDescription, "{0}");
            }
        }
    }
}
