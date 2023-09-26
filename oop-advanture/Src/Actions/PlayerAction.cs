using System;
using oop_advanture.Src.Texts;

namespace oop_advanture.Src.Actions
{
    public sealed class PlayerAction
    {
        private static PlayerAction _instance;

        public static PlayerAction Instance
        {
            get
            {
                return _instance ??= new PlayerAction();
            }
        }

        private readonly Dictionary<ActionType, Action> _registeredActions = new();

        private PlayerAction()
        {
        }

        public void RegisterAction(Action action)
        {
            _registeredActions[action.Name] = action;
        }

        public void Execute(List<int> args){
            var action = (ActionType)args[0];
            if(_registeredActions.TryGetValue(action, out var value))
            {
                value.Execute(args[1]);
            }else{
                Console.WriteLine(Text.Language.ActionNotFound);
            }
        }
    }
}
