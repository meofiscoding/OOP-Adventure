using oop_advanture.Helper;
using oop_advanture.Src.Items;
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
// write welcome and set color of text to blue
Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine(Text.Language.Welcome, player.Name);

// Castle 
Helper.DrawCastle();
Console.ResetColor();

// Create house and room
var house = new House(player);
house.CreateRoom(3, 3);
house.DecorateRooms();

// Generate number of item key and chest equal to 60% number of rooms
var numberOfItems = (int)Math.Round(house.Rooms.Length * 0.6);
var items = Helper.GenerateItems(numberOfItems, house);

// Populate items to rooms
house.PopulateRooms(items);

//Register actions
PlayerAction.Instance.RegisterAction(new Go(house));
house.GotoStartingRoom();
int highlightedRow = 0; // Change these values to highlight a specific cell
int highlightedCol = 1; // Change these values to highlight a specific cell
Helper.RoomsVisualization(highlightedRow, highlightedCol);
PlayerAction.Instance.RegisterAction(new Backpack(player));
PlayerAction.Instance.RegisterAction(new Take(house));
PlayerAction.Instance.RegisterAction(new Use(house));

// Init room
Room? newRoom = null;

// Selected Action
int selectedActionIndex = (int)ActionType.Go;
// Selected Direction
int selectionDirectionIndex = (int)Direction.None;
// Selected Items
int selectedItemIndex = (int)ItemType.None;

while (selectedActionIndex != (int)ActionType.Quit)
{
    if (newRoom != house.CurrentRoom)
    {
        newRoom = house.CurrentRoom;
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(house.CurrentRoom.ToString());
        Console.ResetColor();
    }
    // Promt user to select action
    Console.WriteLine(Text.Language.SelectAnAction);
    Console.WriteLine(Text.Language.GuildHelper);
    Console.ResetColor();
    selectedActionIndex = Helper.DisplayMenuOption(selectedActionIndex, Text.Language.Actions);
    switch (selectedActionIndex)
    {
        case (int)ActionType.Go:
            Console.WriteLine(Text.Language.SelectDirection);
            Console.WriteLine(Text.Language.GuildHelper);
            selectionDirectionIndex = Helper.DisplayMenuOption(selectionDirectionIndex, Text.Language.Directions);
            PlayerAction.Instance.Execute(new List<int> { selectedActionIndex, selectionDirectionIndex });
            break;

        case (int)ActionType.Backpack:
            PlayerAction.Instance.Execute(new List<int> { selectedActionIndex, 0 });
            break;

        case (int)ActionType.Take:
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Text.Language.SelectItemToTake);
            Console.ResetColor();
            var availableItemsToTake = house.CurrentRoom.InventoryItems
                .Select(t => (ItemType)Enum.Parse(typeof(ItemType), t))
                // add none option
                .Append(ItemType.None)
                .ToDictionary(t => t, t => t.ToString());
            selectedItemIndex = Helper.DisplayMenuOption(selectedItemIndex, availableItemsToTake);
            PlayerAction.Instance.Execute(new List<int> { selectedActionIndex, selectedItemIndex });
            break;

        case (int)ActionType.Use:
            selectedItemIndex = (int)ItemType.None;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(Text.Language.SelectItemToUse);
            Console.ResetColor();
            var availableItemsToUse = house.Player.InventoryItems
                .Select(t => (ItemType)Enum.Parse(typeof(ItemType), t))
                // add none option
                .Append(ItemType.None)
                .ToDictionary(t => t, t => t.ToString());
            selectedItemIndex = Helper.DisplayMenuOption(selectedItemIndex, availableItemsToUse);
            PlayerAction.Instance.Execute(new List<int> { selectedActionIndex, selectedItemIndex });
            break;
    }
}
