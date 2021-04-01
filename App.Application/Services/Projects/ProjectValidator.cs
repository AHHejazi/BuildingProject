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

            RuleFor(p => p.Number).NotNull().WithMessage(x => AppResources.Required)
                .MinimumLength(10).WithMessage("{PropertyName} must not exceed 10 characters.");

            RuleFor(p => p.QuarterName)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull();

            RuleFor(e => e)
                .MustAsync(async (e, cancellationToken) => await EventNameAndDateUnique(e, cancellationToken))
                .WithMessage("An event with the same name and date already exists.")
            .When(p => !string.IsNullOrEmpty(p.NameAr) && !string.IsNullOrEmpty(p.NameEn));

            RuleFor(p => p.PropertyNumber)
                .NotEmpty().WithMessage("{PropertyName} is required.");
        }

        private async Task<bool> EventNameAndDateUnique(ProjectDto e, CancellationToken token)
        {
            return !(await _projectRepository.IsProjectNameUnique(e.NameAr, e.NameEn));
        }
    }
}
