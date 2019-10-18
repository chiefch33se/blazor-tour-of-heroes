using BlazorState;

namespace TourOfHeroes.Components.Heroes.State.Actions
{
    public partial class HeroState 
    {
        public class Add: IAction
        {
            public string Name;

            public Add(string name)
            {
                Name = name;
            }
        }
    }
}