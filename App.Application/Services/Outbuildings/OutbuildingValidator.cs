﻿using App.Application.Contracts.Persistence;
using Application.App.Contracts.Persistence;
using FluentValidation;
using Localization.App;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.App.Services.Outbuildings
{
        public class OutbuildingValidator : AbstractValidator<OutbuildingDto>
        {
            private readonly IOutbuildingRepository _OutbuildingRepository;
            public OutbuildingValidator(IOutbuildingRepository OutbuildingRepository)
            {
            _OutbuildingRepository = OutbuildingRepository;

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

        private async Task<bool> EventNameAndDateUnique(OutbuildingDto e, CancellationToken token)
        {
            return !(await _OutbuildingRepository.IsOutbuildingNameUnique(e.NameAr, e.NameEn));
        }
    }
    }