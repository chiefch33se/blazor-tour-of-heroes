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
        public class HandleAdd : BaseHandler<Actions.HeroState.Add>
        {
            public HandleAdd(IStore store) : base(store) { }

            public override Task<Unit> Handle(Actions.HeroState.Add aAction, CancellationToken aCancellationToken)
            {
                // TODO: Make service call.
                var heroToAppend = new Hero
                {
                    Id = 1,
                    Name = aAction.Name
                };

                _heroState.Heroes.Add(heroToAppend);

                return Unit.Task;
            }
        }
    }
}