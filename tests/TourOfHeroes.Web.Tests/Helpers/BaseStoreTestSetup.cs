using BlazorState;
using Moq;
using TourOfHeroes.Web.Common.Containers.Search.State;
using TourOfHeroes.Web.Pages.Details.State;
using TourOfHeroes.Web.Pages.Heroes.State;

namespace TourOfHeroes.Web.Tests.Helpers
{
    /// <summary>
    /// Provides the necessary setup for the state.
    /// </summary>
    public abstract class BaseStoreTestSetup
    {
        /// <summary>
        /// The <see cref="HeroesState"/> to test with.
        /// </summary>
        private protected readonly HeroesState _heroesState;

        /// <summary>
        /// The <see cref="HeroesState"/> to test with.
        /// </summary>
        private protected readonly DetailsState _detailsState;

        /// <summary>
        /// The <see cref="SearchState"/> to test with.
        /// </summary>
        private protected readonly SearchState _searchState;

        /// <summary>
        /// The <see cref="Mock{IStore}"/> to test with.
        /// </summary>
        private protected readonly Mock<IStore> _mockStore;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseHeroStateTestSetup"/> class.
        /// </summary>
        public BaseStoreTestSetup()
        {
            _mockStore = new Mock<IStore>();

            // Setup Heroes State.
            _heroesState = new HeroesState();
            _heroesState.Initialize();
            _mockStore
                .Setup(store => store.GetState<HeroesState>())
                .Returns(_heroesState);

            // Setup Details State.
            _detailsState = new DetailsState();
            _detailsState.Initialize();
            _mockStore
                .Setup(store => store.GetState<DetailsState>())
                .Returns(_detailsState);

            // Setup Search State.
            _searchState = new SearchState();
            _searchState.Initialize();
            _mockStore
                .Setup(store => store.GetState<SearchState>())
                .Returns(_searchState);
        }
    }
}