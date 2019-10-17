namespace MyBlazorApp.Client.Features.Base
{
  using BlazorState;
    using TourOfHeroes.Components.Heroes.State;

    /// <summary>
    /// Base Handler that makes it easy to access state
    /// </summary>
    /// <typeparam name="TAction"></typeparam>
    public abstract class BaseHandler<TAction> : ActionHandler<TAction>
    where TAction : IAction
  {
    protected HeroState _heroState => Store.GetState<HeroState>();

    public BaseHandler(IStore aStore) : base(aStore) { }
  }
}