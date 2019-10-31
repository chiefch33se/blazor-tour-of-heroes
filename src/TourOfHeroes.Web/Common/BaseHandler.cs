using BlazorState;
using TourOfHeroes.Web.Pages.Heroes.State;

namespace TourOfHeroes.Web.Common
{
    /// <summary>
    /// Base Handler that makes it easy to access state.
    /// </summary>
    public abstract class BaseHandler<TAction> : ActionHandler<TAction>
        where TAction : IAction
    {
        /// <summary>
        /// Gets the <see cref="HeroesState"/>.
        /// </summary>
        protected HeroesState HeroesState => Store.GetState<HeroesState>();

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseHandler"/> class.
        /// </summary>
        /// <param name="store">The single source of truth to create with.</param>
        public BaseHandler(IStore store)
            : base(store) 
        {
        }
    }
}
