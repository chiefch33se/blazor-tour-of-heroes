using System;
using BlazorState;
using TourOfHeroes.Web.Common.Models;

namespace TourOfHeroes.Web.Common.State.Details
{
    /// <inheritdoc/>
    public partial class DetailsState
    {
        public class Message2Action : IAction
        {

            /// <summary>
            /// Initializes a new instance of the <see cref="Message2Action"/> class.
            /// </summary>
            /// <param name="hero">The payload to create with.</param>
            public Message2Action()
            {
            }
        }
    }
}
