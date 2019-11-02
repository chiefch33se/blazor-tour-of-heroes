using BlazorState;

namespace TourOfHeroes.Web.Common.Containers.Search.State
{
    /// <inheritdoc/>
    public partial class SearchState
    {
        /// <summary>
        /// Action to find a <see cref="Hero"/> by name.
        /// </summary>
        public class QueryAction : IAction
        {
            public string Query { get; }

            /// <summary>
            /// Initializes a new instance of the <see cref="QueryAction"/> class.
            /// </summary>
            /// <param name="query">The query payload.</param>
            public QueryAction(string query)
            {
                Query = query;
            }
        }
    }
}