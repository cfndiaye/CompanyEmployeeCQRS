using System;
using Application.Commands;
using FluentValidation;
using FluentValidation.Results;

namespace Application.Validators;

public sealed class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
{
    public CreateCompanyCommandValidator()
    {
        RuleFor(c => c.CompanyForCreationDto.Name).NotEmpty().MaximumLength(60);
        RuleFor(c => c.CompanyForCreationDto.Address).NotEmpty().MaximumLength(60);
    }

    public override ValidationResult Validate(ValidationContext<CreateCompanyCommand> context)
    {
        return context.InstanceToValidate.CompanyForCreationDto is null
            ? new ValidationResult(new[]
            {
               new ValidationFailure("CompanyForCreationDto", "CompanyForCreationDto is null")
            })
            : base.Validate(context);
    }

}

