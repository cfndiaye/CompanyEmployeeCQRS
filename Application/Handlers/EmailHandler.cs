using System;
using Application.Notifications;
using Contracts;
using MediatR;

namespace Application.Handlers;

internal sealed class EmailHandler : INotificationHandler<CompanyDeletedNotification>
{
    private readonly ILoggerManager _loggerManager;

    public EmailHandler(ILoggerManager loggerManager) => _loggerManager = loggerManager;
    

    public async Task Handle(CompanyDeletedNotification notification, CancellationToken cancellationToken)
    {
        _loggerManager.LogWarn($"Delete action for the company with id: {notification.Id} has occurred.");

        await Task.CompletedTask;
    }
}

