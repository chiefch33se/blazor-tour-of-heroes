using System.Linq;
using BlazorState;
using Microsoft.AspNetCore.Components;
using TourOfHeroes.Web.Common.State.Heroes;

namespace TourOfHeroes.Web.Common.Containers.TopHeroes
{
    /// <summary>
    /// Top Heroes.
    /// </summary>
    public class TopHeroesBase : BlazorStateComponent
    {
        /// <summary>
        /// Gets the heroes state.
        /// </summary>
        protected HeroesState HeroesState => GetState<HeroesState>();

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