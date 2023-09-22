using System;

namespace oop_advanture.Src.Text
{
    public abstract class Language
    {
        // Contain all the properties for all the text inside the game
        public string Welcome { get; protected set; } = "";
        public string ChooseYourName { get; protected set; } = "";

        public string ChooseYourNameAgain { get; set; } = "";
    }
}
