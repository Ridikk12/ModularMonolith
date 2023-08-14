using MediatR;
using ModularMonolith.Contracts.Events;
using System;

namespace ModularMonolith.Contracts
{
    public class ProductCratedIntegrationEvent : INotification, IIntegrationEvent
    {
        public ProductCratedIntegrationEvent(Guid id, string name, string description)
        {
            Name = name;
            Description = description;
            Id = id;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}