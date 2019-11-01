using TourOfHeroes.Web.Pages.Heroes.State;
using Xunit;

namespace TourOfHeroes.Web.Tests.Pages.Heroes.State.RetrieveOne
{
    /// <summary>
    /// Unit tests for <see cref="HeroesState.RetrieveOneAction"/>.
    /// </summary>
    public class RetrieveOneActionTests : HeroesState
    {
        /// <summary>
        /// Happy path.
        /// </summary>
        /// <param name="expectedPayload">The payload to test with.</param>
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void RetrieveOneAction_ValidPayload_SetsPayload(int expectedPayload)
        {
            // Given a well formed action.
            var actualPayload = new HeroesState.RetrieveOneAction(expectedPayload);

            // It should be instanciated with the given payload.
            Assert.Equal(expectedPayload, actualPayload.Id);
        }
    }
}
