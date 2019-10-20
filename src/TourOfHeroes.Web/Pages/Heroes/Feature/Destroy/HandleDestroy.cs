using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using MediatR;
using TourOfHeroes.Web.Shared;

namespace TourOfHeroes.Web.Pages.Heroes.Feature
{
    public partial class HeroesState
    {
        public class HandleDestroy : BaseHandler<HeroesState.DestroyAction>
        {
            public HandleDestroy(IStore store) : base(store) { }

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