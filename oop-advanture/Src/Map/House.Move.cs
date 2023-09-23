namespace oop_advanture.Src.Map
{
    public partial class House
    {
        public Room CurrentRoom { get; set; }
        public void GoToRoom(int index)
        {
            if(CurrentRoom != null){
                CurrentRoom.IsVisited = true;
            }

            CurrentRoom = Rooms[index];
        }

        public void GotoStartingRoom()
        {
            GoToRoom(_random.Next(Rooms.Length));
        }
    }
}
