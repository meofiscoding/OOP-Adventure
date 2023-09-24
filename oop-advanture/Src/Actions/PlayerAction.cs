using System;

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

        private readonly Dictionary<string, Action> _registeredActions = new();

        private PlayerAction()
        {
        }

        public void RegisterAction(Action action)
        {
            var name = action.Name.ToLower();
            _registeredActions[name] = action;
        }

        
    }
}
