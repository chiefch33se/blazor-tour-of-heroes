using BlazorState;

namespace TourOfHeroes.Components.Heroes.Feature.Add
{
    public partial class HeroState 
    {
        public class AddAction: IAction
        {
            public string Name;

            public AddAction(string name)
            {
                Name = name;
            }
        }
    }
}