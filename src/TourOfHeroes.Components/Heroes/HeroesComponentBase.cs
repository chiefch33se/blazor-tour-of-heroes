using System.Linq;
using BlazorState;
using Microsoft.AspNetCore.Components;
using TourOfHeroes.Components.Heroes.Feature;
using TourOfHeroes.Data;

namespace TourOfHeroes.Components.Heroes
{
    public class HeroesComponentBase : BlazorStateComponent
    {
        protected HeroesState _heroesState => GetState<HeroesState>();
        protected Hero _hero = new Hero();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected void Add()
        {
            Mediator.Send(new Feature.Add.HeroesState.AddAction(_hero.Name));
            _hero.Name = string.Empty;
        }

        protected void Delete(Hero hero)
        {
            Mediator.Send(new Feature.Delete.HeroesState.DeleteAction(hero));
        }

        protected void Edit(int id)
        {
            NavigationManager.NavigateTo($"/heroes/{id}");
        }

        protected override void OnInitialized()
        {
            if (_heroesState.Heroes.Any() == false)
            {
                Mediator.Send(new Feature.Get.HeroesState.GetAction());
            }
        }
    }
}