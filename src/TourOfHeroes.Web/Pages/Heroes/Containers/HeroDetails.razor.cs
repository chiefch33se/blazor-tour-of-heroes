using BlazorState;
using Microsoft.AspNetCore.Components;
using TourOfHeroes.Web.Pages.Heroes.Models;
using TourOfHeroes.Web.Pages.Heroes.State;

namespace TourOfHeroes.Web.Pages.Heroes.Containers
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
        /// Gets or sets the backing property for the edit form.
        /// </summary>
        public Hero Hero { get; set; }

        /// <summary>
        /// Gets the heroes state.
        /// </summary>
        protected HeroesState HeroesState => GetState<HeroesState>();

        /// <summary>
        /// Updates the given <see cref="Hero"/>.
        /// </summary>
        protected void Modify()
        {
            Mediator.Send(new HeroesState.ModifyAction(Hero));
            NavigateBack();
        }

        /// <inheritdoc/>
        protected override void OnParametersSet() 
        {
            Mediator.Send(new HeroesState.RetrieveOneAction(HeroId));
            HeroNotFound = HeroesState.Hero is null;

            if (HeroNotFound == false)
            {
                Hero.Id = HeroesState.Hero.Id;
            }
        }

        /// <summary>
        /// Sends the user back to the heroes dashboard.
        /// </summary>
        protected void NavigateBack()
        {
            NavigationManager.NavigateTo("/heroes");
        }
    }
}