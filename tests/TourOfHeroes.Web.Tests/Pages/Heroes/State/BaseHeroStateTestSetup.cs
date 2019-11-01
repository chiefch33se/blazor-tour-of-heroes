using BlazorState;
using Moq;
using TourOfHeroes.Web.Pages.Heroes.State;

namespace TourOfHeroes.Web.Tests.Pages.Heroes.State
{
    /// <summary>
    /// Provides the necessary setup for <see cref="HeroesState"/> handler tests.
    /// </summary>
    public abstract class BaseHeroStateTestSetup : HeroesState
    {
        /// <summary>
        /// The <see cref="HeroesState"/> to test with.
        /// </summary>
        private protected readonly HeroesState _heroesState;

        /// <summary>
        /// The <see cref="Mock{IStore}"/> to test with.
        /// </summary>
        private protected readonly Mock<IStore> _mockStore;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseHeroStateTestSetup"/> class.
        /// </summary>
        public BaseHeroStateTestSetup()
        {
            _heroesState = new HeroesState();
            _heroesState.Initialize();
            _mockStore = new Mock<IStore>();
            _mockStore
                .Setup(store => store.GetState<HeroesState>())
                .Returns(_heroesState);
        }
    }
}