using BlazorState;
using TourOfHeroes.Data;

namespace TourOfHeroes.Components.Heroes.Feature.Delete
{
    public partial class HeroesState 
    {
        public class DeleteAction: IAction
        {
            public Hero Hero;

            public DeleteAction(Hero hero)
            {
                Hero = hero;
            }
        }
    }
}