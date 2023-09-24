using System;
using oop_advanture.Src.Actions;
using oop_advanture.Src.Map;

namespace oop_advanture.Src.Texts
{
    public abstract class Language
    {
        // Contain all the properties for all the text inside the game
        public string Welcome { get; protected set; } = "";
        public string ChooseYourName { get; protected set; } = "";
        public string ChooseYourNameAgain { get; protected set; } = "";
        public string DefaultRoomName { get; protected set; } = "";
        public string DefaultRoomDescriptions { get; protected set; } = "";
        public string SelectAnAction { get; set; } = "";
        public string GuildHelper { get; set; } = "";
        public string SelectDirection { get; set; } = "";
        public string GoError { get; set; } = "";
        public Dictionary<ActionType, string> Actions { get; set; } = new();
        public Dictionary<Direction, string> Directions { get; set; } = new();
    }
}
