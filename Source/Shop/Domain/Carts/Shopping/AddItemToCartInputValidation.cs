/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.Carts.Shopping
{
    /// <summary>
    /// Represents the input validation for <see cref="AddItemToCart"/>
    /// </summary>
    public class AddItemToCartInputValidation : CommandInputValidatorFor<AddItemToCart>
    {
        /// <summary>
        /// Initializes a new instsance of <see cref="AddItemToCartInputValidation"/>
        /// </summary>
        public AddItemToCartInputValidation()
        {
            RuleFor(_ => _.Article.Value)
                .NotNull()
                .NotEmpty()
                .WithMessage("Article number has to be supplied");
                
            RuleFor(_ => _.Quantity)
                .GreaterThan(0)
                .WithMessage("Quantity has to be greater than 0");
        }
    }
}