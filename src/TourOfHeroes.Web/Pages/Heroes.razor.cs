using System.Linq;
using BlazorState;
using Microsoft.AspNetCore.Components;
using TourOfHeroes.Web.Common.Models;
using TourOfHeroes.Web.Common.State.Heroes;

namespace TourOfHeroes.Web.Pages
{
    /// <summary>
    /// Heroes dashboard.
    /// </summary>
    public class HeroesBase : BlazorStateComponent
    {
        /// <summary>
        /// Gets or sets the <see cref="NavigationManager"/>.
        /// </summary>
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        /// <summary>
        /// Gets the heroes state.
        /// </summary>
        protected HeroesState HeroesState => GetState<HeroesState>();

        /// <summary>
        /// Backing field for the create form.
        /// </summary>
        private protected Hero _hero = new Hero();

        /// <summary>
        /// Creates a <see cref="Hero"/>.
        /// </summary>
        protected void Create()
        {
            Mediator.Send(new HeroesState.CreateAction(_hero.Name));
            _hero.Name = string.Empty;
        }

        /// <summary>
        /// Deletes a <see cref="Hero"/>.
        /// </summary>
        /// <param name="id">The ID of the <see cref="Hero"/> to delete.</param>
        protected void Delete(int id)
        {
            Mediator.Send(new HeroesState.DestroyAction(id));
        }

        /// <summary>
        /// Send the user to the modify page.
        /// </summary>
        /// <param name="id">The ID of the <see cref="Hero"/> to modify.</param>
        protected void Modify(int id)
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