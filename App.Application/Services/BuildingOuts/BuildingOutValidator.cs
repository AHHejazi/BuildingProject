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

            RuleFor(p => p.BuildingId)
                .NotNull().NotEmpty().WithMessage(x => AppResources.Required);

            RuleFor(p => p.ComponentId)
               .NotNull().NotEmpty().WithMessage(x => AppResources.Required);

            RuleFor(p => p.OutbuildingsTypeId)
               .NotNull().NotEmpty().WithMessage(x => AppResources.Required);

        }
    }
}