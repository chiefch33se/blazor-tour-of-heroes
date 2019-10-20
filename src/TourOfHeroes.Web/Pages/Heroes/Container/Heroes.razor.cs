using System.Linq;
using BlazorState;
using Microsoft.AspNetCore.Components;
using TourOfHeroes.Data;
using TourOfHeroes.Web.Pages.Heroes.Container.Duck;

namespace TourOfHeroes.Web.Pages.Heroes.Container
{
    public class HeroesBase : BlazorStateComponent
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected HeroesState _heroesState => GetState<HeroesState>();

        protected Hero _hero = new Hero();

        protected void Create()
        {
            Mediator.Send(new HeroesState.CreateAction(_hero.Name));
            _hero.Name = string.Empty;
        }

        protected void Delete(int id)
        {
            Mediator.Send(new HeroesState.DestroyAction(id));
        }

        protected void Modify(int id)
        {
            NavigationManager.NavigateTo($"/heroes/{id}");
        }

        protected override void OnInitialized()
        {
            if (_heroesState.Heroes.Any() == false)
            {
                Mediator.Send(new HeroesState.RetrieveManyAction());
            }
        }
    }
}