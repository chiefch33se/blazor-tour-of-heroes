using System.Threading;
using Moq;
using TourOfHeroes.Web.Common.State.Search;
using TourOfHeroes.Web.Tests.Helpers;
using Xunit;

namespace TourOfHeroes.Web.Tests.Common.State.Search.Reset
{
    /// <summary>
    /// Unit tests for <see cref="SearchState.HandleReset"/>.
    /// </summary>
    public class HandleResetTests : BaseStoreTestSetup
    {
        /// <summary>
        /// The <see cref="SearchState.HandleReset"/> to test with.
        /// </summary>
        private readonly SearchState.HandleReset _handleQuery;

        /// <summary>
        /// Initializes a new instance of the <see cref="HandleResetTests"/> class.
        /// </summary>
        public HandleResetTests()
        {
            _handleQuery = new SearchState.HandleReset(_mockStore.Object);
        }

        /// <summary>
        /// Ensure <see cref="SearchState.Initialize()"/> is called.
        /// </summary>
        [Fact]
        public void Handle_ShouldCall_SearchStateInitialize()
        {
            // Arrange.
            var mockSearchState = new Mock<SearchState>();
            _mockStore
                .Setup(store => store.GetState<SearchState>())
                .Returns(mockSearchState.Object);

            // Act.
            _handleQuery.Handle(new SearchState.ResetAction(), new CancellationToken());

            // Assert.
            mockSearchState.Verify(searchState => searchState.Initialize(), Times.Once);
        }
    }
}