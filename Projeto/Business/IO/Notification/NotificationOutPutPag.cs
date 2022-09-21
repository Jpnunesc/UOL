using System;
using System.Collections.Generic;
using System.Text;

namespace Business.IO.Notification
{
    public class NotificationOutPutPag
    {
        public NotificationOutPutPag(int totalItems, IEnumerable<NotificationOutput> notification)
        {
            TotalItems = totalItems;
            Notification = notification;
        }

        public int TotalItems { get; set; }
        public IEnumerable<NotificationOutput> Notification { get; set; }
    }
}
