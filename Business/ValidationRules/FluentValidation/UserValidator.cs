using Core.Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator:AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.LastName).NotEmpty().DependentRules(() =>
            {
                RuleFor(u => u.FirstName).NotEmpty();
            });

            RuleFor(u => u.FirstName).MinimumLength(3);
            RuleFor(u => u.LastName).MinimumLength(2);
            RuleFor(p => p.Email).Must(MailCheck).When(p => p.Email != null).WithMessage("IsValid Mail");
            RuleFor(p => p.Email).NotEmpty();
        }

        private bool MailCheck(string arg)
        {
            return arg.Contains("@");
        }

    }
}
