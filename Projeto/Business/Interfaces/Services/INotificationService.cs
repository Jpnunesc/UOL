using Business.IO;
using Business.IO.Notification;
using System.Threading.Tasks;

namespace Business.Interfaces.Services
{
    public interface INotificationService
    {
        Task<ReturnView> Save(NotificationInput notification);
        Task<ReturnView> Put(NotificationInput notification);
        Task<ReturnView> Delete(int id);
        Task<ReturnView> GetById(int id);
        Task<ReturnView> GetByFilter(NotificationFilter filter);
        Task<ReturnView> GetList();
    }
}
