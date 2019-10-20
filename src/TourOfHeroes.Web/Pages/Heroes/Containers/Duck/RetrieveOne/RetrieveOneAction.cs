using BlazorState;

namespace TourOfHeroes.Web.Pages.Heroes.Containers.Duck
{
    public partial class HeroesState 
    {
        public class RetrieveOneAction : IAction
        {
            public int Id { get; private set; }

            public RetrieveOneAction(int id)
            {
                Id = id;
            }
        }
    }
}