namespace oop_advanture.Src.Map
{
    public partial class House
    {
        public Room CurrentRoom { get; set; }
        public void GoToRoom(int index)
        {
            if (CurrentRoom != null)
            {
                CurrentRoom.IsVisited = true;
            }

            CurrentRoom = Rooms[index];
            CurrentRoom.Coordinate = new Coordinate
            {
                Row = index / Width,
                Col = index % Width
            };
        }

        public void GotoStartingRoom()
        {
            GoToRoom(_random.Next(Rooms.Length));
        }
    }
}
