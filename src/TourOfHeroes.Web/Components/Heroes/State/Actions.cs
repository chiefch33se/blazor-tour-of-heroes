using MediatR;

namespace TourOfHeroes.Web.Components.Heroes.State
{
    public class AddAction : IRequest<HeroState>
    {
        public string Name;

        public AddAction(string name)
        {
            Name = name;
        }
    }

    public class LoadAction : IRequest<HeroState> { }
}