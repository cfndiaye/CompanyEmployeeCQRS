using System;
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Commands;

public sealed record UpdateCompanyCommand(Guid Id, CompanyForUpdateDto CompanyForUpdateDto, bool TrackChanges) : IRequest<Unit>;


