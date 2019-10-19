using System.Collections.Generic;
using BlazorState;
using TourOfHeroes.Data;

namespace TourOfHeroes.Components.Heroes.Feature
{
    public partial class HeroesState : State<HeroesState>
    {
        public List<Hero> Heroes { get; set; }

        public override void Initialize() => Heroes = new List<Hero>();
    }
}