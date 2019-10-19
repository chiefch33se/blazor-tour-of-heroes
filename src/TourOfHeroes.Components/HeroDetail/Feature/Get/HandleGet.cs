using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using BlazorState;
using MediatR;
using MyBlazorApp.Client.Features.Base;
using TourOfHeroes.Data;

namespace TourOfHeroes.Components.HeroDetail.Feature.Get
{
    public partial class HeroDetailState
    {
        public class HandleGet : BaseHandler<HeroDetailState.GetAction>
        {
            public HandleGet(IStore store) : base(store) { }

            public override Task<Unit> Handle(HeroDetailState.GetAction aAction, CancellationToken aCancellationToken)
            {
                _heroDetailState.Hero = _heroesState.Heroes.FirstOrDefault(hero => hero.Id == aAction._id);

                return Unit.Task;
            }
        }
    }
}