using System;
using TourOfHeroes.Web.Common.Models;
using TourOfHeroes.Web.Common.State.Details;
using Xunit;

namespace TourOfHeroes.Web.Tests.Common.State.Details.Modify
{
    /// <summary>
    /// Unit tests for <see cref="HeroesState.ModifyAction"/>.
    /// </summary>
    public class ModifyActionTests
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
            var payload = new Hero
            {
                Id = expectedId,
                Name = expectedName
            };
            var action = new DetailsState.Message2Action(payload);

            // It should be instanciated with the given payload.
            Assert.Equal(payload, action.Hero);
        }

        /// <summary>
        /// If given a null payload, the action should throw an <see cref="ArgumentNullException"/>.
        /// </summary>
        [Fact]
        public void CreateAction_NullPayload_Throws()
        {
            // Given an invalid payload.
            Assert.Throws<ArgumentNullException>(() => new DetailsState.Message2Action(null));
        }
    }
}
