using System;
using oop_advanture.Src.Actions;
using oop_advanture.Src.Map;

namespace oop_advanture.Src.Texts
{
    public abstract partial class Language
    {
        // Contain all the properties for all the text inside the game
        public string Welcome { get; protected set; } = "";
        public string ChooseYourName { get; protected set; } = "";
        public string ChooseYourNameAgain { get; protected set; } = "";
        public string DefaultRoomName { get; protected set; } = "";
        public string DefaultRoomDescriptions { get; protected set; } = "";
        public string SelectAnAction { get; protected set; } = "";
        public string GuildHelper { get; protected set; } = "";
        public string SelectDirection { get; protected set; } = "";
        public string GoError { get; protected set; } = "";
        public string ActionNotFound { get; protected set; } = "";
        public string RoomOld { get; protected set; } = "";
        public string RoomNew { get; protected set; } = "";
        public string And { get; protected set; } = "";
        public string Comma { get; protected set; } = "";
        public string Space { get; protected set; } = "";
        public string ItemNotFound { get; set; } = "";
        public string BackpackEmpty { get; set; } = "";
        public string BackpackList { get; set; } = "";
        public Dictionary<ActionType, string> Actions { get; protected set; } = new();
        public Dictionary<Direction, string> Directions { get; protected set; } = new();
        public List<string> RoomDescriptions { get; protected set; } = new();
    }
}
