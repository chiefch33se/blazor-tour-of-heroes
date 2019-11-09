using System.Linq;
using BlazorState;
using Microsoft.AspNetCore.Components;
using TourOfHeroes.Web.Common.State.Heroes;
using System.Threading.Tasks;
using System.Collections.Generic;
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
        /// Gets or sets the selected hero from the search.
        /// </summary>
        public Hero SelectedHero
        {
            get 
            { 
                return null;
            }
            set
            {
                // Bit hacky but it works.
                NavigationManager.NavigateTo($"/details/{value.Id}");
            }
        }

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
        protected async Task<IEnumerable<Hero>> SearchHeroes(string query)
        {
            return await Task.FromResult(HeroesState.Heroes
                .Where(hero => hero.Name.ToLowerInvariant()
                    .Contains(query.ToLowerInvariant())));
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