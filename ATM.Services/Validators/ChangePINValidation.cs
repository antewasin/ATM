using ATM.Services.Commands.Card;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATM.Services.Validators
{
    public class ChangePINValidation : AbstractValidator<ChangePIN>
    {
        public ChangePINValidation()
        {
            RuleFor(c => c.PIN).Length(4);
        }
    }
}
