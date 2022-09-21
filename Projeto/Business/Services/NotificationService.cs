using AutoMapper;
using Business.Constante;
using Business.Interfaces.Repositories;
using Business.Interfaces.Services;
using Business.IO;
using Business.IO.Notification;
using Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IMapper _mapper;
        private readonly Messages _messages = new Messages();
        private readonly INotificationRepository _repository;
        public NotificationService(IMapper mapper, INotificationRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ReturnView> Save(NotificationInput notification)
        {
            try
            {
                var validate = notification.Validate(notification);
                if (!validate.Status)
                {
                    return validate;
                }
                var registerEntity = _mapper.Map<NotificationInput, NotificationEntity>(notification);
                return new ReturnView() { Object = _mapper.Map<NotificationEntity, NotificationOutput>(await _repository.Add(registerEntity)), Message = _messages.MessageSuccess, Status = true };
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task<ReturnView> Put(NotificationInput notification)
        {
            var validate = notification.Validate(notification);
            if (!validate.Status)
            {
                return validate;
            }
            var registerEntity = _mapper.Map<NotificationInput, NotificationEntity>(notification);
            return new ReturnView() { Object = _mapper.Map<NotificationEntity, NotificationOutput>(await _repository.Update(registerEntity)), Message = _messages.MessageSuccess, Status = true };
        }

        public async Task<ReturnView> Delete(int id)
        {
            await _repository.Remove(id);
            return new ReturnView() { Message = _messages.MessageSuccess, Status = true };
        }

        public async Task<ReturnView> GetById(int id)
        {
            return new ReturnView() { Object = _mapper.Map<NotificationEntity, NotificationOutput>(await _repository.Get(x => x.Id == id)), Message = _messages.MessageSuccess, Status = true };
        }

        public async Task<ReturnView> GetByFilter(NotificationFilter filter)
        {
            return new ReturnView() { Object = await _repository.GetFilter(filter), Message = _messages.MessageSuccess, Status = true };
        }
        public void Dispose()
        {
            _repository?.Dispose();
        }
    }
}
