using DoctorWho.Db.DTOs;
using FluentValidation;

namespace DoctorWho.web.Validators
{
    public class EpisodeValidator: AbstractValidator<EpisodeDto>
    {
        public EpisodeValidator()
        {
            RuleFor(x => x.AuthorId).NotNull().NotEmpty();
            RuleFor(x => x.DoctorId).NotNull().NotEmpty();
            RuleFor(x => x.SeriesNumber.ToString()).Length(10).WithMessage(x => "SeriesNumber must be 10 characters in length. You entered "+x.SeriesNumber.ToString().Length+" characters.\"");
            RuleFor(x => x.EpisodNumber).GreaterThan(0);
        }
    }
}
