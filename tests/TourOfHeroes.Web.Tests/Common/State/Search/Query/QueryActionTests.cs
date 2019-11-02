using TourOfHeroes.Web.Common.State.Search;
using Xunit;

namespace TourOfHeroes.Web.Tests.Common.State.Search.Query
{
    /// <summary>
    /// Unit tests for <see cref="SearchState.QueryAction"/>.
    /// </summary>
    public class QueryActionTests
    {
        /// <summary>
        /// Happy path.
        /// </summary>
        /// <param name="expectedPayload">The payload to test with.</param>
        [Theory]
        [InlineData("Tornado")]
        [InlineData("Magneta")]
        public void DestroyAction_ValidPayload_SetsPayload(string expectedPayload)
        {
            // Given a well formed action.
            var actualPayload = new SearchState.QueryAction(expectedPayload);

            // It should be instanciated with the given payload.
            Assert.Equal(expectedPayload, actualPayload.Query);
        }
    }
}