using Business.Enums;

namespace Business.IO.Notification
{
    public class NotificationOutput
    {
        public int Id { get; set; }
        public TypeNotificationEnum  Tipo { get; set; }
        public string Mensagem { get; set; }
        public string EmailDestinatario { get; set; }
        public string EmailOrigem { get; set; }
        public string NumDestinario { get; set; }
        public string Assunto { get; set; }
        public string Cliente { get; set; }
        public string NomeUsuario { get; set; }
    }
}
