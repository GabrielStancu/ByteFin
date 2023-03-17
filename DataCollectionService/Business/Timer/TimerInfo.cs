using DataCollectionService.Business.Timer;

namespace DataCollectionService.Business;

public class TimerInfo
{
    public ScheduleStatus? ScheduleStatus { get; set; }
    public bool IsPastDue { get; set; }
}
