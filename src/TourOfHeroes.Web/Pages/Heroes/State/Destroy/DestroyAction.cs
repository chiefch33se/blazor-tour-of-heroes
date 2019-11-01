using BlazorState;

namespace TourOfHeroes.Web.Pages.Heroes.State
{
    /// <inheritdoc/>
    public partial class HeroesState
    {
        /// <summary>
        /// Action for destroying a <see cref="Hero"/>.
        /// </summary>
        public class DestroyAction : IAction
        {
            /// <summary>
            /// Gets the ID of the <see cref="Hero"/>.
            /// </summary>
            public int Id { get; }

            /// <summary>
            /// Initializes a new instance of the <see cref="DestroyAction"/> class.
            /// </summary>
            /// <param name="id">The payload to create with.</param>
            public DestroyAction(int id)
            {
                Id = id;
            }
        }
    }
}
