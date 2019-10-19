using BlazorState;
using TourOfHeroes.Data;

namespace TourOfHeroes.Components.HeroDetail.Feature
{
    public partial class HeroDetailState : State<HeroDetailState>
    {
        public Hero Hero { get; set; }

        public override void Initialize() => Hero = new Hero();
    }
}