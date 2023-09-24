using System;
using oop_advanture.Src.Texts;

namespace oop_advanture.Src.Map
{
    public partial class House
    {
        // Calculate corresponding room index of 1D array from 2D array
        private int CalculateRoomIndex(int col, int row)
        {
            return Math.Clamp(col, -1, Width) + Math.Clamp(row, -1, Height) * Width;
        }

        // Using node structure to create room
        private void CreateRoom(int width, int height)
        {
            var total = width * height;
            // Create room
            Rooms = new Room[total];
            // Create room index
            for (int i = 0; i < total; i++)
            {
                var tmpRoom = new Room();
                var col = i % Width;
                var row = i / Width;
                tmpRoom.Name = String.Format(Text.Language.DefaultRoomName, i, col, row);
            }
        }
    }
}
