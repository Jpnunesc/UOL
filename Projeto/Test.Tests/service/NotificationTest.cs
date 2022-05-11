
using AutoMapper;
using Moq;
using Xunit;
using Business.Services;
using Business.Interfaces.Repositories;
using Business.Interfaces.Services;
using Domain.Entitys;
using System.Collections.Generic;
using System.Configuration;
using System;
using System.IO;

namespace Test.Tests.service
{
    public class NotificationTest
    {
        Mock<IMapper> mapper = new Mock<IMapper>();
        Mock<INotificationRepository> mockRepository = new Moq.Mock<INotificationRepository>();
        [Fact(DisplayName = "Salvar notificação")]
        public async void CadastrarNotificacao_ComDadosCorretos_DeveRetornarCadastrado()
        {
            NotificationService service = new NotificationService(mapper.Object, mockRepository.Object);
            //Assert.True(result.Status);

        }
    }
}
