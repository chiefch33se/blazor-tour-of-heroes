using System.Collections.Generic;
using System.Threading;
using TourOfHeroes.Web.Common.Models;
using TourOfHeroes.Web.Common.State.Heroes;
using TourOfHeroes.Web.Tests.Helpers;
using Xunit;

namespace TourOfHeroes.Web.Tests.Common.State.Heroes.Destroy
{
    /// <summary>
    /// Unit tests for <see cref="HeroesState.HandleDestroy"/>.
    /// </summary>
    public class HandleDestroyTests : BaseStoreTestSetup
    {
        /// <summary>
        /// The <see cref="HeroesState.HandleDestroy"/> to test with.
        /// </summary>
        private readonly HeroesState.HandleDestroy _handleDestroy;

        /// <summary>
        /// Initializes a new instance of the <see cref="HandleDestroyTests"/> class.
        /// </summary>
        public HandleDestroyTests()
        {
            _handleDestroy = new HeroesState.HandleDestroy(_mockStore.Object);
        }

        /// <summary>
        /// Happy path.
        /// </summary>
        /// <param name="payload">The payload to test with.</param>
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void HandleDestroy_ValidAction_UpdatesState(int payload)
        {
            // Arrange.
            var action = new HeroesState.DestroyAction(payload);
            var hero = new Hero
            {
                Id = payload
            };
            var heroes = new List<Hero> { hero };
            var keyValuePairs = new Dictionary<string, object>
            {
                { "Heroes", heroes }
            };
            _heroesState.Hydrate(keyValuePairs);

            // Act.
            _handleDestroy.Handle(action, new CancellationToken());

            // Assert.
            Assert.Empty(_heroesState.Heroes);
        }
    }
}
