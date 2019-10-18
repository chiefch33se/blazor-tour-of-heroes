using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using MediatR;
using MyBlazorApp.Client.Features.Base;
using TourOfHeroes.Data;

namespace TourOfHeroes.Components.Heroes.State.Handlers
{
    public partial class HeroState
    {
        public class HandleDelete : BaseHandler<Actions.HeroState.Delete>
        {
            public HandleDelete(IStore store) : base(store) { }

            public override Task<Unit> Handle(Actions.HeroState.Delete aAction, CancellationToken aCancellationToken)
            {
                // TODO: Make service call.
                _heroState.Heroes.Remove(aAction.Hero);

                return Unit.Task;
            }
        }
    }
}