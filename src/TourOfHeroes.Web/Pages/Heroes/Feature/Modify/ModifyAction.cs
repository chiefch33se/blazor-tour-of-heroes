using BlazorState;
using TourOfHeroes.Data;

namespace TourOfHeroes.Web.Pages.Heroes.Feature
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