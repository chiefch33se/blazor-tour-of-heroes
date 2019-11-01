using System.Collections.Generic;
using TourOfHeroes.Web.Common.Models;
using Xunit;

namespace TourOfHeroes.Web.Tests.Common.Models
{
    /// <summary>
    /// Unit tests for <see cref="Hero"/>.
    /// </summary>
    public class HeroTests
    {
        /// <summary>
        /// Happy path.
        /// </summary>
        [Fact]
        public void Equals_IsEqual_ShouldBeTrue()
        {
            // Arrange.
            var tornado1 = new Hero
            {
                Id = 1,
                Name = "Tornado"
            };
            var tornado2 = new Hero
            {
                Id = 1,
                Name = "Tornado"
            };

            // Act.
            var results = new List<bool>();
            results.Add(tornado1.Equals(tornado2));
            results.Add(tornado1.Equals(tornado2 as object));

            // Assert.
            Assert.True(results.TrueForAll(item => item));
        }

        /// <summary>
        /// Entities not equal should not return true on equality.
        /// </summary>
        [Fact]
        public void Equals_NotEqual_ShouldBeFalse()
        {
            // Arrange.
            var tornado = new Hero
            {
                Id = 1,
                Name = "Tornado"
            };

            // Act.
            var results = new List<bool>();
            results.Add(tornado.Equals(new Hero()));
            results.Add(tornado.Equals(new object()));

            // Assert.
            Assert.True(results.TrueForAll(item => item == false));
        }
    }
}
