using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using MediatR;
using MyBlazorApp.Client.Features.Base;

namespace TourOfHeroes.Components.Heroes.Feature.Delete
{
    public partial class HeroesState
    {
        public class HandleDelete : BaseHandler<HeroesState.DeleteAction>
        {
            public HandleDelete(IStore store) : base(store) { }

            public override Task<Unit> Handle(HeroesState.DeleteAction aAction, CancellationToken aCancellationToken)
            {
                // TODO: Make service call.
                _heroesState.Heroes.Remove(aAction.Hero);

                return Unit.Task;
            }
        }
    }
}