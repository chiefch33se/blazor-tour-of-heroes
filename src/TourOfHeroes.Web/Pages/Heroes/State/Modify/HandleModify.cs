using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using MediatR;
using TourOfHeroes.Web.Shared;

namespace TourOfHeroes.Web.Pages.Heroes.State
{
    public partial class HeroesState
    {
        public class HandleModify : BaseHandler<HeroesState.ModifyAction>
        {
            public HandleModify(IStore store) : base(store) { }

            public override Task<Unit> Handle(HeroesState.ModifyAction aAction, CancellationToken aCancellationToken)
            {
                // TODO: Make service call.
                var heroToModify = _heroesState.Heroes.SingleOrDefault(hero => hero.Id == aAction.Hero.Id);
                heroToModify.Name = aAction.Hero.Name;

                return Unit.Task;
            }
        }
    }
}