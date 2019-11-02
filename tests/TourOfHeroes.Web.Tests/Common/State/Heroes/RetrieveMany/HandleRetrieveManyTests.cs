using System.Collections.Generic;
using System.Threading;
using TourOfHeroes.Web.Common.Models;
using TourOfHeroes.Web.Common.State.Heroes;
using TourOfHeroes.Web.Tests.Helpers;
using Xunit;

namespace TourOfHeroes.Web.Tests.Common.State.Heroes.RetrieveMany
{
    /// <summary>
    /// Unit tests for <see cref="HeroesState.HandleRetrieveMany"/>.
    /// </summary>
    public class HandleRetrieveManyTests : BaseStoreTestSetup
    {
        /// <summary>
        /// The <see cref="HeroesState.HandleRetrieveMany"/> to test with.
        /// </summary>
        private readonly HeroesState.HandleRetrieveMany _handleModify;

        /// <summary>
        /// Initializes a new instance of the <see cref="HandleRetrieveManyTests"/> class.
        /// </summary>
        public HandleRetrieveManyTests()
        {
            _handleModify = new HeroesState.HandleRetrieveMany(_mockStore.Object);
        }

        /// <summary>
        /// Happy path.
        /// </summary>
        [Fact]
        public void HandleRetrieveMany_ValidAction_UpdatesState()
        {
            // Arrange.
            var action = new HeroesState.RetrieveManyAction();
            var expectedHeroes = new List<Hero>
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

            // Act.
            _handleModify.Handle(action, new CancellationToken());

            // Assert.
            Assert.Equal(expectedHeroes, _heroesState.Heroes);
        }
    }
}
