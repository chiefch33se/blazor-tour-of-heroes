using TourOfHeroes.Web.Pages.Heroes.Models;
using TourOfHeroes.Web.Pages.Heroes.State;
using Xunit;

namespace TourOfHeroes.Web.Tests.Pages.Heroes.State.Modify
{
    /// <summary>
    /// Unit tests for <see cref="HeroesState.ModifyAction"/>.
    /// </summary>
    public class ModifyActionTests : HeroesState
    {
        /// <summary>
        /// Happy path.
        /// </summary>
        /// <param name="expectedId">The ID payload to test with.</param>
        /// <param name="expectedName">The Name payload to test with.</param>
        [Theory]
        [InlineData(1, "Tornado")]
        [InlineData(2, "Magneta")]
        public void ModifyAction_ValidPayload_SetsPayload(int expectedId, string expectedName)
        {
            // Given a well formed action.
            var actualPayload = new HeroesState.ModifyAction(new Hero
            {
                Id = expectedId,
                Name = expectedName
            });

            // It should be instanciated with the given payload.
            Assert.Equal(expectedId, actualPayload.Hero.Id);
            Assert.Equal(expectedName, actualPayload.Hero.Name);
        }
    }
}
