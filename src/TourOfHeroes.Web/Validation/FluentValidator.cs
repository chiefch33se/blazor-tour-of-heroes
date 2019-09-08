using System;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace TourOfHeroes.Web.Validation
{
    /// <summary>
    /// Custom validator component which uses Fluent validation.
    /// </summary>
    public class FluentValidator : ComponentBase
    {
        /// <summary>
        /// Gets or sets the forms <see cref="EditContext"/>.
        /// </summary>
        [CascadingParameter]
        public EditContext EditContext { get; set; }

        /// <summary>
        /// Initialization of the validator.
        /// </summary>
        protected override void OnInitialized()
        {
            if (EditContext == null)
            {
                throw new InvalidOperationException();
            }

            EditContext.AddFluentValidation();
        }
    }
}