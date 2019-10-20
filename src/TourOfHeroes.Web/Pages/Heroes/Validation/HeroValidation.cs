using FluentValidation;
using TourOfHeroes.Web.Pages.Heroes.Models;

namespace TourOfHeroes.Web.Pages.Heroes.Validation
{
    /// <summary>
    /// Validation rules for <see cref="Hero"/>.
    /// </summary>
    public class HeroValidation : AbstractValidator<Hero>
    {
        /// <summary>
        /// The maximum length that <see cref="Hero.Name"/> can be.
        /// </summary>
        public static int HeroNameMaxLength = 50;

        /// <summary>
        /// Initializes a new instance of the <see cref="HeroValidation"/> class.
        /// </summary>
        public HeroValidation()
        {
            RuleFor(hero => hero.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(hero => hero.Name).MaximumLength(HeroNameMaxLength).WithMessage("Name is too long");
        }
    }
}