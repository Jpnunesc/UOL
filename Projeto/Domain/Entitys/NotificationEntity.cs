using Domain.Entity;
using System;

namespace Domain.Entitys
{
    public class NotificationEntity : BaseEntity
    {
        public int Type { get; set; }
        public string Body { get; set; }

    }
}
