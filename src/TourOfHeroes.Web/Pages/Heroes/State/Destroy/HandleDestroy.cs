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
        /// Deals with the side effects of dispatching a <see cref="HeroesState.DestroyAction"/> and updates the state accordingly.
        /// </summary>
        public class HandleDestroy : BaseHandler<HeroesState.DestroyAction>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="HandleDestroy"/> class.
            /// </summary>
            /// <param name="store">The application store to create with.</param>
            public HandleDestroy(IStore store) 
                : base(store) 
            {
            }
          
            /// <inheritdoc/>
            public override Task<Unit> Handle(HeroesState.DestroyAction aAction, CancellationToken aCancellationToken)
            {
                // TODO: Make service call.

                var itemToDelete = _heroesState.Heroes.FirstOrDefault(hero => hero.Id == aAction.Id);
                
                var result = _heroesState.Heroes.Remove(itemToDelete);
                
                return Unit.Task;
            }
        }
    }
}
