using System;

namespace oop_advanture.Helper
{
    public static class Helper
    {
        public static int DisplayMenuOption<T>(int selectedIndex, Dictionary<T, string> options)
        {
            while (true)
            {
                // User select action
                foreach (var item in options)
                {
                    if (Convert.ToInt32(item.Key) == selectedIndex)
                    {
                        // only highlight current line
                        Console.BackgroundColor = ConsoleColor.Gray;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Console.WriteLine($"> {item.Value}");
                        Console.ResetColor();
                    }
                    else
                    {
                        // Add 2 more space to fully over write "> " part
                        Console.WriteLine($"{item.Value}  ");
                    }
                }

                // Enter key to select
                var key = Console.ReadKey(true).Key;
                // replace the old action part by the new one
                Console.SetCursorPosition(0, Console.CursorTop - options.Count);
                if (key == ConsoleKey.Enter)
                {
                    // Set position to the end of the line
                    Console.SetCursorPosition(0, Console.CursorTop + options.Count);
                    return selectedIndex;
                }
                switch (key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex = selectedIndex - 1 < 0 ? options.Count - 1 : selectedIndex - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        selectedIndex = (selectedIndex + 1) % options.Count;
                        break;
                }
            }
        }

        public static void DrawCastle()
        {
            // get file from current directory
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "Helper/Castle.txt");
            try
            {
                // Check if the file exists
                if (File.Exists(filePath))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    // Read the file using a StreamReader
                    using StreamReader reader = new(filePath);
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // Print each line to the console
                        Console.WriteLine(line);
                    }
                }
                else
                {
                    Console.WriteLine("The specified file does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
