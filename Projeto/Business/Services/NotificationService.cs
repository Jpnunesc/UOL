using Business.Constante;
using Business.Enums;
using Business.Extensions;
using Business.Interfaces.Repositories;
using Business.Interfaces.Services;
using Business.IO;
using Business.IO.Notification;
using Business.Validations;
using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IMapper _mapper;
        private readonly Messages _messages;
        private readonly INotificationRepository _repository;
        public NotificationService(IMapper mapper, INotificationRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ReturnView> Save(NotificationInput notification)
        {
            var validate = NotificationInput.Validate();
            if (!validate.Status)
            {
                return validate;
            }
            var registerEntity = _mapper.Map<NotificationInput, NotificationEntity>(notification);
            return new ReturnView() { Object = _mapper.Map<NotificationEntity, NotificationOutput>(await _repository.Add(registerEntity)), Message = _messages.MessageSuccess, Status = true };
        }

        public Task<ReturnView> Put(NotificationInput notification)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnView> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnView> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnView> GetByFilter(NotificationFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<ReturnView> GetList()
        {
            throw new NotImplementedException();
        }
        public void Dispose()
        {
            _repository?.Dispose();
        }
    }
}
