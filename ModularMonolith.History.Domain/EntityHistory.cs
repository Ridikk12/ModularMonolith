using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ModularMonolith.History.Domain
{
    public class EntityHistory
    {
        public string EntityName { get; set; }
        public Guid EntityId { get; set; }
        public EventType EventType { get; set; }
        public string RaisedBy { get; set; }
        public DateTime RaisedOn { get; set; }

    }

    public enum EventType
    {
        Create,
        Update,
        Delete
    }
}
