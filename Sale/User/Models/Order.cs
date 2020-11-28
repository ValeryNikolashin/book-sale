using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using User.Enums;

namespace User.Models
{
    /// <summary>
    /// Модель для таблицы orders
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Id
        /// </summary>
        [Key]
        [ForeignKey("User")]
        public int Id { get; set; }
        
        /// <summary>
        /// Ссылка для оплаты заказа
        /// </summary>
        [StringLength(100)]
        public string Url { get; set; }
        
        /// <summary>
        /// Статус заказа
        /// </summary>
        [Required]
        public OrderStatuses Status { get; set; }
        
        /// <summary>
        /// Книги заказа
        /// </summary>
        public virtual ICollection<Book> Books { get; set; }

        /// <summary>
        /// Пользователь
        /// </summary>
        public virtual User User { get; set; }
    }
}