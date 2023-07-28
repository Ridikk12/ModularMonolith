using System;
using ModularMonolith.History.Domain.Enums;

namespace ModularMonolith.History.Domain.Entities
{
    public class EntityHistory
    {
        private EntityHistory()
        {
        }

        private EntityHistory(string entityName, Guid entityId, EventType eventType)
        {
            EntityName = entityName;
            EntityId = entityId;
            EventType = eventType;
        }

        public Guid Id { get; private set; }
        public string EntityName { get; private set; }
        public Guid EntityId { get; private set; }
        public EventType EventType { get; private set; }
        public string RaisedBy { get; private set; }
        public DateTime RaisedOn { get; private set; }

        public static EntityHistory Create(Guid entityId, string entityName, EventType eventType) =>
            new EntityHistory(entityName, entityId, eventType);
    }
}