using System;
using oop_advanture.Src.Actions;
using oop_advanture.Src.Map;

namespace oop_advanture.Src.Texts
{
    public class English : Language
    {
        public English()
        {
            ChooseYourName = "Hello, what's your name? ";
            Welcome = "Hello {0}, welcome to the OOP - Adventure!";
            ChooseYourNameAgain = "Please enter your name: ";
            // Room name with {1} and {2} is X, Y coordinate position in grid
            DefaultRoomName = "Room {0} ({1}, {2})"; 
            // Room description with {0} is direction you are able to move based on the room that you're in
            DefaultRoomDescriptions = "You are in {0} room with door to the {1}.";
            SelectAnAction = "Use arrow key to select an action below: ";
            GoError = "You can't go that way!";
            SelectDirection = "Choose direction to go: ";
            GuildHelper = "You can use arrow key to select an action and press enter to confirm...";
            ActionNotFound = "Action not found!";
            RoomOld = "You had returned to {0}.";
            RoomNew = "You are in {0}.";
            And = "and";
            Comma = ",";
            Space = " ";
            ItemNotFound = "Item {0} not found!";
            Directions = Enum.GetValues(typeof(Direction))
                .Cast<Direction>()
                .ToDictionary(t => t, t => t.ToString());
            Actions = Enum.GetValues(typeof(ActionType))
                .Cast<ActionType>()
                .ToDictionary(t => t, t => t.ToString());
            RoomDescriptions = new List<string>(){
                "normal",
                "cold",
                "warm",
                "strange",
                "dark",
                "bright",
                "scary"
            };
        }
    }
}
