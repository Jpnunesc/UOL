using Domain.Entity;
using System;

namespace Domain.Entitys
{
    public class NotificationEntity : BaseEntity
    {
        public int Tipo { get; set; }
        public string Mensagem { get; set; }
        public string EmailDestinatario { get; set; }
        public string EmailOrigem { get; set; }
        public string NumDestinario { get; set; }
        public string Assunto { get; set; }
        public string Cliente { get; set; }
        public string NomeUsuario { get; set; }

    }
}
