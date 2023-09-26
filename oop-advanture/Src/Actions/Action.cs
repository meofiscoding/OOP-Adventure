using System;

namespace oop_advanture.Src.Actions
{
    public abstract class Action
    {
        public virtual ActionType Name { get; protected set; }
        public virtual void Execute(int arg){
            throw new NotImplementedException();
        }
    }
}
