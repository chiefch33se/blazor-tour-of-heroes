using System.Collections.Generic;
using BlazorState;
using TourOfHeroes.Web.Pages.Heroes.Models;

namespace TourOfHeroes.Web.Pages.Heroes.State
{
    /// <summary>
    /// Single source of truth for everything heroes.
    /// </summary>
    public partial class HeroesState : State<HeroesState>
    {
        /// <summary>
        /// Gets or sets a <see cref="List{Hero}"/>.
        /// </summary>
        public List<Hero> Heroes { get; private set; }

        /// <summary>
        /// Gets or sets a <see cref="Hero"/>.
        /// </summary>
        public Hero Hero { get; private set; }

        /// <inheritdoc/>
        public override void Initialize()
        {
            Heroes = new List<Hero>();
            Hero = new Hero();
        }
    }
}