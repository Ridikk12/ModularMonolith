using System;

namespace ModularMonolith.History.Application.Features.History.Get.Responses;

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