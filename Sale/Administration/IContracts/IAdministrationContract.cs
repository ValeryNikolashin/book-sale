using User.Dto;

namespace Administration.IContracts
{
    /// <summary>
    /// Логика для админки
    /// </summary>
    public interface IAdministrationContract
    {
        /// <summary>
        /// Авторизация администратора
        /// </summary>
        /// <param name="login">Логин администратора</param>
        /// <param name="password">Пароль администратора</param>
        bool TryLoginAsAdmin(string login, string password);

        /// <summary>
        /// Обновление информации о книге
        /// </summary>
        /// <param name="book">книга с обновлённой информацией</param>
        /// <returns></returns>
        bool TryUpdateBook(BookDto book);

        /// <summary>
        /// Добавление в БД новой книги
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        bool TryCreateNewBook(BookDto book);
    }
}