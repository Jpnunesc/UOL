using Business.Enums;
using Business.Validations;

namespace Business.IO.Notification
{
    public class NotificationInput
    {
        public TypeNotificationEnum Tipo { get; set; }
        public string Mensagem { get; set; }
        public string EmailDestinatario { get; set; }
        public string EmaiOrigem { get; set; }
        public string NumDestinario { get; set; }
        public string Assunto { get; set; }
        public string Cliente { get; set; }
        public string NomeUsuario { get; set; }


        //TODO: colocar um variavel "body" que converte tudo em json de acordo com o "tipo"
        public ReturnView Validate()
        {
            ReturnView retorno = new ReturnView();
            NotificationValidation validator = new NotificationValidation();
            foreach (var el in list)
            {
                var valid = validator.Validate(value);
                if (!valid.IsValid)
                {
                    retorno.Status = false;
                    foreach (var item in valid.Errors)
                    {
                        retorno.Message = string.IsNullOrEmpty(retorno.Message) ? item.ErrorMessage : retorno.Message + ", " + item.ErrorMessage;
                    }
                    return retorno;
                }
            }
            retorno.Status = true;
            return retorno;
        }
    }

}
