using MediatR;

namespace TourOfHeroes.Web.Components.Counter.State
{
    public class IncrementAction : IRequest<CounterState> { }
}