using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using MediatR;
using MyBlazorApp.Client.Features.Base;

namespace TourOfHeroes.Components.Heroes.Feature.Delete
{
    public partial class HeroState
    {
        public class HandleDelete : BaseHandler<HeroState.DeleteAction>
        {
            public HandleDelete(IStore store) : base(store) { }

            public override Task<Unit> Handle(HeroState.DeleteAction aAction, CancellationToken aCancellationToken)
            {
                // TODO: Make service call.
                _heroState.Heroes.Remove(aAction.Hero);

                return Unit.Task;
            }
        }
    }
}