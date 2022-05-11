using AutoMapper;
using Business.IO.Notification;
using Business.IO.Users;
using System.Collections.Generic;

namespace Business.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<NotificationEntity, NotificationOutput>();
            CreateMap<NotificationOutput, NotificationEntity>(MemberList.None);

            CreateMap<NotificationInput,  NotificationEntity>(MemberList.None);
            CreateMap<NotificationEntity, NotificationInput>(MemberList.None);

            CreateMap<UserAuthView, UserEntity>(MemberList.None);
            CreateMap<UserEntity, UserAuthView>(MemberList.None);


        }
    }

}