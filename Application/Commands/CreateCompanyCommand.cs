using System;
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Commands;

public sealed record  CreateCompanyCommand(CompanyForCreationDto CompanyForCreationDto): IRequest<CompanyDto>;


