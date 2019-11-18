using BlazorState;
using TourOfHeroes.Web.Common.State.Details;

namespace TourOfHeroes.Web.Pages
{
    public class StateBase : BlazorStateComponent
    {
        protected DetailsState DetailsState => GetState<DetailsState>();

        public void HasClicked()
        {
            Mediator.Send(new DetailsState.Message1Action());
            Mediator.Send(new DetailsState.Message2Action());
        }
    }
}