using BlazorState;
using TourOfHeroes.Data;

namespace TourOfHeroes.Web.Pages.Heroes.Containers.Duck
{
    public partial class HeroesState 
    {
        public class ModifyAction: IAction
        {
            public Hero Hero;

            public ModifyAction(Hero hero)
            {
                Hero = hero;
            }
        }
    }
}