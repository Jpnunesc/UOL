using AutoMapper;
using Business.Interfaces.Repositories;
using Business.IO.Notification;
using Domain.Entitys;
using Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class NotificationRepository : RepositoryBase<CodeContext, NotificationEntity>, INotificationRepository
    {
        private readonly IMapper _mapper;
        public NotificationRepository(CodeContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }
        public async Task<NotificationOutPutPag> GetFilter(NotificationFilter filter)
        {
            var query = DbSet.AsQueryable();
            var totalItems = 0;

            if (filter.Tipo > 0)
            {
                query = query.Where(x => x.Tipo == filter.Tipo);
            }
            filter.Page = filter.Page ?? 1;
            filter.PageSize = filter.PageSize ?? 10;
            var skip = (filter.Page.Value - 1) * filter.PageSize.Value;
            totalItems = query.AsNoTracking().Count();

            var listProduct = await query
                    .AsNoTracking()
                    .Skip(skip)
                    .Take(filter.PageSize.Value)
                    .ToListAsync();

            var listOutPut = _mapper.Map<List<NotificationEntity>, List<NotificationOutput>>(listProduct);

            return new NotificationOutPutPag(totalItems, listOutPut);
        }
    }
}
