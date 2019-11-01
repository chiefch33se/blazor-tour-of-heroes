using BlazorState;

namespace TourOfHeroes.Web.Pages.Heroes.State
{
    /// <inheritdoc/>
    public partial class HeroesState
    {
        /// <summary>
        /// Action for retrieving a single <see cref="Hero"/>.
        /// </summary>
        protected internal class RetrieveOneAction : IAction
        {
            /// <summary>
            /// Gets or sets the ID of the <see cref="Hero"/> to retrieve.
            /// </summary>
            public int Id { get; private set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="RetrieveOneAction"/> class.
            /// </summary>
            /// <param name="id">The payload to create with.</param>
            public RetrieveOneAction(int id)
            {
                Id = id;
            }
        }
    }
}