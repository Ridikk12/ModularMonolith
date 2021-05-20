using System;
using Microsoft.EntityFrameworkCore;

namespace ModularMonolith.Outbox.Entities
{
    public class OutBoxMessage
    {

        private OutBoxMessage()
        {

        }

        public Guid Id { get; private set; }
        public string Message { get; private set; }
        public DateTime SavedOn { get; private set; }
        public DateTime? ExecutedOn { get; set; }
        public string Type { get; private set; }

        public static OutBoxMessage New(string message, string type) => new OutBoxMessage
        {
            SavedOn = DateTime.UtcNow,
            Id = Guid.NewGuid(),
            Message = message,
            Type = type
        };
    }

}
