using System;
using BlazorState;
using TourOfHeroes.Web.Common.Models;

namespace TourOfHeroes.Web.Pages.Details.State
{
    /// <inheritdoc/>
    public partial class DetailsState
    {
        /// <summary>
        /// Action for modifying a <see cref="Hero"/>.
        /// </summary>
        public class ModifyAction : IAction
        {
            /// <summary>
            /// Gets the modified <see cref="Hero"/>.
            /// </summary>
            public Hero Hero { get; }

            /// <summary>
            /// Initializes a new instance of the <see cref="ModifyAction"/> class.
            /// </summary>
            /// <param name="hero">The payload to create with.</param>
            public ModifyAction(Hero hero)
            {
                Hero = hero ?? throw new ArgumentNullException(nameof(hero));
            }
        }
    }
}
