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

// Create items
var items = new List<Item>(){
    new Key(house),
    new Key(house),
    new Key(house),
    new Key(house),
    new Key(house),
    new Key(house),
    new Key(house),
    new Key(house),
    new Key(house),
    new Key(house),
    new Key(house),
    new Chest(house, new List<Item?>(){
        new Gold(10),
        new Gold(20),
        new Gold(30),
        new Gold(40),
        new Gold(50),
        new Gold(60),
        new Gold(70),
        new Gold(80),
        new Gold(90),
        new Gold(100),
    }),
};

// Populate items to rooms
house.PopulateRooms(items);

//Register actions
PlayerAction.Instance.RegisterAction(new Go(house));
house.GotoStartingRoom();
PlayerAction.Instance.RegisterAction(new Backpack(player));
PlayerAction.Instance.RegisterAction(new Take(house));

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
            Console.WriteLine(Text.Language.SelectItem);
            Console.ResetColor();
            var availableItems = house.CurrentRoom.InventoryItems
                .Select(t => (ItemType)Enum.Parse(typeof(ItemType), t))
                // add none option
                .Append(ItemType.None)
                .ToDictionary(t => t, t => t.ToString());
            selectedItemIndex = Helper.DisplayMenuOption(selectedItemIndex, availableItems);
            PlayerAction.Instance.Execute(new List<int> { selectedActionIndex, selectedItemIndex });
            break;
    }
}
