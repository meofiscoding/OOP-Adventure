using System;

namespace oop_advanture.Src.Character
{
    public abstract class Character
    {
        public string Name { get; set; }

        protected Character(string name)
        {
            Name = name;
        }
    }
}
