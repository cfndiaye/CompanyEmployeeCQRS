using System;
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Queries;

public sealed record GetCompanyQuery(Guid Id, bool Trackchange) : IRequest<CompanyDto>;


