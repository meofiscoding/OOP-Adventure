﻿using oop_advanture.Helper;
using oop_advanture.Src.Actions;
using oop_advanture.Src.Character;
using oop_advanture.Src.Map;
using oop_advanture.Src.Texts;

// Language
Text.SetLanguage(new English());
Console.WriteLine(Text.Language.ChooseYourName);

// Name
var name = Console.ReadLine();

while (String.IsNullOrEmpty(name))
{
    Console.WriteLine(Text.Language.ChooseYourNameAgain);
    name = Console.ReadLine();
}

// Welcome
Player player = new(name);
Console.WriteLine(Text.Language.Welcome, player.Name);

// Create house and room
var house = new House(player);
house.CreateRoom(3, 3);

//Register actions
PlayerAction.Instance.RegisterAction(new Go(house));
house.GotoStartingRoom();

Room? newRoom = null;
if (newRoom != house.CurrentRoom)
{
    newRoom = house.CurrentRoom;
    Console.WriteLine(house.CurrentRoom.ToString());
}
// Selected Action
int selectedActionIndex = (int)ActionType.Go;
// Selected Direction
int selectionDirectionIndex = (int)Direction.North;

while (selectedActionIndex != (int)ActionType.Quit)
{
    // Promt user to select action
    Console.WriteLine(Text.Language.SelectAnAction);
    Console.WriteLine(Text.Language.GuildHelper);
    selectedActionIndex = Helper.DisplayMenuOption(selectedActionIndex, Text.Language.Actions);
    switch (selectedActionIndex)
    {
        case (int)ActionType.Go:
            Console.WriteLine(Text.Language.SelectDirection);
            Console.WriteLine(Text.Language.GuildHelper);
            selectionDirectionIndex = Helper.DisplayMenuOption(selectionDirectionIndex, Text.Language.Directions);
            PlayerAction.Instance.Execute(new List<int> { selectedActionIndex, selectionDirectionIndex });
            break;
    }
}