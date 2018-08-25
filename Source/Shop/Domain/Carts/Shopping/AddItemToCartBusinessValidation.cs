/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Dolittle. All rights reserved.
 *  Licensed under the MIT License. See LICENSE in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
using Dolittle.Commands.Validation;
using FluentValidation;

namespace Domain.Carts.Shopping
{
    public class AddItemToCartBusinessValidation : CommandBusinessValidatorFor<AddItemToCart>
    {
        public AddItemToCartBusinessValidation()
        {
            
        }
        
    }
}