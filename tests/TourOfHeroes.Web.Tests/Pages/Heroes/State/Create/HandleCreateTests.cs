using System.Linq;
using System.Threading;
using BlazorState;
using TourOfHeroes.Web.Pages.Heroes.Models;
using TourOfHeroes.Web.Pages.Heroes.State;
using Moq;
using Xunit;

namespace TourOfHeroes.Web.Tests.Pages.Heroes.State.Create
{
    /// <summary>
    /// Unit tests for <see cref="HeroesState.HandleCreate"/>.
    /// </summary>
    public class HandleCreateTests : HeroesState
    {
        /// <summary>
        /// The <see cref="HeroesState.HandleCreate"/> to test with.
        /// </summary>
        private readonly HeroesState.HandleCreate _handleCreate;

        /// <summary>
        /// The <see cref="HeroesState"/> to test with.
        /// </summary>
        private HeroesState _heroesState;

        /// <summary>
        /// Initializes a new instance of the <see cref="HandleCreateTests"/> class.
        /// </summary>
        public HandleCreateTests()
        {
            _heroesState = new HeroesState();
            _heroesState.Initialize();
            var mockStore = new Mock<IStore>();
            mockStore
                .Setup(store => store.GetState<HeroesState>())
                .Returns(_heroesState);
            _handleCreate= new HeroesState.HandleCreate(mockStore.Object);
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
        /// <param name="expected">The expected ID to be given to the new Hero added to the state.</param>
        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        public void HandleCreate_WithExistingItems_HasCorrectId(int expected)
        {
            // Arrange.
            var payload = "Tornado";
            var action = new HeroesState.CreateAction(payload);
            for (int i = 0; i < expected; i++)
            {
                _heroesState.Heroes.Add(new Hero
                {
                    Id = i
                });
            }

            // Act.
            _handleCreate.Handle(action, new CancellationToken());
            var tornado = _heroesState.Heroes.Single(hero => hero.Name == payload);

            // Assert.
            Assert.Equal(expected, tornado.Id);
        }
    }
}
