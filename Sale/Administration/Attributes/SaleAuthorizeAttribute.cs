using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Administration.Attributes
{
    public class SaleAuthorizeAttribute : AuthorizeAttribute
    {
        
        //Имя cookie для логина администратора
        private const string LoginCookieName = "login";
        //Имя cookie для пароля администратора
        private const string PasswordCookieName = "password";
        //Ключ логина администратора в Web.config
        private const string AdminLogin = "AdminLogin";
        //Ключ пароля администратора в Web.config
        private const string AdminPassword = "AdminPassword";
        
        
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var cookies = actionContext.Request.Headers.GetCookies().Select(x => x.Cookies).FirstOrDefault();
            if (cookies!=null && cookies.Any())
            {
                var login = cookies.FirstOrDefault(x=>x.Name==LoginCookieName)?.Value;
                var password = cookies.FirstOrDefault(x=>x.Name==PasswordCookieName)?.Value;
                var adminLogin = ConfigurationManager.AppSettings[AdminLogin];
                var adminPassword = ConfigurationManager.AppSettings[AdminPassword];
                return adminLogin == login && adminPassword == password;
            }
            
            return false;
        }
    }
}