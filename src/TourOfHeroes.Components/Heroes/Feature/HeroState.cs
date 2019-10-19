using System.Collections.Generic;
using BlazorState;
using TourOfHeroes.Data;

namespace TourOfHeroes.Components.Heroes.Feature
{
    public partial class HeroState : State<HeroState>
    {
        public List<Hero> Heroes { get; private set; }

        public override void Initialize() => Heroes = new List<Hero>();
    }
}