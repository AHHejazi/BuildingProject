using Application.App.Contracts.Persistence;
using FluentValidation;
using Localization.App;

namespace Application.App.Services.BuildingOuts
{
    public class BuildingOutValidator : AbstractValidator<BuildingOutDto>
    {
        private readonly IBuildingOutRepository _BuildingOutRepository;
        public BuildingOutValidator(IBuildingOutRepository BuildingOutRepository)
        {
            _BuildingOutRepository = BuildingOutRepository;

            RuleFor(p => p.NameAr)
                .NotNull().WithMessage(x => AppResources.Required)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.NameEn)
                .NotNull().WithMessage(x => AppResources.Required)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

        }
    }
}