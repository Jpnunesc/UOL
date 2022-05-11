using Business.Enums;

namespace Business.IO.Notification
{
    public class NotificationOutput
    {
        public int Id { get; set; }
        public TypeNotificationEnum Type  { get; set; }
        public string Body { get; set; }
    }
}
