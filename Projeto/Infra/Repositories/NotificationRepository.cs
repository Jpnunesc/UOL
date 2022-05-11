using Business.Interfaces.Repositories;
using Business.IO.Notification;
using Domain.Entitys;
using Infra.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class NotificationRepository : RepositoryBase<CodeContext, NotificationEntity>, INotificationRepository
    {
        public NotificationRepository(CodeContext context) : base(context)
        {
        }
        public Task<IEnumerable<NotificationEntity>> GetFilter(NotificationFilter filter)
        {
            var query = DbSet as IQueryable<NotificationEntity>;

            throw new System.NotImplementedException();
        }
    }
}
