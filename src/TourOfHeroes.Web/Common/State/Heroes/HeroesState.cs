using System.Collections.Generic;
using System.Reflection;
using BlazorState;
using TourOfHeroes.Web.Common.Models;

namespace TourOfHeroes.Web.Common.State.Heroes
{
    /// <summary>
    /// Single source of truth for heroes.
    /// </summary>
    public partial class HeroesState : State<HeroesState>
    {
        /// <summary>
        /// Gets or sets a <see cref="List{Hero}"/>.
        /// </summary>
        public IReadOnlyCollection<Hero> Heroes { get; private set; }

        /// <inheritdoc/>
        public override void Initialize()
        {
            Heroes = new List<Hero>();
        }

        /// <summary>
        /// Hydrate the state.
        /// </summary>
        /// <param name="aKeyValuePairs">The state to hydrate with.</param>
        /// <returns>This object.</returns>
        public override HeroesState Hydrate(IDictionary<string, object> aKeyValuePairs)
        {
            // Provides a way for the tests to hydrate the state.
            // Otherwise, it's just the handler that should do anything with state.
            ThrowIfNotTestAssembly(Assembly.GetCallingAssembly());

            Heroes = aKeyValuePairs[nameof(Heroes)] as IReadOnlyCollection<Hero>;

            return this;
        }
    }
}