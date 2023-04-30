using DoctorWho.Db.DTOs;
using FluentValidation;

namespace DoctorWho.web.Validators
{
    public class DoctorDtoValidator:AbstractValidator<DoctorDto>
    {
        public DoctorDtoValidator() {
            RuleFor(x => x.DoctorNumber)
                .NotNull()
                .NotEmpty();
            RuleFor(x => x.DoctorName)
                .NotEmpty()
                .NotNull();
            RuleFor(x => x.LastEpisodDate).Empty().When(x => !x.FirstEpisodDate.HasValue).WithMessage("Last Episod Date should be empty when First Episod Date is empty");
            RuleFor(x => x.LastEpisodDate).GreaterThanOrEqualTo(x => x.FirstEpisodDate).When(x => x.FirstEpisodDate.HasValue).WithMessage("Last Episod Date' must be greater than or equal to First Episod Date");

        }

    }
}
