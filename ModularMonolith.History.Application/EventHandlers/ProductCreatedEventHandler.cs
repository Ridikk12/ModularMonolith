using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using ModularMonolith.Contracts;
using ModularMonolith.History.Domain;

namespace ModularMonolith.History.Application.EventHandlers
{
    public class ProductCreatedEventHandler : INotificationHandler<ProductCratedEvent>
    {
        private readonly IHistoryEntityRepository _repository;

        public ProductCreatedEventHandler(IHistoryEntityRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(ProductCratedEvent notification, CancellationToken cancellationToken)
        {
            var history = EntityHistory.Create(notification.Id, notification.Name, EventType.Create,
                notification.CreatedBy, notification.CreatedOn);
            await _repository.Add(history);
        }

    }
}
