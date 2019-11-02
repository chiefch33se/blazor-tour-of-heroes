using System.Linq;
using BlazorState;
using Microsoft.AspNetCore.Components;
using TourOfHeroes.Web.Common.Models;
using TourOfHeroes.Web.Common.State.Details;
using TourOfHeroes.Web.Common.State.Heroes;

namespace TourOfHeroes.Web.Pages
{
    /// <summary>
    /// Hero details.
    /// </summary>
    public class HeroDetailsBase : BlazorStateComponent
    {
        /// <summary>
        /// Gets or sets the <see cref="NavigationManager"/>.
        /// </summary>
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Hero"/> ID from the URL parameter.
        /// </summary>
        [Parameter]
        public int HeroId { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the given hero exists.
        /// </summary>
        public bool HeroNotFound { get; set; }

        /// <summary>
        /// Backing property for the edit form.
        /// </summary>
        private protected Hero _hero = new Hero();

        /// <summary>
        /// Gets the heroes state.
        /// </summary>
        protected DetailsState DetailsState => GetState<DetailsState>();

        /// <summary>
        /// Gets the heroes state.
        /// </summary>
        protected HeroesState HeroesState => GetState<HeroesState>();

        /// <summary>
        /// Updates the given <see cref="Hero"/>.
        /// </summary>
        protected void Modify()
        {
            Mediator.Send(new DetailsState.ModifyAction(_hero));
            NavigateBack();
        }

        /// <summary>
        /// Sends the user back to the heroes dashboard.
        /// </summary>
        protected void NavigateBack()
        {
            NavigationManager.NavigateTo("/heroes");
        }

        /// <inheritdoc/>
        protected override void OnParametersSet()
        {
            Mediator.Send(new DetailsState.RetrieveOneAction(HeroId));

            HeroNotFound = DetailsState.Hero is null;

            if (HeroNotFound == false)
            {
                _hero.Id = DetailsState.Hero.Id;
            }
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