using System.Collections.Generic;
using BlazorState;
using TourOfHeroes.Data;

namespace TourOfHeroes.Web.Pages.Heroes.Feature
{
    public partial class HeroesState : State<HeroesState>
    {
        public List<Hero> Heroes { get; private set; }

        public Hero Hero { get; private set; }

        public override void Initialize()
        {
            Heroes = new List<Hero>();
            Hero = new Hero();
        }
    }
}