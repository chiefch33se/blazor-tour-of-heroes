using System;
using System.Diagnostics.CodeAnalysis;

namespace TourOfHeroes.Web.Pages.Heroes.Models
{
    /// <summary>
    /// Represents a Hero entity.
    /// </summary>
    public class Hero : Entity, IEquatable<Hero>
    {
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Equality comparer.
        /// </summary>
        /// <param name="other">Other <see cref="Hero"/> to check against.</param>
        /// <returns>True if equal.</returns>
        public bool Equals([AllowNull] Hero other)
        {
            return other != null && other.Id == Id && other.Name == Name;
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            return Equals(obj as Hero);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
