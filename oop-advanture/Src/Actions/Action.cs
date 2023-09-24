using System;

namespace oop_advanture.Src.Actions
{
    public abstract class Action
    {
        public virtual ActionType Name { get; protected set; }
        public virtual void Execute(List<int> arg){
            throw new NotImplementedException();
        }
    }
}
