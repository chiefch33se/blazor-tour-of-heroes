using BlazorState;
using TourOfHeroes.Web.Common.Models;

namespace TourOfHeroes.Web.Pages.Details.State
{
    /// <summary>
    /// Single source of truth for details.
    /// </summary>
    public partial class DetailsState : State<DetailsState>
    {
        /// <summary>
        /// Gets or sets a <see cref="Hero"/>.
        /// </summary>
        public Hero Hero { get; private set; }

        /// <inheritdoc/>
        public override void Initialize()
        {
            Hero = new Hero();
        }
    }
}