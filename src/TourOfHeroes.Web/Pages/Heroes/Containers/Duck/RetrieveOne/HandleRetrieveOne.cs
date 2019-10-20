using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using MediatR;
using TourOfHeroes.Data;
using TourOfHeroes.Web.Shared;

namespace TourOfHeroes.Web.Pages.Heroes.Containers.Duck
{
    public partial class HeroesState
    {
        public class HandleRetrieveOne : BaseHandler<HeroesState.RetrieveOneAction>
        {
            public HandleRetrieveOne(IStore store) : base(store) { }

            public override Task<Unit> Handle(HeroesState.RetrieveOneAction aAction, CancellationToken aCancellationToken)
            {
                // TODO: Make service call.
                _heroesState.Hero = _heroesState.Heroes.FirstOrDefault(hero => hero.Id == aAction.Id);

                return Unit.Task;
            }
        }
    }
}