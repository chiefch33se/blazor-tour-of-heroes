using BlazorState;
using TourOfHeroes.Components.Heroes.State;

namespace MyBlazorApp.Client.Features.Base
{
    /// <summary>
    /// Base Handler that makes it easy to access state.
    /// </summary>
    public abstract class BaseHandler<TAction> : ActionHandler<TAction>
        where TAction : IAction
    {
        protected HeroState _heroState => Store.GetState<HeroState>();

        public BaseHandler(IStore store) : base(store) { }
    }
}
