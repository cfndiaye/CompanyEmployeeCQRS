using System;
using Application.Queries;
using AutoMapper;
using Contracts;
using Entities.Exceptions;
using MediatR;
using Shared.DataTransferObjects;

namespace Application.Handlers;

internal class GetCompanyHandler : IRequestHandler<GetCompanyQuery, CompanyDto>
{
    private readonly IRepositoryManager _repositooryManager;
    private readonly IMapper _mapper;

    public GetCompanyHandler(IRepositoryManager repositoryManager, IMapper mapper)
    {
        _repositooryManager = repositoryManager;
        _mapper = mapper;
    }

    public async Task<CompanyDto> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
    {
        var company = await _repositooryManager.Company.GetCompanyAsync(request.Id, trackChanges: false);
        if (company is null) throw new CompanyNotFoundException(request.Id);


        return _mapper.Map<CompanyDto>(company);
    }
}

