using System;
using System.Collections.Generic;
using User.Dto;

namespace User.IContracts
{
    /// <summary>
    /// Логика работы приложения Sale
    /// </summary>
    public interface IUserContract
    {
        /// <summary>
        /// Авторизоваться
        /// </summary>
        /// <param name="promoCode">Промокод пользователя</param>
        /// <returns>Авторизация прошла успешно?</returns>
        bool TryLogIn(Guid promoCode);
        
        /// <summary>
        /// Возвращает новый промокод
        /// </summary>
        /// <returns></returns>
        Guid GetPromoCode();
        
        /// <summary>
        /// Возвращает список книг, участвующих в распродаже
        /// </summary>
        /// <returns></returns>
        IEnumerable<BookDto> GetBooks();
        
        /// <summary>
        /// Возвращает список книг в заказе пользователя
        /// </summary>
        /// <param name="promoCode">Промокод пользователя</param>
        /// <returns></returns>
        IEnumerable<BookDto> GetOrderBooks(Guid promoCode); 
        
        /// <summary>
        /// Добавляет книгу в заказ пользователя
        /// </summary>
        /// <param name="promoCode">Промокод пользователя</param>
        /// <param name="bookId">id книги</param>
        /// <returns></returns>
        bool TryToAddBookToBasket (Guid promoCode, int bookId);
        
        /// <summary>
        /// Удаляет книгу из заказа пользователя
        /// </summary>
        /// <param name="promoCode">Промокод пользователя</param>
        /// <param name="bookId">id книги</param>
        void DeleteBookFromBasket (Guid promoCode, int bookId);
        
        /// <summary>
        /// Оформить заказ для оплаты
        /// </summary>
        /// <param name="promoCode">Промокод пользователя</param>
        void ToRegisterOrder(Guid promoCode);

        /// <summary>
        /// Возвращает заказ по промокоду пользователя
        /// </summary>
        /// <param name="promoCode">Промокод пользователя</param>
        OrderDto GetOrder(Guid promoCode);
    }
}