using System.Threading;
using TourOfHeroes.Web.Pages.Heroes.Models;
using TourOfHeroes.Web.Pages.Heroes.State;
using Xunit;

namespace TourOfHeroes.Web.Tests.Pages.Heroes.State.RetrieveOne
{
    /// <summary>
    /// Unit tests for <see cref="HeroesState.HandleRetrieveOne"/>.
    /// </summary>
    public class HandleRetrieveOneTests : BaseHeroStateTestSetup
    {
        /// <summary>
        /// The <see cref="HeroesState.HandleRetrieveOne"/> to test with.
        /// </summary>
        private readonly HeroesState.HandleRetrieveOne _handleRetrieveOne;

        /// <summary>
        /// Initializes a new instance of the <see cref="HandleRetrieveOneTests"/> class.
        /// </summary>
        public HandleRetrieveOneTests()
        {
            _handleRetrieveOne = new HeroesState.HandleRetrieveOne(_mockStore.Object);
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
            var action = new HeroesState.RetrieveOneAction(payload);
            var expected = new Hero
            {
                Id = payload
            };
            _heroesState.Heroes.Add(expected);
            
            // Act.
            _handleRetrieveOne.Handle(action, new CancellationToken());

            // Assert.
            Assert.Equal(expected, _heroesState.Hero);
        }
    }
}
