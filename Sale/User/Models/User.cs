using System;
using System.ComponentModel.DataAnnotations;

namespace User.Models
{
    /// <summary>
    /// Модель для таблицы users
    /// </summary>
    public class User
    {
        /// <summary>
        /// Id пользователя
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Промо-код пользователя
        /// </summary>
        [Required]
        public Guid PromoCode { get; set; }
    }
}