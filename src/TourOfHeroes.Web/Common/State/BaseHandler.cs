using BlazorState;
using TourOfHeroes.Web.Common.State.Search;
using TourOfHeroes.Web.Common.State.Details;
using TourOfHeroes.Web.Common.State.Heroes;

namespace TourOfHeroes.Web.Common.State
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
        /// Gets the <see cref="DetailsState"/>.
        /// </summary>
        protected DetailsState DetailsState => Store.GetState<DetailsState>();

        /// <summary>
        /// Gets the <see cref="SearchState"/>.
        /// </summary>
        protected SearchState SearchState => Store.GetState<SearchState>();

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
