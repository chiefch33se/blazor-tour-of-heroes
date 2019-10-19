using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using MediatR;
using MyBlazorApp.Client.Features.Base;
using TourOfHeroes.Data;

namespace TourOfHeroes.Components.Heroes.Feature.Add
{
    public partial class HeroState
    {
        public class HandleAdd : BaseHandler<HeroState.AddAction>
        {
            public HandleAdd(IStore store) : base(store) { }

            public override Task<Unit> Handle(HeroState.AddAction aAction, CancellationToken aCancellationToken)
            {
                // TODO: Make service call.
                var id = 1;

                if (_heroState.Heroes.Any())
                {
                    id = _heroState.Heroes.Max(hero => hero.Id + 1);
                }

                var heroToAppend = new Hero
                {
                    Id = id,
                    Name = aAction.Name
                };

                _heroState.Heroes.Add(heroToAppend);

                return Unit.Task;
            }
        }
    }
}