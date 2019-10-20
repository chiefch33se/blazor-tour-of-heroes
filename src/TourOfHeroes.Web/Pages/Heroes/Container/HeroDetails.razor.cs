using BlazorState;
using Microsoft.AspNetCore.Components;
using TourOfHeroes.Data;
using TourOfHeroes.Web.Pages.Heroes.Container.Duck;

namespace TourOfHeroes.Web.Pages.Heroes.Container
{
    public class HeroDetailsBase : BlazorStateComponent
    {
        [Parameter]
        public int HeroId { get; set; }
        public bool _heroNotFound = false;
        protected Hero _hero = new Hero();
        protected HeroesState _heroesState => GetState<HeroesState>();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected void Modify()
        {
            Mediator.Send(new HeroesState.ModifyAction(_hero));
            NavigateBack();
        }

        protected override void OnParametersSet() 
        {
            Mediator.Send(new HeroesState.RetrieveOneAction(HeroId));

            if (_heroesState.Hero is null)
            {
                _heroNotFound = true;
            }
            else
            {
                _hero.Id = _heroesState.Hero.Id;
            }
        }

        protected void NavigateBack()
        {
            NavigationManager.NavigateTo($"/heroes");
        }
    }
}