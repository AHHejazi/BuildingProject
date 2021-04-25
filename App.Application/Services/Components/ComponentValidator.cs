using App.Application.Contracts.Persistence;
using FluentValidation;
using Localization.App;
using System.Threading;
using System.Threading.Tasks;

namespace Application.App.Services.Components
{
        public class ComponentValidator : AbstractValidator<ComponentDto>
        {
            private readonly IComponentRepository _componentRepository;
            public ComponentValidator(IComponentRepository componentRepository)
            {
            _componentRepository = componentRepository;

                RuleFor(p => p.NameAr)
                    .NotNull().WithMessage(x => AppResources.Required)
                    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

                RuleFor(p => p.NameEn)
                    .NotNull().WithMessage(x => AppResources.Required)
                    .MaximumLength(50).WithMessage("{PropertyName} must not exceed 50 characters.");

            RuleFor(e => e)
            .MustAsync(async (e, cancellationToken) => await EventNameAndDateUnique(e, cancellationToken))
            .WithMessage("An event with the same name and date already exists.")
            .When(p => !string.IsNullOrEmpty(p.NameAr) && !string.IsNullOrEmpty(p.NameEn));

        }

        private async Task<bool> EventNameAndDateUnique(ComponentDto e, CancellationToken token)
        {
            return !(await _componentRepository.IsComponentNameUnique(e.NameAr, e.NameEn));
        }
    }
    }