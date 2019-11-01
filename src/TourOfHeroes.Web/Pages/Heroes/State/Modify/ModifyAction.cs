using BlazorState;
using TourOfHeroes.Web.Pages.Heroes.Models;

namespace TourOfHeroes.Web.Pages.Heroes.State
{
    /// <inheritdoc/>
    public partial class HeroesState 
    {
        /// <summary>
        /// Action for modifying a <see cref="Hero"/>.
        /// </summary>
        protected internal class ModifyAction: IAction
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
                Hero = hero;
            }
        }
    }
}
