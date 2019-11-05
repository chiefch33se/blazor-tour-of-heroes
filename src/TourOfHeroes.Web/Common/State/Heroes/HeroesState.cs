using System.Collections.Generic;
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
    }
}