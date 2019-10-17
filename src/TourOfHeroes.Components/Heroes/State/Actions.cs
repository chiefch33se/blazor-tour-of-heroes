using BlazorState;

namespace TourOfHeroes.Components.Heroes.State
{
        public class AddAction : IAction
        {
            public string Name;

            public AddAction(string name)
            {
                Name = name;
            }
        }

        public class LoadAction : IAction { }

}