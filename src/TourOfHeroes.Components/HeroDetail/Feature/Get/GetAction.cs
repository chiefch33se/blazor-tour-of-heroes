using BlazorState;

namespace TourOfHeroes.Components.HeroDetail.Feature.Get
{
    public partial class HeroDetailState 
    {
        public class GetAction : IAction
        {
            internal readonly int _id;

            public GetAction(int id)
            {
                _id = id;
            }
        }
    }
}