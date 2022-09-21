using Business.Enums;
using Business.Validations;

namespace Business.IO.Notification
{
    public class NotificationInput
    {
        public int? Id { get; set; }
        public int Tipo { get; set; }
        public string Mensagem { get; set; }
        public string EmailDestinatario { get; set; }
        public string EmailOrigem { get; set; }
        public string NumDestinario { get; set; }
        public string Assunto { get; set; }
        public string Cliente { get; set; }
        public string NomeUsuario { get; set; }

        public ReturnView Validate(NotificationInput notification)
        {
            ReturnView retorno = new ReturnView();
                var validator = notification.Tipo == (int)TypeNotificationEnum.Email 
                                                     ? new NotificationEmailValidation().Validate(notification) 
                                                     : new NotificationSmsValidation().Validate(notification);
                if (!validator.IsValid)
                {
                    retorno.Status = false;
                    foreach (var item in validator.Errors)
                    {
                        retorno.Message = string.IsNullOrEmpty(retorno.Message) ? item.ErrorMessage : retorno.Message + ", " + item.ErrorMessage;
                    }
                    return retorno;
                }
            retorno.Status = true;
            return retorno;
        }
    }

}
