using System.Collections.Generic;
using BlazorState;
using TourOfHeroes.Data;

namespace TourOfHeroes.Web.Pages.Heroes.Container.Duck
{
    public partial class HeroesState : State<HeroesState>
    {
        public List<Hero> Heroes { get; set; }

        public Hero Hero { get; set; }

        public override void Initialize()
        {
            Heroes = new List<Hero>();
            Hero = new Hero();
        }
    }
}