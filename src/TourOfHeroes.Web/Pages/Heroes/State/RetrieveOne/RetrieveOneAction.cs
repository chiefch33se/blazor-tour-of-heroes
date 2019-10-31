using BlazorState;

namespace TourOfHeroes.Web.Pages.Heroes.State
{
    public partial class HeroesState 
    {
        internal class RetrieveOneAction : IAction
        {
            public int Id { get; private set; }

            public RetrieveOneAction(int id)
            {
                Id = id;
            }
        }
    }
}