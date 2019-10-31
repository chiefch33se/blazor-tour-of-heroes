using BlazorState;

namespace TourOfHeroes.Web.Pages.Heroes.State
{
    public partial class HeroesState 
    {
        public class CreateAction: IAction
        {
            public string Name;

            public CreateAction(string name)
            {
                Name = name;
            }
        }
    }
}