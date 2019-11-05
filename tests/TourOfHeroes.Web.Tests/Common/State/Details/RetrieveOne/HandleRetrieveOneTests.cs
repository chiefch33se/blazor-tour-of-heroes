using System.Collections.Generic;
using System.Threading;
using TourOfHeroes.Web.Common.Models;
using TourOfHeroes.Web.Common.State.Details;
using TourOfHeroes.Web.Tests.Helpers;
using Xunit;

namespace TourOfHeroes.Web.Tests.Common.State.Details.RetrieveOne
{
    /// <summary>
    /// Unit tests for <see cref="HeroesState.HandleRetrieveOne"/>.
    /// </summary>
    public class HandleRetrieveOneTests : BaseStoreTestSetup
    {
        /// <summary>
        /// The <see cref="HeroesState.HandleRetrieveOne"/> to test with.
        /// </summary>
        private readonly DetailsState.HandleRetrieveOne _handleRetrieveOne;

        /// <summary>
        /// Initializes a new instance of the <see cref="HandleRetrieveOneTests"/> class.
        /// </summary>
        public HandleRetrieveOneTests()
        {
            _handleRetrieveOne = new DetailsState.HandleRetrieveOne(_mockStore.Object);
        }

        /// <summary>
        /// Happy path.
        /// </summary>
        /// <param name="payload">The payload to test with.</param>
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void HandleRetrieveOne_ValidAction_UpdatesState(int payload)
        {
            // Arrange.
            var action = new DetailsState.RetrieveOneAction(payload);
            var expected = new Hero
            {
                Id = payload
            };

            var heroes = new List<Hero> { expected };
            var keyValuePairs = new Dictionary<string, object>
            {
                { "Heroes", heroes }
            };
            
            _heroesState.Hydrate(keyValuePairs);

            // Act.
            _handleRetrieveOne.Handle(action, new CancellationToken());

            // Assert.
            Assert.Equal(expected, _detailsState.Hero);
        }
    }
}
