using App.Application.Contracts.Persistence;
using FluentValidation;
using Localization.App;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.App.Services.Supplies
{
        public class SuppliesValidator : AbstractValidator<SuppliesDto>
        {
            private readonly ISuppliesRepository _suppliesRepository;
            public SuppliesValidator(ISuppliesRepository suppliesRepository)
            {
            _suppliesRepository = suppliesRepository;

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

        private async Task<bool> EventNameAndDateUnique(SuppliesDto e, CancellationToken token)
        {
            return !(await _suppliesRepository.IsSupplyNameUnique(e.NameAr, e.NameEn));
        }
    }
    }