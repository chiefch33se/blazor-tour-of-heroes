using BlazorState;
using TourOfHeroes.Web.Common.Models;

namespace TourOfHeroes.Web.Common.Containers.Search.State
{
    /// <summary>
    /// Single source of truth for search.
    /// </summary>
    public partial class SearchState : State<SearchState>
    {
        /// <summary>
        /// Gets or sets the <see cref="Hero"/> found during the search.
        /// </summary>
        public Hero Hero { get; private set; }

        /// <inheritdoc/>
        public override void Initialize()
        {
            Hero = new Hero();
        }
    }
}
