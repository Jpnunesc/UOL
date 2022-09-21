
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
using Business.IO.Notification;
using System.Threading.Tasks;

namespace Test.Tests.service
{
    public class ProdutoTest
    {
        Mock<IMapper> mapper = new();
        Mock<INotificationRepository> mockRepository = new();
        [Fact(DisplayName = "Salvar Produto")]
        public void RegisterProductWithCorrectDataMustReturnRegistered()
        {
            
            NotificationService service = new(mapper.Object, mockRepository.Object);
            var body = new NotificationInput
            {
                Tipo = 1,
                Mensagem = "teste",
                EmailDestinatario = "teste",
                EmailOrigem = "teste",
                Assunto = "teste",
                Cliente = "teste",
                NomeUsuario = "teste"
            };
            mockRepository.Setup(s => s.Add(It.IsAny<NotificationEntity>())).Returns(Task.FromResult(new NotificationEntity()));
            var result = service.Save(body);
            Assert.True(result.Result.Status);

        }
    }
}
