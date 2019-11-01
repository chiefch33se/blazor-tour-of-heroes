using FluentValidation;

namespace TourOfHeroes.Web.Common.Models.Validation
{
    /// <summary>
    /// Validation rules for <see cref="Hero"/>.
    /// </summary>
    public class HeroValidationCollection : AbstractValidator<Hero>
    {
        /// <summary>
        /// The maximum length that <see cref="Hero.Name"/> can be.
        /// </summary>
        public const int HeroNameMaxLength = 50;

        /// <summary>
        /// Initializes a new instance of the <see cref="HeroValidationCollection"/> class.
        /// </summary>
        public HeroValidationCollection()
        {
            RuleFor(hero => hero.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(hero => hero.Name).MaximumLength(HeroNameMaxLength).WithMessage("Name is too long");
        }
    }
}