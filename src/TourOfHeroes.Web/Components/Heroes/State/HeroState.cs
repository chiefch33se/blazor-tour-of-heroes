using System.Collections.Generic;
using BlazorState;
using TourOfHeroes.Data;

namespace TourOfHeroes.Web.Components.Heroes.State
{
    public partial class HeroState : State<HeroState>
    {
        public List<Hero> Heroes { get; private set; }

        protected override void Initialize() => Heroes = new List<Hero>();
    }
}