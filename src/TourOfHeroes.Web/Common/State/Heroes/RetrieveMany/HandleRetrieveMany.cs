using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using MediatR;
using TourOfHeroes.Web.Common.Models;
using TourOfHeroes.Web.Common;

namespace TourOfHeroes.Web.Common.State.Heroes
{
    /// <inheritdoc/>
    public partial class HeroesState
    {
        /// <summary>
        /// Deals with the side effects of dispatching a <see cref="HeroesState.RetrieveManyAction"/> and updates the state accordingly.
        /// </summary>
        public class HandleRetrieveMany : BaseHandler<HeroesState.RetrieveManyAction>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="HandleRetrieveMany"/> class.
            /// </summary>
            /// <param name="store">The single source of truth to create with.</param>
            public HandleRetrieveMany(IStore store)
                : base(store)
            {
            }

            /// <summary>
            /// Handles the dispatched Action, and updates the state.
            /// </summary>
            /// <param name="aAction">The Action to handle.</param>
            /// <param name="aCancellationToken">Propagates notification that operations should be canceled.</param>
            /// <returns>A <see cref"Task{Unit}"/> instance.</returns>
            public override Task<Unit> Handle(HeroesState.RetrieveManyAction aAction, CancellationToken aCancellationToken)
            {
                // TODO: Make service call.
                var heroes = new List<Hero>
                {
                    new Hero{ Id = 11, Name = "Dr Nice" },
                    new Hero{ Id = 12, Name = "Narco" },
                    new Hero{ Id = 13, Name = "Bombasto" },
                    new Hero{ Id = 14, Name = "Celeritas" },
                    new Hero{ Id = 15, Name = "Magneta" },
                    new Hero{ Id = 16, Name = "RubberMan" },
                    new Hero{ Id = 17, Name = "Dynama" },
                    new Hero{ Id = 18, Name = "Dr IQ" },
                    new Hero{ Id = 19, Name = "Magma" },
                    new Hero{ Id = 20, Name = "Tornado" },
                };

                HeroesState.Heroes.AddRange(heroes);

                return Unit.Task;
            }
        }
    }
}
