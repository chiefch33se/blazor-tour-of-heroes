using System.Collections.Generic;
using BlazorState;
using TourOfHeroes.Web.Common.Models;

namespace TourOfHeroes.Web.Common.State.Search
{
    /// <summary>
    /// Single source of truth for search.
    /// </summary>
    public partial class SearchState : State<SearchState>
    {
        /// <summary>
        /// Gets or sets the <see cref="Hero"/> found during the search.
        /// </summary>
        public IReadOnlyCollection<Hero> Results { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the query resulted in an empty set.
        /// </summary>
        public bool NoResults { get; private set; }

        /// <inheritdoc/>
        public override void Initialize()
        {
            Results = new List<Hero>();
            NoResults = false;
        }
    }
}
