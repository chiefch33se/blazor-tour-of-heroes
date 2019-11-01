using System.Linq;
using System.Threading;
using TourOfHeroes.Web.Common.Models;
using TourOfHeroes.Web.Pages.Heroes.State;
using TourOfHeroes.Web.Tests.Helpers;
using Xunit;

namespace TourOfHeroes.Web.Tests.Pages.Heroes.State.Create
{
    /// <summary>
    /// Unit tests for <see cref="HeroesState.HandleCreate"/>.
    /// </summary>
    public class HandleCreateTests : BaseStoreTestSetup
    {
        /// <summary>
        /// The <see cref="HeroesState.HandleCreate"/> to test with.
        /// </summary>
        private readonly HeroesState.HandleCreate _handleCreate;

        /// <summary>
        /// Initializes a new instance of the <see cref="HandleCreateTests"/> class.
        /// </summary>
        public HandleCreateTests()
        {
            _handleCreate = new HeroesState.HandleCreate(_mockStore.Object);
        }

        /// <summary>
        /// Happy path.
        /// </summary>
        /// <param name="payload">The payload to test with.</param>
        [Theory]
        [InlineData("Tornado")]
        [InlineData("Magneta")]
        public void HandleCreate_ValidAction_UpdatesState(string payload)
        {
            // Arrange.
            var action = new HeroesState.CreateAction(payload);

            // Act.
            _handleCreate.Handle(action, new CancellationToken());

            // Assert.
            Assert.Equal(payload, _heroesState.Heroes.Single().Name);
        }

        /// <summary>
        /// The ID should increment by one every time an item is added.
        /// </summary>
        /// <param name="numberOfExistingHeroes">The number of existing Heroes in state after hydration.</param>
        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        public void HandleCreate_WithExistingItems_HasCorrectId(int numberOfExistingHeroes)
        {
            // Arrange.
            var payload = "Tornado";
            var action = new HeroesState.CreateAction(payload);
            for (int i = 0; i <= numberOfExistingHeroes; i++)
            {
                _heroesState.Heroes.Add(new Hero
                {
                    Id = i
                });
            }

            // Should be one higher than the number of Heroes already in the state.
            var expected = numberOfExistingHeroes + 1;

            // Act.
            _handleCreate.Handle(action, new CancellationToken());
            var tornado = _heroesState.Heroes.Single(hero => hero.Name == payload);

            // Assert.
            Assert.Equal(expected, tornado.Id);
        }
    }
}
