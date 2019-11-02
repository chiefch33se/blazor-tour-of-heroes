using System.Linq;
using BlazorState;
using Microsoft.AspNetCore.Components;
using TourOfHeroes.Web.Common.State.Search;
using TourOfHeroes.Web.Common.State.Heroes;

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

        /// <summary>
        /// Gets the heroes state.
        /// </summary>
        protected HeroesState HeroesState => GetState<HeroesState>();

        /// <summary>
        /// The search query.
        /// </summary>
        private protected string _searchText = string.Empty;

        /// <summary>
        /// Search for a hero.
        /// </summary>
        public void SearchHeroes()
        {
            Mediator.Send(new SearchState.QueryAction(_searchText));
        }

        /// <summary>
        /// Reset the control.
        /// </summary>
        public void ResetControl()
        {
            Mediator.Send(new SearchState.ResetAction());
        }

        /// <summary>
        /// Send the user to the details page.
        /// </summary>
        /// <param name="id">The ID of the <see cref="Hero"/> to view details for.</param>
        protected void NavigateToHeroDetails(int id)
        {
            NavigationManager.NavigateTo($"/details/{id}");
        }

        /// <inheritdoc/>
        protected override void OnInitialized()
        {
            if (HeroesState.Heroes.Any() == false)
            {
                Mediator.Send(new HeroesState.RetrieveManyAction());
            }
        }
    }
}