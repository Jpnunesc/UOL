using System.ComponentModel;

namespace Business.Enums
{
    public enum TypeNotificationEnum
    {
        [Description("SMS")]
        Sms = 1,
        [Description("EMAIL")]
        Email = 2
    }
}
