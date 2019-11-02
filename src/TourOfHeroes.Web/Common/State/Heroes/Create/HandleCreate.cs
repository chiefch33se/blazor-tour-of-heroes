using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using MediatR;
using TourOfHeroes.Web.Common.Models;

namespace TourOfHeroes.Web.Common.State.Heroes
{
    /// <inheritdoc/>
    public partial class HeroesState
    {
        /// <summary>
        /// Deals with the side effects of dispatching a <see cref="HeroesState.CreateAction"/> and updates the state accordingly.
        /// </summary>
        public class HandleCreate : BaseHandler<HeroesState.CreateAction>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="HandleCreate"/> class.
            /// </summary>
            /// <param name="store">The single source of truth to create with.</param>
            public HandleCreate(IStore store)
                : base(store)
            {
            }

            /// <summary>
            /// Handles the dispatched Action, and updates the state.
            /// </summary>
            /// <param name="aAction">The Action to handle.</param>
            /// <param name="aCancellationToken">Propagates notification that operations should be canceled.</param>
            /// <returns>A <see cref"Task{Unit}"/> instance.</returns>
            public override Task<Unit> Handle(HeroesState.CreateAction aAction, CancellationToken aCancellationToken)
            {
                // TODO: Make service call.
                var id = 1;

                if (HeroesState.Heroes.Any())
                {
                    id = HeroesState.Heroes.Max(hero => hero.Id + 1);
                }

                var heroToAppend = new Hero
                {
                    Id = id,
                    Name = aAction?.Name
                };

                HeroesState.Heroes.Add(heroToAppend);

                return Unit.Task;
            }
        }
    }
}
