using System.Globalization;
using System.Threading;
using WebMatrix.WebData;

namespace BankSystem
{
    public  class InitConfig
    {

        public static void Config()
        {
            CultureInfo cultureInfo = new CultureInfo("ru-RU");
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            WebSecurity.InitializeDatabaseConnection("DefaultConnection","UserProfile","UserId","Login",false);
        }
    }
}
