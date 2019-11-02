using System.Collections.Generic;
using System.Threading;
using TourOfHeroes.Web.Common.State.Search;
using TourOfHeroes.Web.Common.Models;
using TourOfHeroes.Web.Tests.Helpers;
using Xunit;

namespace TourOfHeroes.Web.Tests.Common.Containers.Search.State.Query
{
    /// <summary>
    /// Unit tests for <see cref="HandleQuery"/>.
    /// </summary>
    public class HandleQueryTests : BaseStoreTestSetup
    {
        /// <summary>
        /// The <see cref="SearchState.QueryAction"/> to test with.
        /// </summary>
        private readonly SearchState.HandleQuery _handleQuery;

        /// <summary>
        /// Initializes a new instance of the <see cref="HandleDestroyTests"/> class.
        /// </summary>
        public HandleQueryTests()
        {
            _handleQuery = new SearchState.HandleQuery(_mockStore.Object);
        }

        [Fact]
        public void Example()
        {
            _heroesState.Heroes.AddRange(new List<Hero>
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
            });

            var action = new SearchState.QueryAction("Dr");

            _handleQuery.Handle(action, new CancellationToken());
        }
    }
}