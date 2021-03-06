using Application.App.Contracts.Persistence;
using FluentValidation;
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

            RuleFor(e => e)
                .MustAsync(EventNameAndDateUnique)
                .WithMessage("An event with the same name and date already exists.");

            RuleFor(p => p.NameAr)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");//check arabic letters only

            RuleFor(p => p.NameEn)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull()
                .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(p => p.Number)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();
            //check that is numeric

            RuleFor(p => p.ContractorName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(p => p.ConsultingOfficeName)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(p => p.CityName)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(p => p.QuarterName)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull();

            RuleFor(p => p.PropertyFullAddress)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull();

            RuleFor(p => p.PropertyNumber)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull();

            RuleFor(p => p.PropertyLatitude)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull();

            RuleFor(p => p.PropertyLongitude)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull();

            RuleFor(p => p.IsActive)
              .NotEmpty().WithMessage("{PropertyName} is required.")
              .NotNull();

            RuleFor(p => p.SerialNumber)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(p => p.ProjectType)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(p => p.TotalArea)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull(); 

            RuleFor(p => p.InstrumentNumber)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull(); 

            RuleFor(p => p.BuildingLicenseNumber)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull(); 

            RuleFor(p => p.FloorsNumber)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull(); 

            RuleFor(p => p.FloorsNumber)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull(); 

            RuleFor(p => p.EstimatedCost)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull(); 

            RuleFor(p => p.InstrumentAttachment)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(p => p.BuildingLicenseAttachment)
               .NotEmpty().WithMessage("{PropertyName} is required.")
               .NotNull();

            RuleFor(p => p.ConstructionDiagrams)
                           .NotEmpty().WithMessage("{PropertyName} is required.")
                           .NotNull();

            RuleFor(p => p.MechanicalDiagrams)
                           .NotEmpty().WithMessage("{PropertyName} is required.")
                           .NotNull();

            RuleFor(p => p.ArchitecturalDiagrams)
                           .NotEmpty().WithMessage("{PropertyName} is required.")
                           .NotNull();

            RuleFor(p => p.ElictricalDiagrams)
                           .NotEmpty().WithMessage("{PropertyName} is required.")
                           .NotNull();

            RuleFor(p => p.SoilReport)
                           .NotEmpty().WithMessage("{PropertyName} is required.")
                           .NotNull();

            RuleFor(p => p.SurveyReport)
                           .NotEmpty().WithMessage("{PropertyName} is required.")
                           .NotNull();

            RuleFor(p => p.StocksNumber)
                           .NotEmpty().WithMessage("{PropertyName} is required.")
                           .NotNull();

            RuleFor(p => p.Cost)
                           .NotEmpty().WithMessage("{PropertyName} is required.")
                           .NotNull();

        }



        private async Task<bool> EventNameAndDateUnique(ProjectDto e, CancellationToken token)
        {
            return !(await _projectRepository.IsProjectNameUnique(e.NameAr, e.NameEn));
        }
    }
}
