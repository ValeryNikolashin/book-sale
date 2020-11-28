using System;

namespace User.Dto
{
    /// <summary>
    /// Дто книги
    /// </summary>
    public class BookDto
    {
        /// <summary>
        /// Id книги
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Наименование книги
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Автор
        /// </summary>
        public string Author { get; set; }
        
        /// <summary>
        /// Год издания
        /// </summary>
        public DateTime Year { get; set; }

        /// <summary>
        /// ISBN код
        /// </summary>
        public string IsbnCode { get; set; }
        
        /// <summary>
        /// Путь к картинке
        /// </summary>
        public string Picture { get; set; }
        
        /// <summary>
        /// Стоимость
        /// </summary>
        public double Cost { get; set; }
        
        /// <summary>
        /// Количество книг доступных для продажи
        /// </summary>
        public int Count { get; set; }
    }
}