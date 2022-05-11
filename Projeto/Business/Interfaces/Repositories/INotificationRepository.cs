using Business.IO.Notification;
using Domain.Entitys;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces.Repositories
{
    public interface INotificationRepository : IRepositoryBase<NotificationEntity>
    {
        Task<IEnumerable<NotificationEntity>> GetFilter(NotificationFilter filter);
    }
}
