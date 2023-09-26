using System;
using oop_advanture.Items;
using oop_advanture.Src.Texts;

namespace oop_advanture.Src.Map
{
    public partial class House
    {
        public void DecorateRooms()
        {
            // Iterate through all rooms in the house
            foreach (var room in Rooms)
            {
                var roomDescription = Text.Language.RoomDescriptions[_random.Next(Text.Language.RoomDescriptions.Count)];
                room.Description = String.Format(Text.Language.DefaultRoomDescriptions, roomDescription, "{0}");
            }
        }

        public void PopulateRooms(List<Item> items)
        {
            // populate item to room randomly
            foreach (var item in items)
            {
                var room = Rooms[_random.Next(Rooms.Length)];
                if(room.Total == 0){
                    room.Add(item);
                }
            }
        }
    }
}
