using oop_advanture.Helper;
using oop_advanture.Src.Actions;
using oop_advanture.Src.Character;
using oop_advanture.Src.Map;
using oop_advanture.Src.Texts;

// Language
// Text.SetLanguage(new English());
// Console.WriteLine(Text.Language.ChooseYourName);

// // Name
// var name = Console.ReadLine();

// while (String.IsNullOrEmpty(name))
// {
//     Console.WriteLine(Text.Language.ChooseYourNameAgain);
//     name = Console.ReadLine();
// }

// // Welcome
// Player player = new(name);
// // write welcome and set color of text to blue
// Console.ForegroundColor = ConsoleColor.Blue;
// Console.WriteLine(Text.Language.Welcome, player.Name);

// Castle 
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
int castleWidth = 68;
int castleHeight = 17;
int castleWidthHalf = castleWidth / 2;
int towerWidth = 4;
int pillarWidth = 5;
int pillarHeight = 9;
int towerRoofWidth = 8;
int flagIndex = towerRoofWidth / 2;
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
        if (row > 5 && row < 10)
        {
            if (col == 0)
            {
                Console.WriteLine();
                Console.Write(' ');
            }
            else
            {
                if(row == 6 && col == towerWidth + 2 + 8 +2){
                    Console.Write(new string('_', pillarWidth));
                    col += pillarWidth;
                }
                if(row == 7 && col == towerWidth + 2 + 8 +1){
                    Console.Write("[" + new string(' ', pillarWidth) + "]");
                    col += pillarWidth + 2;
                }
                if (row == 8 && col == towerWidth + 2 + 8)
                {
                    Console.Write("[" + new string('_', pillarWidth + 2) + "]");
                    col += pillarWidth + 1 + 2;
                    int count = 3;
                    while (count > 0)
                    {
                        Console.Write("[ ]");
                        count--;
                        col +=3;
                    }
                    Console.Write("[");
                    col++;
                }
                if (col == 1 || col == castleWidth - 1 - 2)
                {
                    Console.Write('|');
                }
                else if (col == castleWidth - 1 - (towerRoofWidth - 1) - 8 && row == 9)
                {
                    int count = 3;
                    while (count > 0)
                    {
                        Console.Write("[ ]");
                        count--;
                    }
                    col += 2 + (3 * 2);
                }
                else if (col == castleWidth - 1 - (towerRoofWidth - 1) && row != 9)
                {
                    Console.Write('|');
                }
                else if (col == towerWidth + 2)
                {
                    if (row == 9)
                    {
                        int count = 3;
                        while (count > 0)
                        {
                            Console.Write("[ ]");
                            count--;
                        }
                        col += 2 + (3 * 2);
                        // Pillar
                        Console.Write('|');
                        Console.Write(new string(' ', pillarWidth));
                        Console.Write('|');
                        col += pillarWidth + 2;
                    }
                    else
                    {
                        Console.Write('|');
                    }
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


// Console.ResetColor();

// // Create house and room
// var house = new House(player);
// house.CreateRoom(3, 3);

// //Register actions
// PlayerAction.Instance.RegisterAction(new Go(house));
// house.GotoStartingRoom();

// // Init room
// Room? newRoom = null;
// if (newRoom != house.CurrentRoom)
// {
//     newRoom = house.CurrentRoom;
//     Console.WriteLine(house.CurrentRoom.ToString());
// }

// // Selected Action
// int selectedActionIndex = (int)ActionType.Go;
// // Selected Direction
// int selectionDirectionIndex = (int)Direction.North;

// while (selectedActionIndex != (int)ActionType.Quit)
// {
//     // Promt user to select action
//     Console.ForegroundColor = ConsoleColor.Green;
//     Console.WriteLine(Text.Language.SelectAnAction);
//     Console.WriteLine(Text.Language.GuildHelper);
//     Console.ResetColor();
//     selectedActionIndex = Helper.DisplayMenuOption(selectedActionIndex, Text.Language.Actions);
//     switch (selectedActionIndex)
//     {
//         case (int)ActionType.Go:
//             Console.ForegroundColor = ConsoleColor.Yellow;
//             Console.WriteLine(Text.Language.SelectDirection);
//             Console.WriteLine(Text.Language.GuildHelper);
//             Console.ResetColor();
//             selectionDirectionIndex = Helper.DisplayMenuOption(selectionDirectionIndex, Text.Language.Directions);
//             PlayerAction.Instance.Execute(new List<int> { selectedActionIndex, selectionDirectionIndex });
//             break;
//     }
// }

