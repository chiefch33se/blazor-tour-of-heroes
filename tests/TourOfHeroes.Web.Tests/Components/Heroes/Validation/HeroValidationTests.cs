using System.Linq;
using TourOfHeroes.Data;
using TourOfHeroes.Web.Components.Heroes.Validation;
using Xunit;

namespace TourOfHeroes.Web.Tests.Components.Heroes.Validation
{
    public class HeroValidationTests
    {
        private HeroValidation _heroValidation;

        /// <summary>
        /// Ensures a new <see cref="HeroValidation"/> for each test run.
        /// </summary>
        public HeroValidationTests()
        {
            _heroValidation = new HeroValidation();
        }

        /// <summary>
        /// Happy path.
        /// </summary>
        [Fact]
        public void HeroValidation_ValidModel_PassesValidation()
        {
            // Given valid model.
            // When validated.
            var result = _heroValidation.Validate(ValidHero);

            // Then should pass validation.
            Assert.True(result.IsValid);
        }

        [Fact]
        public void HeroValidation_RuleFor_NotEmpty()
        {
            // Given empty name.
            var hero = ValidHero;
            hero.Name = string.Empty;

            // When validated.
            var result = _heroValidation.Validate(hero);

            // Then should fail validation with one error.
            Assert.False(result.IsValid);
            var validationFailure = result.Errors.ToList().Single();
            Assert.True(validationFailure.PropertyName == nameof(Hero.Name));
            Assert.True(validationFailure.ErrorMessage == "Name is required");
        }

        [Fact]
        public void HeroValidation_RuleFor_MaximumLength()
        {
            // Given name that is too long.
            var hero = ValidHero;
            hero.Name = new string(Enumerable.Repeat('a', HeroValidation.HeroNameMaxLength + 1).ToArray());

            // When validated.
            var result = _heroValidation.Validate(hero);

            // Then should fail validation with one error.
            Assert.False(result.IsValid);
            var validationFailure = result.Errors.ToList().Single();
            Assert.True(validationFailure.PropertyName == nameof(Hero.Name));
            Assert.True(validationFailure.ErrorMessage == "Name is too long");
        }

        private Hero ValidHero => new Hero
        {
            Id = 1,
            Name = new string(Enumerable.Repeat('a', HeroValidation.HeroNameMaxLength).ToArray())
        };
    }
}