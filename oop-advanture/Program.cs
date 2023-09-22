using oop_advanture.Src.Character;
using oop_advanture.Src.Text;

Text.SetLanguage(new English());
Console.WriteLine(Text.Language.ChooseYourName);

var name = Console.ReadLine();

while(String.IsNullOrEmpty(name)){
    Console.WriteLine(Text.Language.ChooseYourNameAgain);
    name = Console.ReadLine();
}

Player player = new(name);
Console.WriteLine(Text.Language.Welcome, player.Name);

