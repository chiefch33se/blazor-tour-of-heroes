using System.Linq;
using System.Threading;
using TourOfHeroes.Web.Pages.Heroes.Models;
using TourOfHeroes.Web.Pages.Heroes.State;
using Xunit;

namespace TourOfHeroes.Web.Tests.Pages.Heroes.State.Modify
{
    /// <summary>
    /// Unit tests for <see cref="HeroesState.HandleModify"/>.
    /// </summary>
    public class HandleModifyTests : BaseHeroStateTestSetup
    {
        /// <summary>
        /// The <see cref="HeroesState.HandleModify"/> to test with.
        /// </summary>
        private readonly HeroesState.HandleModify _handleModify;

        /// <summary>
        /// Initializes a new instance of the <see cref="HandleModifyTests"/> class.
        /// </summary>
        public HandleModifyTests()
        {
            _handleModify = new HeroesState.HandleModify(_mockStore.Object);
        }

        /// <summary>
        /// Happy path.
        /// </summary>
        /// <param name="id">The ID to test with.</param>
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void HandleModify_ValidAction_UpdatesState(int id)
        {
            // Arrange.
            _heroesState.Heroes.Add(new Hero
            {
                Id = id,
                Name = "Tornado"
            });
            var payload = new Hero
            {
                Id = id,
                Name = "Red Tornado"
            };
            var action = new HeroesState.ModifyAction(payload);

            // Act.
            _handleModify.Handle(action, new CancellationToken());

            // Assert.
            Assert.Equal(payload, _heroesState.Heroes.Single());
        }

        /// <summary>
        /// Handle modify should be able to deal with trying to modify a <see cref="Hero"/> that is not in the state.
        /// </summary>
        /// <returns>A <see cref="Task"/> instance.</returns>
        [Fact]
        public async Task HandleModify_NotFound_IsHandled()
        {
            // Arrange.
            var action = new HeroesState.ModifyAction(new Hero());

            // Act.
            var exception = await Record.ExceptionAsync(() => _handleModify.Handle(action, new CancellationToken()));

            // Assert.
            Assert.Null(exception);
        }
    }
}
