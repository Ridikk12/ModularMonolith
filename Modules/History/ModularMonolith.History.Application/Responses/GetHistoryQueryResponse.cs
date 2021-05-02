using System;
using System.Collections.Generic;
using System.Text;

namespace ModularMonolith.History.Application.Responses
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
