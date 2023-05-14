using System;

namespace ModularMonolith.History.Application.Queries.GetHistory.Responses
{
    public class GetHistoryQueryResponse
    {
        public GetHistoryQueryResponse(string name, DateTime createDate, string eventType)
        {
            Name = name;
            CreateDate = createDate;
            EventType = eventType;
        }
        public string Name { get; }
        public DateTime CreateDate { get; }
        public string EventType { get; }


    }
}
