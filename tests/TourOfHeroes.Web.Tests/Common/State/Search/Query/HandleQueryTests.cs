using System.Threading;
using TourOfHeroes.Web.Common.Models;
using TourOfHeroes.Web.Common.State.Search;
using TourOfHeroes.Web.Tests.Helpers;
using Xunit;

namespace TourOfHeroes.Web.Tests.Common.State.Search.Query
{
    /// <summary>
    /// Unit tests for <see cref="SearchState.HandleQuery"/>.
    /// </summary>
    public class HandleQueryTests : BaseStoreTestSetup
    {
        /// <summary>
        /// The <see cref="SearchState.HandleQuery"/> to test with.
        /// </summary>
        private readonly SearchState.HandleQuery _handleQuery;

        /// <summary>
        /// Initializes a new instance of the <see cref="HandleCreateTests"/> class.
        /// </summary>
        public HandleQueryTests()
        {
            _handleQuery = new SearchState.HandleQuery(_mockStore.Object);
        }

        /// <summary>
        /// Happy path.
        /// </summary>
        /// <param name="query">The query to test with (case shouldn't matter).</param>
        [Theory]
        [InlineData("Tornado")]
        [InlineData("tornado")]
        [InlineData("TORNADO")]
        public void Handle_GivenMatchingSearchTerm_ReturnsCorrectHero(string query)
        {
            // Arrange.
            var hero = new Hero
            {
                Id = 1,
                Name = "Tornado"
            };
            _heroesState.Heroes.Add(hero);
            var action = new SearchState.QueryAction(query);

            // Act.
            _handleQuery.Handle(action, new CancellationToken());

            // Assert.
            Assert.Contains(hero, _searchState.Results);
            Assert.False(_searchState.NoResults);            
        }

        /// <summary>
        /// Strings that don't match shouldn't return a result.
        /// </summary>
        [Fact]
        public void Handle_GivenNonMatchingSearchTerm_ReturnsNothing()
        {
            // Arrange.
            var hero = new Hero
            {
                Id = 1,
                Name = "Tornado"
            };
            _heroesState.Heroes.Add(hero);
            var action = new SearchState.QueryAction("some non-matching query");

            // Act.
            _handleQuery.Handle(action, new CancellationToken());

            // Assert.
            Assert.Empty(_searchState.Results);
            Assert.True(_searchState.NoResults);
        }
    }
}