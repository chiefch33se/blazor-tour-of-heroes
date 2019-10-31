using System.Linq;
using TourOfHeroes.Web.Pages.Heroes.Models;
using TourOfHeroes.Web.Pages.Heroes.Validation;
using Xunit;

namespace TourOfHeroes.Web.Tests.Pages.Heroes.Validation
{
    public class HeroValidationCollectionTests
    {
        private HeroValidationCollection _HeroValidationCollection;

        /// <summary>
        /// Ensures a new <see cref="HeroValidationCollection"/> for each test run.
        /// </summary>
        public HeroValidationCollectionTests()
        {
            _HeroValidationCollection = new HeroValidationCollection();
        }

        /// <summary>
        /// Happy path.
        /// </summary>
        [Fact]
        public void HeroValidationCollection_ValidModel_PassesValidation()
        {
            // Given valid model.
            // When validated.
            var result = _HeroValidationCollection.Validate(ValidHero);

            // Then should pass validation.
            Assert.True(result.IsValid);
        }

        [Fact]
        public void HeroValidationCollection_RuleFor_NotEmpty()
        {
            // Given empty name.
            var hero = ValidHero;
            hero.Name = string.Empty;

            // When validated.
            var result = _HeroValidationCollection.Validate(hero);

            // Then should fail validation with one error.
            Assert.False(result.IsValid);
            var validationFailure = result.Errors.ToList().Single();
            Assert.True(validationFailure.PropertyName == nameof(Hero.Name));
            Assert.True(validationFailure.ErrorMessage == "Name is required");
        }

        [Fact]
        public void HeroValidationCollection_RuleFor_MaximumLength()
        {
            // Given name that is too long.
            var hero = ValidHero;
            hero.Name = new string(Enumerable.Repeat('a', HeroValidationCollection.HeroNameMaxLength + 1).ToArray());

            // When validated.
            var result = _HeroValidationCollection.Validate(hero);

            // Then should fail validation with one error.
            Assert.False(result.IsValid);
            var validationFailure = result.Errors.ToList().Single();
            Assert.True(validationFailure.PropertyName == nameof(Hero.Name));
            Assert.True(validationFailure.ErrorMessage == "Name is too long");
        }

        private Hero ValidHero => new Hero
        {
            Id = 1,
            Name = new string(Enumerable.Repeat('a', HeroValidationCollection.HeroNameMaxLength).ToArray())
        };
    }
}