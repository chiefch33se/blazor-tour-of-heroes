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
        public class HandleLoad : BaseHandler<LoadAction>
        {
            public HandleLoad(IStore aStore) : base(aStore)
            {
            }

            public override Task<Unit> Handle(LoadAction aAction, CancellationToken aCancellationToken)
            {
                // TODO: Make service call.
                var heroes = new List<Hero>
                {
                    new Hero{ Id = 11, Name = "Dr Nice" },
                    new Hero{ Id = 12, Name = "Narco" },
                    new Hero{ Id = 13, Name = "Bombasto" },
                    new Hero{ Id = 14, Name = "Celeritas" },
                    new Hero{ Id = 15, Name = "Magneta" },
                    new Hero{ Id = 16, Name = "RubberMan" },
                    new Hero{ Id = 17, Name = "Dynama" },
                    new Hero{ Id = 18, Name = "Dr IQ" },
                    new Hero{ Id = 19, Name = "Magma" },
                    new Hero{ Id = 20, Name = "Tornado" },
                };

                _heroState.Heroes.AddRange(heroes);

                return Unit.Task;
            }
        }
    }
}