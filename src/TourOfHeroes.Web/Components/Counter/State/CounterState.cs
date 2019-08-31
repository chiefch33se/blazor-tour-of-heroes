using BlazorState;

namespace TourOfHeroes.Web.Components.Counter.State
{
    public partial class CounterState : State<CounterState>
    {
        public int Count { get; private set; }

        protected override void Initialize() => Count = 3;
    }
}