using BlazorState;

namespace TourOfHeroes.Web.Pages.Heroes.State
{
    /// <inheritdoc/>
    public partial class HeroesState 
    {
        /// <summary>
        /// Action for creating a <see cref="Hero"/>.
        /// </summary>
        public class CreateAction : IAction
        {
            /// <summary>
            /// Gets the name of the <see cref="Hero"/>.
            /// </summary>
            public string Name { get; }

            /// <summary>
            /// Initializes a new instance of the <see cref="CreateAction"/> class.
            /// </summary>
            /// <param name="name">The payload to create with.</param>
            public CreateAction(string name)
            {
                Name = name;
            }
        }
    }
}
