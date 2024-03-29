﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModularMonolith.Contracts;
using ModularMonolith.History.Domain.Entities;
using ModularMonolith.History.Domain.Enums;
using ModularMonolith.History.Domain.Interfaces;

namespace ModularMonolith.History.Application.EventHandlers.Products
{
    public class ProductCreatedEventHandler : INotificationHandler<ProductCratedIntegrationEvent>
    {
        private readonly IHistoryEntityRepository _repository;

        public ProductCreatedEventHandler(IHistoryEntityRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(ProductCratedIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var history = EntityHistory.Create(notification.Id, notification.Name, EventType.Create);
            await _repository.Add(history);
            await _repository.CommitAsync();
        }

    }
}
