using BlazorState;
using Microsoft.AspNetCore.Components;
using TourOfHeroes.Data;
using TourOfHeroes.Web.Pages.Heroes.Feature;

namespace TourOfHeroes.Web.Pages.Heroes.Containers
{
    public class HeroDetailsBase : BlazorStateComponent
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int HeroId { get; set; }

        protected bool _heroNotFound = false;

        protected Hero _hero = new Hero();

        protected HeroesState _heroesState => GetState<HeroesState>();

        protected void Modify()
        {
            Mediator.Send(new HeroesState.ModifyAction(_hero));
            NavigateBack();
        }

        protected override void OnParametersSet() 
        {
            Mediator.Send(new HeroesState.RetrieveOneAction(HeroId));
            _heroNotFound = _heroesState.Hero is null;

            if (_heroNotFound == false)
            {
                _hero.Id = _heroesState.Hero.Id;
            }
        }

        protected void NavigateBack()
        {
            NavigationManager.NavigateTo("/heroes");
        }
    }
}