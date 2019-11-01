using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using MediatR;
using TourOfHeroes.Web.Common;

namespace TourOfHeroes.Web.Pages.Heroes.State
{
    /// <inheritdoc/>
    public partial class HeroesState
    {
        /// <summary>
        /// Deals with the side effects of dispatching a <see cref="HeroesState.ModifyAction"/> and updates the state accordingly.
        /// </summary>
        protected internal class HandleModify : BaseHandler<HeroesState.ModifyAction>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="HandleModify"/> class.
            /// </summary>
            /// <param name="store">The single source of truth to create with.</param>
            public HandleModify(IStore store) 
                : base(store)
            {
            }

            /// <summary>
            /// Handles the dispatched Action, and updates the state.
            /// </summary>
            /// <param name="aAction">The Action to handle.</param>
            /// <param name="aCancellationToken">Propagates notification that operations should be canceled.</param>
            /// <returns>A <see cref"Task{Unit}"/> instance.</returns>
            public override Task<Unit> Handle(HeroesState.ModifyAction aAction, CancellationToken aCancellationToken)
            {
                // TODO: Make service call.
                var heroToModify = HeroesState.Heroes.SingleOrDefault(hero => hero.Id == aAction.Hero.Id);
                heroToModify.Name = aAction.Hero.Name;

                return Unit.Task;
            }
        }
    }
}
