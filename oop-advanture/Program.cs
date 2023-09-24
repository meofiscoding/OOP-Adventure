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

Player player = new(name);
Console.WriteLine(Text.Language.Welcome, player.Name);

// Action
int selectedOptionIndex = (int)ActionType.Go;
Console.WriteLine(Text.Language.SelectAnAction);

while (true)
{
    // User select action
    foreach (var action in Text.Language.Actions)
    {
        if ((int)action.Key == selectedOptionIndex)
        {
            // only highlight current line
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine($"> {action.Value}");
            Console.ResetColor();
        }
        else
        {
            // Add 2 morespace to fully over write "> " part
            Console.WriteLine($"{action.Value}  ");
        }
    }

    // Enter key to select
    var key = Console.ReadKey(true).Key;
    // replace the old action part by the new one
    Console.SetCursorPosition(0, Console.CursorTop - Text.Language.Actions.Count);
    if (key == ConsoleKey.Enter)
    {
        Console.WriteLine($"You selected {Text.Language.Actions[(ActionType)selectedOptionIndex]}");
        // TODO: Implement action when enter
        break;
    }
    switch (key)
    {
        case ConsoleKey.UpArrow:
            selectedOptionIndex = Math.Max(0, selectedOptionIndex - 1);
            break;

        case ConsoleKey.DownArrow:
            selectedOptionIndex = Math.Min(Text.Language.Actions.Count - 1, selectedOptionIndex + 1);
            break;
    }
}

var house = new House(player);
