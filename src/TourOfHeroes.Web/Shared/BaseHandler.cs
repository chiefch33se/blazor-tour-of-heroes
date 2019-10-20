using BlazorState;
using TourOfHeroes.Web.Pages.Heroes.Duck;

namespace TourOfHeroes.Web.Shared
{
    /// <summary>
    /// Base Handler that makes it easy to access state.
    /// </summary>
    public abstract class BaseHandler<TAction> : ActionHandler<TAction>
        where TAction : IAction
    {
        protected HeroesState _heroesState => Store.GetState<HeroesState>();

        public BaseHandler(IStore store) : base(store) { }
    }
}
