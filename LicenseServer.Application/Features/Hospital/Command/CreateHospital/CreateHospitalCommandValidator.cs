using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseServer.Application.Features.Hospital.Command.CreateHospital
{
    public class CreateHospitalCommandValidator:AbstractValidator<CreateHospitalCommand>
    {
        public CreateHospitalCommandValidator()
        {


            RuleFor(x => x.EmailAddress)
                .NotNull().When(x=>string.IsNullOrEmpty(x.PhoneNumber)).WithMessage("Please enter email address")
                .NotEmpty().When(x => string.IsNullOrEmpty(x.PhoneNumber)).WithMessage("Please enter email address")
                .EmailAddress().WithMessage("Please enter valid email address");
        }
    }
}
