using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TourOfHeroes.Web.Common.Models;
using TourOfHeroes.Web.Common.State.Details;
using TourOfHeroes.Web.Tests.Helpers;
using Xunit;

namespace TourOfHeroes.Web.Tests.Common.State.Details.Modify
{
    /// <summary>
    /// Unit tests for <see cref="DetailsState.HandleModify"/>.
    /// </summary>
    public class HandleModifyTests : BaseStoreTestSetup
    {
        /// <summary>
        /// The <see cref="DetailsState.HandleModify"/> to test with.
        /// </summary>
        private readonly DetailsState.HandleModify _handleModify;

        /// <summary>
        /// Initializes a new instance of the <see cref="HandleModifyTests"/> class.
        /// </summary>
        public HandleModifyTests()
        {
            _handleModify = new DetailsState.HandleModify(_mockStore.Object);
        }

        /// <summary>
        /// Happy path.
        /// </summary>
        /// <param name="id">The ID to test with.</param>
        /// <param name="name">The Name to test with.</param>
        [Theory]
        [InlineData(1, "Red Tornado")]
        [InlineData(2, "Blue Tornado")]
        public void HandleModify_ValidAction_UpdatesState(int id, string name)
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
                Name = name
            };
            var action = new DetailsState.ModifyAction(payload);

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
            var action = new DetailsState.ModifyAction(new Hero());

            // Act.
            var exception = await Record.ExceptionAsync(() => _handleModify.Handle(action, new CancellationToken()));

            // Assert.
            Assert.Null(exception);
        }
    }
}
