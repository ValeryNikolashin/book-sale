using Administration.Attributes;
using System.Web.Http;
using Administration.IContracts;
using User.Dto;

namespace Administration.Controllers
{
    /// <summary>
    /// Api для админки
    /// </summary>
    [SaleAuthorize]
    public class AdministrationController : ApiController
    {
        private readonly IAdministrationContract _administrationContract;

        public AdministrationController(IAdministrationContract administrationContract)
        {
            _administrationContract = administrationContract;
        }

        /// <summary>
        /// Авторизация администратора
        /// </summary>
        /// <param name="login">Логин администратора</param>
        /// <param name="password">Пароль администратора</param>
        [System.Web.Http.HttpPost]
        [System.Web.Http.AllowAnonymous]
        public bool TryLoginAsAdmin(string login, string password)
        {
            return _administrationContract.TryLoginAsAdmin(login, password);
        }

        /// <summary>
        /// Обновление информации о книге
        /// </summary>
        /// <param name="book">книга с обновлённой информацией</param>
        [System.Web.Http.HttpPost]
        public bool TryUpdateBook([FromBody] BookDto book)
        {
            return _administrationContract.TryUpdateBook(book);
        }

        /// <summary>
        /// Добавление в БД новой книги
        /// </summary>
        /// <param name="book">Новая книга</param>
        /// <returns></returns>
        [System.Web.Http.HttpPost]
        public bool TryCreateNewBook([FromBody] BookDto book)
        {
            return _administrationContract.TryCreateNewBook(book);
        }
    }
}