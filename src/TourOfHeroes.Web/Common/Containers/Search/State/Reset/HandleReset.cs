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
        /// Deals with the side effects of dispatching a <see cref="SearchState.ResetAction"/> and updates the state accordingly.
        /// </summary>
        public class HandleReset : BaseHandler<SearchState.ResetAction>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="HandleReset"/> class.
            /// </summary>
            /// <param name="store">The single source of truth to create with.</param>
            public HandleReset(IStore store)
                : base(store)
            {
            }

            /// <summary>
            /// Handles the dispatched Action, and updates the state.
            /// </summary>
            /// <param name="aAction">The Action to handle.</param>
            /// <param name="aCancellationToken">Propagates notification that operations should be canceled.</param>
            /// <returns>A <see cref"Task{Unit}"/> instance.</returns>
            public override Task<Unit> Handle(ResetAction aAction, CancellationToken aCancellationToken)
            {
                SearchState.Initialize();

                return Unit.Task;
            }
        }
    }
}
