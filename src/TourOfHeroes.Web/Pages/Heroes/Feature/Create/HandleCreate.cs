using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using MediatR;
using TourOfHeroes.Web.Shared;
using TourOfHeroes.Web.Pages.Heroes.Models;

namespace TourOfHeroes.Web.Pages.Heroes.Feature
{
    public partial class HeroesState
    {
        public class HandleCreate : BaseHandler<HeroesState.CreateAction>
        {
            public HandleCreate(IStore store) : base(store) { }

            public override Task<Unit> Handle(HeroesState.CreateAction aAction, CancellationToken aCancellationToken)
            {
                // TODO: Make service call.
                var id = 1;

                if (_heroesState.Heroes.Any())
                {
                    id = _heroesState.Heroes.Max(hero => hero.Id + 1);
                }

                var heroToAppend = new Hero
                {
                    Id = id,
                    Name = aAction.Name
                };

                _heroesState.Heroes.Add(heroToAppend);

                return Unit.Task;
            }
        }
    }
}