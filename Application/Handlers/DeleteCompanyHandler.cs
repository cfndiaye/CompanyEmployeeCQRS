using System;
using Application.Commands;
using Application.Notifications;
using Contracts;
using Entities.Exceptions;
using MediatR;

namespace Application.Handlers;

public class DeleteCompanyHandler : INotificationHandler<CompanyDeletedNotification>
{
    private readonly IRepositoryManager _repositoryManager;

    public DeleteCompanyHandler(IRepositoryManager repositoryManager)
    {
        _repositoryManager = repositoryManager;
    }

    public async Task Handle(CompanyDeletedNotification notification, CancellationToken cancellationToken)
    {
        var company = await _repositoryManager.Company.GetCompanyAsync(notification.Id, trackChanges: notification.TrackChanges);
        if (company is null) throw new CompanyNotFoundException(notification.Id);


         _repositoryManager.Company.DeleteCompany(company);

        await _repositoryManager.SaveAsync();

        
    }
}

