using BlazorState;
using Microsoft.AspNetCore.Components;
using TourOfHeroes.Web.Common.Containers.Search.State;

namespace TourOfHeroes.Web.Common.Containers.Search
{
    /// <summary>
    /// Search Heroes.
    /// </summary>
    public class SearchBase : BlazorStateComponent
    {
        /// <summary>
        /// Gets or sets the <see cref="NavigationManager"/>.
        /// </summary>
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        /// <summary>
        /// Gets the heroes state.
        /// </summary>
        protected SearchState SearchState => GetState<SearchState>();

        public string SearchText = string.Empty;

        public void SearchHeroes()
        {
            Mediator.Send(new SearchState.QueryAction(SearchText));
        }

        public void ResetControl()
        {
            Mediator.Send(new SearchState.ResetAction());
        }
    }
}