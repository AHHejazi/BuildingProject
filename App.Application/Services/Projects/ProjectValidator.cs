using Application.App.Contracts.Persistence;
using FluentValidation;
using Localization.App;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.App.Services.Projects
{
    public class ProjectValidator : AbstractValidator<ProjectDto>
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectValidator(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;

            RuleFor(p => p.NameAr)
                .NotNull().WithMessage(x => AppResources.Required)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.NameEn)
                .NotNull().WithMessage(x => AppResources.Required)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.ContractorName).NotNull().WithMessage(x => AppResources.Required)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.ConsultingOfficeName).NotNull().WithMessage(x => AppResources.Required)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.CityName).NotNull().WithMessage(x => AppResources.Required)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.QuarterName).NotNull().WithMessage(x => AppResources.Required)
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.PropertyFullAddress).NotNull().WithMessage(x => AppResources.Required)
                .MaximumLength(300).WithMessage("{PropertyName} must not exceed 300 characters.");

            RuleFor(p => p.PropertyNumber).NotEmpty().WithMessage(x => AppResources.Required);

            RuleFor(p => p.PropertyLatitude).NotEmpty().WithMessage(x => AppResources.Required);

            RuleFor(p => p.PropertyLongitude).NotEmpty().WithMessage(x => AppResources.Required);

            RuleFor(p => p.SerialNumber).NotEmpty().WithMessage(x => AppResources.Required);

            RuleFor(p => p.ProjectTypeId).NotNull().NotEmpty().WithMessage(x => AppResources.Required);

            RuleFor(p => p.IsActive).NotNull().WithMessage(x => AppResources.Required);

            RuleFor(p => p.TotalArea).NotEmpty().WithMessage(x => AppResources.Required);

            RuleFor(p => p.InstrumentNumber).NotEmpty().WithMessage(x => AppResources.Required);

            RuleFor(p => p.BuildingLicenseNumber).NotEmpty().WithMessage(x => AppResources.Required);

            RuleFor(p => p.BuildingTechnique).NotNull().WithMessage(x => AppResources.Required);

            RuleFor(p => p.FloorsNumber).NotEmpty().WithMessage(x => AppResources.Required);

            RuleFor(p => p.EstimatedCost).NotEmpty().WithMessage(x => AppResources.Required);

            //RuleFor(p => p.InstrumentAttachment).NotNull().WithMessage(x => AppResources.Required);

            //RuleFor(p => p.BuildingLicenseAttachment).NotNull().WithMessage(x => AppResources.Required);

            //RuleFor(p => p.ConstructionDiagrams).NotNull().WithMessage(x => AppResources.Required);

            //RuleFor(p => p.MechanicalDiagrams).NotNull().WithMessage(x => AppResources.Required);

            //RuleFor(p => p.ArchitecturalDiagrams).NotNull().WithMessage(x => AppResources.Required);

            //RuleFor(p => p.ElictricalDiagrams).NotNull().WithMessage(x => AppResources.Required);

            //RuleFor(p => p.SoilReport).NotNull().WithMessage(x => AppResources.Required);

            //RuleFor(p => p.SurveyReport).NotNull().WithMessage(x => AppResources.Required);

            //RuleFor(p => p.StocksNumber).NotEmpty().WithMessage(x => AppResources.Required);

            //RuleFor(p => p.Cost).NotEmpty().WithMessage(x => AppResources.Required);

            RuleFor(e => e)
             .MustAsync(async (e, cancellationToken) => await EventNameAndDateUnique(e, cancellationToken))
             .WithMessage("An event with the same name and date already exists.")
             .When(p => !string.IsNullOrEmpty(p.NameAr) && !string.IsNullOrEmpty(p.NameEn));


        }

        private async Task<bool> EventNameAndDateUnique(ProjectDto e, CancellationToken token)
        {
            return !(await _projectRepository.IsProjectNameUnique(e.NameAr, e.NameEn));
        }
    }
}
