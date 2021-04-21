using Application.App.Contracts.Persistence;
using FluentValidation;
using Localization.App;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.App.Services.Buildings
{
    public class BuildingValidator : AbstractValidator<BuildingDto>
    {
        private readonly IBuildingRepository _buildingRepository;
        public BuildingValidator(IBuildingRepository buildingRepository)
        {
            _buildingRepository = buildingRepository;

            RuleFor(p => p.EstimatedCost).GreaterThan(100000)
                .NotEmpty().WithMessage(x => AppResources.Required);

             RuleFor(p => p.NumberOfApartment).NotNull()/*.LessThan(50)*/
                .NotEmpty().WithMessage(x => AppResources.Required);

            RuleFor(p => p.NumberOfFloor).LessThan(10)
                .NotEmpty().WithMessage(x => AppResources.Required);

            RuleFor(p => p.StampingNumber)
                .NotEmpty().WithMessage(x => AppResources.Required);

            RuleFor(p => p.TotalSurfaceArea)
                .NotEmpty().WithMessage(x => AppResources.Required);

            RuleFor(p => p.LicenseNumber)
                .NotEmpty().WithMessage(x => AppResources.Required);

            RuleFor(p => p.ProjectId).NotNull().NotEmpty().WithMessage(x => AppResources.Required);

            RuleFor(e => e)
                .MustAsync(EventNameAndDateUnique)
                .WithMessage("An event with the same name and date already exists.");


        }

        private async Task<bool> EventNameAndDateUnique(BuildingDto e, CancellationToken token)
        {
            return !(await _buildingRepository.IsBuildingNumberUnique(e.Number));
        }
    }
}
