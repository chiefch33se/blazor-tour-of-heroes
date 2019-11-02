using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using MediatR;

namespace TourOfHeroes.Web.Common.Containers.Search.State
{
    /// <inheritdoc/>
    public partial class SearchState
    {
        /// <summary>
        /// Deals with the side effects of dispatching a <see cref="SearchState.QueryAction"/> and updates the state accordingly.
        /// </summary>
        public class HandleQuery : BaseHandler<SearchState.QueryAction>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="HandleQuery"/> class.
            /// </summary>
            /// <param name="store">The single source of truth to create with.</param>
            public HandleQuery(IStore store)
                : base(store)
            {
            }

            /// <summary>
            /// Handles the dispatched Action, and updates the state.
            /// </summary>
            /// <param name="aAction">The Action to handle.</param>
            /// <param name="aCancellationToken">Propagates notification that operations should be canceled.</param>
            /// <returns>A <see cref"Task{Unit}"/> instance.</returns>
            public override Task<Unit> Handle(QueryAction aAction, CancellationToken aCancellationToken)
            {
                // TODO: This would normally be a backend call via a service.

                var results = HeroesState.Heroes.Where(hero => hero.Name.Contains(aAction.Query));

                SearchState.Results.AddRange(results);

                return Unit.Task;
            }
        }
    }
}