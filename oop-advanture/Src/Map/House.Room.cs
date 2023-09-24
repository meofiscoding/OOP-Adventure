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
        public void CreateRoom(int width, int height)
        {
            Width = Math.Clamp(width, 2, 10);
            Height = Math.Clamp(height, 2, 10);
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

                // Calculate neighbor room index
                if (col < Width - 1)
                {
                    tmpRoom.Neighbors[Direction.East] = CalculateRoomIndex(col + 1, row);
                }
                // col > 0 && col > Width - 1
                if (col > 0)
                {
                    tmpRoom.Neighbors[Direction.West] = CalculateRoomIndex(col - 1, row);
                }
                if (row < Height - 1)
                {
                    tmpRoom.Neighbors[Direction.South] = CalculateRoomIndex(col, row + 1);
                }
                if (row > 0)
                {
                    tmpRoom.Neighbors[Direction.North] = CalculateRoomIndex(col, row - 1);
                }
                Rooms[i] = tmpRoom;
            }
        }
    }
}
