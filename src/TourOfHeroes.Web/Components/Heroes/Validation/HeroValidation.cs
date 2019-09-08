using FluentValidation;
using TourOfHeroes.Data;

namespace TourOfHeroes.Web.Components.Heroes.Validation
{
    /// <summary>
    /// Validation rules for <see cref="Hero"/>.
    /// </summary>
    public class HeroValidation : AbstractValidator<Hero>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HeroValidation"/> class.
        /// </summary>
        public HeroValidation()
        {
            RuleFor(hero => hero.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(hero => hero.Name).MaximumLength(50).WithMessage("Name is too long");
        }
    }
}