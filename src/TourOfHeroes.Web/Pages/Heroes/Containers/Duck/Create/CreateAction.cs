using BlazorState;

namespace TourOfHeroes.Web.Pages.Heroes.Containers.Duck
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