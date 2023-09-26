using System;
using oop_advanture.Src.Map;
using oop_advanture.Src.Texts;

namespace oop_advanture.Src.Actions
{
    public class Go : Action
    {
        public override ActionType Name => ActionType.Go;

        private readonly House _house;

        public Go(House house)
        {
            _house = house;
        }

        // Reference action to the house to figure out where the player is
        // Check direction of the neighbor room => decide if the player can go or not
        public override void Execute(List<int> arg)
        {
            // Get current room of the player
            var currentRoom = _house.CurrentRoom;
            // Get direction that the player want to go
            var direction = (Direction)arg[1];
            // Get the index of the next room
            var nextRooomIndex = currentRoom.Neighbors[direction];
            if (nextRooomIndex == -1 || nextRooomIndex == (int)Direction.None){
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(Text.Language.GoError);
                Console.ResetColor();
            }else{
                // Set the next room to be the current room
                _house.GoToRoom(nextRooomIndex);
            }
        }
    }
}
