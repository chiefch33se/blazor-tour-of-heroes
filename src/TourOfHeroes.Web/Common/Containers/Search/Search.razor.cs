using System.Collections.Generic;
using System.Threading.Tasks;
using BlazorState;
using Microsoft.AspNetCore.Components;
using TourOfHeroes.Web.Common.Containers.Search.State;
using TourOfHeroes.Web.Common.Models;

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

        public Hero _selectedHero = new Hero();

        public async Task<IEnumerable<Hero>> SearchHeroes(string searchText)
        {
            await Mediator.Send(new SearchState.QueryAction(searchText));
            
            return SearchState.Results;
        }
    }
}