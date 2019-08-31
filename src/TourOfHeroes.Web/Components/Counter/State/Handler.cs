using System.Threading;
using System.Threading.Tasks;
using BlazorState;

namespace TourOfHeroes.Web.Components.Counter.State
{
    public partial class CounterState
    {
        public class HandleIncrementAction : RequestHandler<IncrementAction, CounterState>
        {
            public HandleIncrementAction(IStore store) : base(store) { }

            private CounterState _counterState => Store.GetState<CounterState>();

            public override Task<CounterState> Handle(IncrementAction aRequest, CancellationToken aCancellationToken)
            {
                _counterState.Count = _counterState.Count + 1;
                return Task.FromResult(_counterState);
            }
        }
    }
}