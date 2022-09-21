using System.ComponentModel;

namespace Business.Enums
{
    public enum TypeNotificationEnum
    {
        [Description("EMAIL")]
        Email = 1,
        [Description("SMS")]
        Sms = 2
    }
}
