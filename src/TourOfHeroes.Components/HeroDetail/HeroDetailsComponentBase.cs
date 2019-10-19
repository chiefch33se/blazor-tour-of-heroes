using BlazorState;
using Microsoft.AspNetCore.Components;
using TourOfHeroes.Components.HeroDetail.Feature;

namespace TourOfHeroes.Components.HeroDetail
{
    public class HeroDetailComponentBase : BlazorStateComponent
    {
        [Parameter]
        public int HeroId { get; set; }

        protected HeroDetailState _heroDetailState => GetState<HeroDetailState>();

        protected override void OnInitialized()
        {
            Mediator.Send(new Feature.Get.HeroDetailState.GetAction(HeroId));
        }
    }
}