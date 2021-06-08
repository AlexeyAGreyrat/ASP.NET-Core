using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Timesheets.Infrastructure.Constants;
using Timesheets.Models.Dto;
using FluentValidation;

namespace Timesheets.Infrastructupe.Validation
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator()
        {
            RuleFor(x => x.Login).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
