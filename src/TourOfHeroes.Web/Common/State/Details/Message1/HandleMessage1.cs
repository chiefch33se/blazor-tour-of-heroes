using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using MediatR;

namespace TourOfHeroes.Web.Common.State.Details
{
    /// <inheritdoc/>
    public partial class DetailsState
    {
        /// <summary>
        /// Deals with the side effects of dispatching a <see cref="DetailsState.Message2Action"/> and updates the state accordingly.
        /// </summary>
        public class HandleMessage1 : BaseHandler<DetailsState.Message1Action>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="HandleModify"/> class.
            /// </summary>
            /// <param name="store">The single source of truth to create with.</param>
            public HandleMessage1(IStore store)
                : base(store)
            {
            }

            /// <summary>
            /// Handles the dispatched Action, and updates the state.
            /// </summary>
            /// <param name="aAction">The Action to handle.</param>
            /// <param name="aCancellationToken">Propagates notification that operations should be canceled.</param>
            /// <returns>A <see cref"Task{Unit}"/> instance.</returns>
            public override Task<Unit> Handle(DetailsState.Message1Action aAction, CancellationToken aCancellationToken)
            {
                Thread.Sleep(1000);
                DetailsState.Message1 = true;

                return Unit.Task;
            }
        }
    }
}
