using System;
using oop_advanture.Src.Actions;

namespace oop_advanture.Src.Texts
{
    public class English : Language
    {
        public English()
        {
            ChooseYourName = "Hello, what's your name? ";
            Welcome = "Hello {0}, welcome to the oop-adventure!";
            ChooseYourNameAgain = "Please enter your name: ";
            // Room name with {1} and {2} is X, Y coordinate position in grid
            DefaultRoomName = "Room {0} ({1}, {2})"; 
            // Room description with {0} is direction you are able to move based on the room that you're in
            DefaultRoomDescriptions = "You are in room with door to the {0}.";
            SelectAnAction = "Use arrow key to select an action below: ";
            InvalidAction = "Invalid action, please try again!";
            Actions = new Dictionary<ActionType, string>
            {
                {ActionType.Go, "Go"},
                {ActionType.Quit, "Quit"},
            };
        }
    }
}
