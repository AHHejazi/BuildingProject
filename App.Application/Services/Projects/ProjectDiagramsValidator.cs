using Application.App.Contracts.Persistence;
using FluentValidation;
using Localization.App;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.App.Services.Projects
{
    public class ProjectDiagramsValidator : AbstractValidator<ProjectDiagramsDto>
    {
        public ProjectDiagramsValidator()
        {

            RuleFor(p => p.InstrumentAttachmentId).NotNull().WithMessage(x => AppResources.Required);

            RuleFor(p => p.BuildingLicenseAttachmentId).NotNull().WithMessage(x => AppResources.Required);

            RuleFor(p => p.ConstructionDiagramId).NotNull().WithMessage(x => AppResources.Required);

            //RuleFor(p => p.MechanicalDiagrams).NotNull().WithMessage(x => AppResources.Required);

            //RuleFor(p => p.ArchitecturalDiagrams).NotNull().WithMessage(x => AppResources.Required);

            //RuleFor(p => p.ElictricalDiagrams).NotNull().WithMessage(x => AppResources.Required);

            //RuleFor(p => p.SoilReport).NotNull().WithMessage(x => AppResources.Required);

            //RuleFor(p => p.SurveyReport).NotNull().WithMessage(x => AppResources.Required);

            //RuleFor(p => p.StocksNumber).NotEmpty().WithMessage(x => AppResources.Required);

            //RuleFor(p => p.Cost).NotEmpty().WithMessage(x => AppResources.Required);


        }

    }
}
