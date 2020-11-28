using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace User.Models
{
    /// <summary>
    /// Модель для таблицы books
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Id книги
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Наименование книги
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        /// <summary>
        /// Автор
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Author { get; set; }
        
        /// <summary>
        /// Год издания
        /// </summary>
        public DateTime Year { get; set; }

        /// <summary>
        /// ISBN код
        /// </summary>
        [Required]
        [StringLength(20)]
        public string IsbnCode { get; set; }
        
        /// <summary>
        /// Путь к картинке
        /// </summary>
        [StringLength(200)]
        public string Picture { get; set; }
        
        /// <summary>
        /// Стоимость
        /// </summary>
        public double Cost { get; set; }
        
        /// <summary>
        /// Количество книг доступных для продажи
        /// </summary>
        public int Count { get; set; }
        
        /// <summary>
        /// Заказы в которых есть данная книга
        /// </summary>
        public virtual ICollection<Order> Orders { get; set; }
    }
}