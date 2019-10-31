using BlazorState;

namespace TourOfHeroes.Web.Pages.Heroes.State
{
    public partial class HeroesState 
    {
        public class DestroyAction: IAction
        {
            public int Id { get; private set; }

            public DestroyAction(int id)
            {
                Id = id;
            }
        }
    }
}