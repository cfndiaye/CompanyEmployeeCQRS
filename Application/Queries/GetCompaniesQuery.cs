using System;
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Queriesl;

public record GetCompaniesQuery(bool TrackChanges) : IRequest<IEnumerable<CompanyDto>>;


