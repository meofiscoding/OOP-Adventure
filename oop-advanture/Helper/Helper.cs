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
            //     >>>                                                       >>>
            //     |                                                         |
            //    /\                                                        /\
            //   |  |                                                      |  |
            //  /----\                  Lord Dark's Keep                  /----\
            // [______]             Where Brave Knights Tremble          [______]
            //  |    |         _____                        _____         |    |
            //  |[]  |        [     ]                      [     ]        |  []|
            //  |    |       [_______][ ][ ][ ][][ ][ ][ ][_______]       |    |
            //  |    [ ][ ][ ]|     |  ,----------------,  |     |[ ][ ][ ]    |
            //  |             |     |/'    ____..____    '\|     |             |
            //   \  []        |     |    /'    ||    '\    |     |        []  /
            //    |      []   |     |   |o     ||     o|   |     |  []       |
            //    |           |  _  |   |     _||_     |   |  _  |           |
            //    |   []      | (_) |   |    (_||_)    |   | (_) |       []  |
            //    |           |     |   |     (||)     |   |     |           |
            //    |           |     |   |      ||      |   |     |           |
            //  /''           |     |   |o     ||     o|   |     |           ''\
            // [_____________[_______]--'------''------'--[_______]_____________]
            int castleWidth = 67;
            int castleHeight = 17;
            int castleWidthHalf = castleWidth / 2;
            int towerWidth = 6;
            int flagIndex = (towerWidth + 2) / 2;
            int flagIndexSymmetric = castleWidth - flagIndex - 1;
            for (int row = 0; row < castleHeight; row++)
            {
                for (int col = 0; col < castleWidth; col++)
                {
                    // Flag index placed at (towerWidth+2)/2 and the symmetric index of it in left side
                    if (row == 0)
                    {
                        if (col == flagIndex || col == flagIndexSymmetric)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            // Write > 3 times to print flag
                            Console.Write(new string('>', 4));
                            col += 3;
                        }
                        else
                        {
                            Console.Write(' ');
                        }
                    }
                    // Flag
                    if (row == 1)
                    {
                        if (col == 0)
                        {
                            Console.WriteLine();
                        }
                        else
                        {
                            if (col == flagIndex || col == flagIndexSymmetric)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.Write("|");
                            }
                            else
                            {
                                Console.Write(' ');
                            }
                        }
                    }
                    // Flag holder
                    if (row == 2)
                    {
                        if (col == 0)
                        {
                            Console.WriteLine();
                        }
                        else
                        {
                            if (col == flagIndex || col == flagIndexSymmetric)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                Console.Write("/\\");
                                col++;
                            }
                            else
                            {
                                Console.Write(' ');
                            }
                        }
                    }
                    // Castle top
                    if (row == 3)
                    {
                        if (col == 0)
                        {
                            Console.WriteLine();
                        }
                        else
                        {
                            if (col == flagIndex - 1 || col == flagIndexSymmetric - 1 || col == flagIndex + 2 || col == flagIndexSymmetric + 2)
                            {
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                Console.Write("|");
                            }
                            else
                            {
                                Console.Write(' ');
                            }
                        }
                    }
                    // Roof
                    if (row == 4)
                    {
                        if (col == 0)
                        {
                            Console.WriteLine();
                        }
                        else
                        {
                            if (col == flagIndex - 2 || col == flagIndexSymmetric - 2)
                            {
                                Console.Write("/");
                            }
                            else if (col == flagIndex + 3 || col == flagIndexSymmetric + 3)
                            {
                                Console.Write("\\");
                            }
                            else if ((col > flagIndex - 2 && col < flagIndex + 3) || (col > flagIndexSymmetric - 2 && col < flagIndexSymmetric + 3))
                            {
                                Console.Write("-");
                            }
                            else
                            {
                                Console.Write(' ');
                            }
                        }
                    }
                    // Roof holder
                    if (row == 5)
                    {
                        if (col == 0)
                        {
                            Console.WriteLine();
                        }
                        else
                        {
                            if (col == flagIndex - 3 || col == flagIndexSymmetric - 3)
                            {
                                Console.Write("[");
                            }
                            else if (col == flagIndex + 4 || col == flagIndexSymmetric + 4)
                            {
                                Console.Write("]");
                            }
                            else if ((col > flagIndex - 3 && col < flagIndex + 4) || (col > flagIndexSymmetric - 3 && col < flagIndexSymmetric + 4))
                            {
                                Console.Write("_");
                            }
                            else
                            {
                                Console.Write(' ');
                            }
                        }
                    }
                    if (row > 5 && row < 11)
                    {
                        if (col == 0)
                        {
                            Console.WriteLine();
                            Console.Write(' ');
                        }
                        else
                        {
                            if (col == 1 || col == towerWidth || col == castleWidth - 1 - 2 || col == castleWidth - 1 - towerWidth - 1)
                            {
                                Console.Write('|');
                            }
                            else if ((col == 2 || col == castleWidth - 1 - 4) && row == 7)
                            {
                                Console.Write("[]");
                                col++;
                            }
                            else
                            {
                                Console.Write(' ');
                            }
                        }
                    }
                }
            }

        }
    }
}
