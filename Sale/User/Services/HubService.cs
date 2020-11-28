using Microsoft.AspNet.SignalR;
using User.Hubs;

namespace User.Services
{
    /// <summary>
    /// Сервис для хаба CounterHub
    /// </summary>
    public class HubService
    {
        //контекст хаба
        private readonly IHubContext _context;

        public HubService()
        {
            _context = GlobalHost.ConnectionManager.GetHubContext<CounterHub>();
        }

        /// <summary>
        /// Отправляет всем клиентам id книги и
        /// актуальное значение количества экземпляров этой книги, доступных для продажи
        /// </summary>
        /// <param name="bookId">id книги</param>
        /// <param name="booksCount">количество экземпляров для продажи</param>
        public void ChangeCounter(int bookId, int booksCount)
        {
            _context.Clients.All.ChangeCounter(bookId, booksCount);
        }
    }
}