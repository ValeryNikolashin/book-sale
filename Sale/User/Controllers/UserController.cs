using System;
using System.Collections.Generic;
using System.Web.Http;
using User.Dto;
using User.IContracts;

namespace User.Controllers
{
    
    /// <summary>
    /// Контроллер с API магазина Сэйлы
    /// </summary>
    public class UserController: ApiController
    {
        private readonly IUserContract _userContract;
        
        public UserController(IUserContract userContract)
        {
            _userContract = userContract;
        }

        /// <summary>
        /// Авторизоваться
        /// </summary>
        /// <param name="promoCode">Промокод пользователя</param>
        [HttpPost]
        public bool TryLogIn(Guid promoCode)
        {
            return  _userContract.TryLogIn(promoCode);
        }
        
        /// <summary>
        /// Возвращает новый промокод
        /// </summary>
        [HttpGet]
        public Guid GetPromoCode()
        {
            return _userContract.GetPromoCode();
        }
        
        /// <summary>
        /// Возвращает список книг, участвующих в распродаже
        /// </summary>
        [HttpGet]
        public IEnumerable<BookDto> GetBooks()
        {
            return _userContract.GetBooks();
        }
        
        /// <summary>
        /// Возвращает список книг в заказе пользователя
        /// </summary>
        /// <param name="promoCode">Промокод пользователя</param>
        [HttpGet]
        public IEnumerable<BookDto> GetOrderBooks(Guid promoCode)
        {
            return _userContract.GetOrderBooks(promoCode);
        }
        
        /// <summary>
        /// Добавляет книгу в заказ пользователя
        /// </summary>
        /// <param name="promoCode">Промокод пользователя</param>
        /// <param name="bookId">id книги</param>
        [HttpPost]
        public bool TryToAddBookToBasket (Guid promoCode, int bookId)
        {
            return _userContract.TryToAddBookToBasket(promoCode, bookId);
        }
        
        /// <summary>
        /// Удаляет книгу из заказа пользователя
        /// </summary>
        /// <param name="promoCode">Промокод пользователя</param>
        /// <param name="bookId">id книги</param>
        [HttpPost]
        public void DeleteBookFromBasket (Guid promoCode, int bookId)
        {
            _userContract.DeleteBookFromBasket(promoCode, bookId);
        }
        
        /// <summary>
        /// Оформить заказ пользователя для оплаты
        /// </summary>
        /// <param name="promoCode">Промокод пользователя</param>
        [HttpPost]
        public void ToRegisterOrder(Guid promoCode)
        {
            _userContract.ToRegisterOrder(promoCode);
        }

        /// <summary>
        /// Возвращает заказ по промокоду пользователя
        /// </summary>
        /// <param name="promoCode">Промокод пользователя</param>
        [HttpGet]
        public OrderDto GetOrder(Guid promoCode)
        {
            return _userContract.GetOrder(promoCode);
        }
    }
}