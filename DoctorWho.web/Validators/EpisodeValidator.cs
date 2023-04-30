using DoctorWho.Db.DTOs;
using FluentValidation;

namespace DoctorWho.web.Validators
{
    public class EpisodeValidator: AbstractValidator<EpisodeUpsertDto>
    {
        public EpisodeValidator()
        {       
            RuleFor(x => x.DoctorId).NotNull().NotEmpty();
            RuleFor(x => x.AuthorId).NotNull().NotEmpty();
            RuleFor(x => x.SeriesNumber).Length(10);
            RuleFor(x => x.EpisodNumber).GreaterThan(0);
        }
    }
}
