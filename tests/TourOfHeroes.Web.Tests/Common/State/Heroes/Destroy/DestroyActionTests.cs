using TourOfHeroes.Web.Common.State.Heroes;
using Xunit;

namespace TourOfHeroes.Web.Tests.Common.State.Heroes.Destroy
{
    /// <summary>
    /// Unit tests for <see cref="HeroesState.DestroyAction"/>.
    /// </summary>
    public class DestroyActionTests : HeroesState
    {
        /// <summary>
        /// Happy path.
        /// </summary>
        /// <param name="expectedPayload">The payload to test with.</param>
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void DestroyAction_ValidPayload_SetsPayload(int expectedPayload)
        {
            // Given a well formed action.
            var actualPayload = new HeroesState.DestroyAction(expectedPayload);

            // It should be instanciated with the given payload.
            Assert.Equal(expectedPayload, actualPayload.Id);
        }
    }
}
