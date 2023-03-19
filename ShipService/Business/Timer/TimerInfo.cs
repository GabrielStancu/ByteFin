namespace ShipService.Business.Timer;

public class TimerInfo
{
    public TimerScheduleStatus? ScheduleStatus { get; set; }

    public bool IsPastDue { get; set; }
}