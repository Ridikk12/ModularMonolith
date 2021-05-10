using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace ModularMonolith.Contracts
{
    public class ProductCratedEvent : INotification, IIntegrationEvent
    {
        public ProductCratedEvent(Guid id, string name, string description, string createdBy, DateTime createdOn)
        {
            Name = name;
            Description = description;
            CreatedBy = createdBy;
            CreatedOn = createdOn;
            Id = id;
        }
        public Guid Id { get; }
        public string Name { get; }
        public string Description { get; }
        public string CreatedBy { get; }
        public DateTime CreatedOn { get; }
    }

    public interface IIntegrationEvent
    {

    }
}
