using System.Linq;
using BlazorState;
using TourOfHeroes.Components.Heroes.Feature;
using TourOfHeroes.Data;

namespace TourOfHeroes.Components.Heroes
{
    internal class HeroesComponentBase : BlazorStateComponent
    {
        protected HeroState _heroState => GetState<HeroState>();
        protected Hero _hero = new Hero();

        protected void Add()
        {
            Mediator.Send(new Feature.Add.HeroState.AddAction(_hero.Name));
            _hero.Name = string.Empty;
        }

        protected void Delete(Hero hero)
        {
            Mediator.Send(new Feature.Delete.HeroState.DeleteAction(hero));
        }

        protected override void OnInitialized()
        {
            if (_heroState.Heroes.Any() == false)
            {
                Mediator.Send(new Feature.Get.HeroState.GetAction());
            }
        }
    }
}