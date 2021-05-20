using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using ModularMonolith.Contracts.Events;

namespace ModularMonolith.Contracts
{
    public class ProductCratedIntegrationEvent : INotification, IIntegrationEvent
    {
        public ProductCratedIntegrationEvent()
        {

        }
        public ProductCratedIntegrationEvent(Guid id, string name, string description, string createdBy, DateTime createdOn)
        {
            Name = name;
            Description = description;
            CreatedBy = createdBy;
            CreatedOn = createdOn;
            Id = id;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
