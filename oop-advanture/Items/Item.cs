using System;

namespace oop_advanture.Items
{
    public abstract class Item
    {
        // name can be overriden
        public virtual string Name { get; set; }

        // Determine if item had been used or not
        public bool SingleUse { get; set; }
        public bool CanTake { get; set; }

        // Method can be override to determine logic what to do with that item
        public virtual void Use(string source)
        {
            throw new NotImplementedException();
        }
    }
}
