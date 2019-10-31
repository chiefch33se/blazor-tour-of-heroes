using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using MediatR;
using TourOfHeroes.Web.Shared;

namespace TourOfHeroes.Web.Pages.Heroes.State
{
    /// <inheritdoc/>
    public partial class HeroesState
    {
        /// <summary>
        /// Deals with the side effects of dispatching a <see cref="HeroesState.ModifyAction"/> and updates the state accordingly.
        /// </summary>
        public class HandleModify : BaseHandler<HeroesState.ModifyAction>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="HandleModify"/> class.
            /// </summary>
            /// <param name="store">The application store to create with.</param>
            public HandleModify(IStore store) 
                : base(store)
            {
            }

            /// <inheritdoc/>
            public override Task<Unit> Handle(HeroesState.ModifyAction aAction, CancellationToken aCancellationToken)
            {
                // TODO: Make service call.
                var heroToModify = _heroesState.Heroes.SingleOrDefault(hero => hero.Id == aAction.Hero.Id);
                heroToModify.Name = aAction.Hero.Name;

                return Unit.Task;
            }
        }
    }
}
