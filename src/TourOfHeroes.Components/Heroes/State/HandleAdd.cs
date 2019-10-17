using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using MediatR;
using MyBlazorApp.Client.Features.Base;
using TourOfHeroes.Data;

namespace TourOfHeroes.Components.Heroes.State
{
    public partial class HeroState
    {
        public class HandleAdd : BaseHandler<AddAction>
        {
            public HandleAdd(IStore aStore) : base(aStore)
            {
            }

            public override Task<Unit> Handle(AddAction aAction, CancellationToken aCancellationToken)
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