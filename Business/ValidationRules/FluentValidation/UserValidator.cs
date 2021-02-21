using Entities.Concrete;
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
            RuleFor(u => u.LastName).NotNull().DependentRules(() => {
                RuleFor(u => u.FirstName).NotNull();
            });

            RuleFor(u => u.FirstName).MinimumLength(3);
            RuleFor(u => u.LastName).MinimumLength(2);
            RuleFor(u => u.Password).Must(UserPasswordRule).WithMessage("Şifre dört Rakamdan oluşmalı.");

        }

        private bool UserPasswordRule(int arg)
        {
            const int length = 4;
            string password = arg.ToString();

            if (password == null && password.Length!=length )
            {
                throw new ArgumentNullException();
            }

            bool IsValid = password.Length == length;

            return IsValid;
        }
    }
}
