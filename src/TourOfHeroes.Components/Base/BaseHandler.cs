using BlazorState;
using TourOfHeroes.Components.Heroes.Feature;
using TourOfHeroes.Components.HeroDetail.Feature;

namespace MyBlazorApp.Client.Features.Base
{
    /// <summary>
    /// Base Handler that makes it easy to access state.
    /// </summary>
    public abstract class BaseHandler<TAction> : ActionHandler<TAction>
        where TAction : IAction
    {
        protected HeroesState _heroesState => Store.GetState<HeroesState>();

        protected HeroDetailState _heroDetailState => Store.GetState<HeroDetailState>();

        public BaseHandler(IStore store) : base(store) { }
    }
}
