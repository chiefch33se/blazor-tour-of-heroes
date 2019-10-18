using BlazorState;
using TourOfHeroes.Data;

namespace TourOfHeroes.Components.Heroes.State.Actions
{
    public partial class HeroState 
    {
        public class Delete: IAction
        {
            public Hero Hero;

            public Delete(Hero hero)
            {
                Hero = hero;
            }
        }
    }
}