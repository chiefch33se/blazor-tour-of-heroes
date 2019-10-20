using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BlazorState;
using MediatR;
using TourOfHeroes.Data;
using TourOfHeroes.Web.Shared;

namespace TourOfHeroes.Web.Pages.Heroes.Container.Duck
{
    public partial class HeroesState
    {
        public class HandleRetrieveMany : BaseHandler<HeroesState.RetrieveManyAction>
        {
            public HandleRetrieveMany(IStore store) : base(store) { }

            public override Task<Unit> Handle(HeroesState.RetrieveManyAction aAction, CancellationToken aCancellationToken)
            {
                // TODO: Make service call.
                var heroes = new List<Hero>
                {
                    new Hero{ Id = 111, Name = "Dr Nice" },
                    new Hero{ Id = 122, Name = "Narco" },
                    new Hero{ Id = 133, Name = "Bombasto" },
                    new Hero{ Id = 144, Name = "Celeritas" },
                    new Hero{ Id = 155, Name = "Magneta" },
                    new Hero{ Id = 166, Name = "RubberMan" },
                    new Hero{ Id = 177, Name = "Dynama" },
                    new Hero{ Id = 188, Name = "Dr IQ" },
                    new Hero{ Id = 199, Name = "Magma" },
                    new Hero{ Id = 200, Name = "Tornado" },
                };

                _heroesState.Heroes.AddRange(heroes);

                return Unit.Task;
            }
        }
    }
}