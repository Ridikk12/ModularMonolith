using Newtonsoft.Json;
using System;

namespace ModularMonolith.Outbox.Entities
{
    public class OutBoxMessage
    {
        protected OutBoxMessage()
        {

        }

        public Guid Id { get; private set; }
        public string Message { get; private set; }
        public DateTime SavedOn { get; private set; }
        public DateTime? ExecutedOn { get; set; }
        public string Type { get; private set; }

        public static OutBoxMessage New(object message)
        {
            var serializedMessage = JsonConvert.SerializeObject(message);
            var type = message.GetType().ToString();

            return new OutBoxMessage
            {
                Message = serializedMessage,
                Type = type,
                SavedOn = DateTime.UtcNow,
                Id = Guid.NewGuid()
            };
        }
    }

}