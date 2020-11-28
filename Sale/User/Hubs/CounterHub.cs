using Microsoft.AspNet.SignalR;

namespace User.Hubs
{
    /// <summary>
    /// Хаб для "живого счётчика"
    /// </summary>
    public class CounterHub : Hub
    {
      
        /// <summary>
        /// Отправляет всем клиентам id книги и
        /// актуальное значение количества экземпляров этой книги, доступных для продажи
        /// </summary>
        /// <param name="bookId">id книги</param>
        /// <param name="booksCount">количество экземпляров для продажи</param>
        public void ChangeCounter(int bookId,int booksCount)
        {
            // Вызывает на всех клиентах метод "ChangeCounter", чтобы обновить информацию на них (клиентах).
            Clients.All.Send(nameof(ChangeCounter),bookId,booksCount);
        }
    }
}