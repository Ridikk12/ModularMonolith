using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ModularMonolith.History.Domain
{
    public class EntityHistory
    {
        private EntityHistory()
        {

        }
        private EntityHistory(string entityName, Guid entityId, EventType eventType, string raisedBy, DateTime raisedOn)
        {
            EntityName = entityName;
            EntityId = entityId;
            EventType = eventType;
            RaisedBy = raisedBy;
            RaisedOn = raisedOn;
        }
        public Guid Id { get; private set; }
        public string EntityName { get; private set; }
        public Guid EntityId { get; private set; }
        public EventType EventType { get; private set; }
        public string RaisedBy { get; private set; }
        public DateTime RaisedOn { get; private set; }

        public static EntityHistory Create(Guid entityId, string entityName, EventType eventType, string raisedBy, DateTime raisedOn) =>
            new EntityHistory(entityName, entityId, eventType, raisedBy, raisedOn);


    }
}
