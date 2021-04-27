using System;
using System.Collections.Generic;
using System.Text;
using MediatR;

namespace ModularMonolith.Contracts
{
    public class ProductCratedEvent : INotification
    {
        public ProductCratedEvent(string name, string description, string createdBy, DateTime createdOn)
        {
            Name = name;
            Description = description;
            CreatedBy = createdBy;
            CreatedOn = createdOn;
        }
        public string Name { get; }
        public string Description { get; }
        public string CreatedBy { get; }
        public DateTime CreatedOn { get; }
    }
}
