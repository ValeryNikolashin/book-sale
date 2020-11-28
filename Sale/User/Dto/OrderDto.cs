using System;
using System.Collections.Generic;
using User.Enums;

namespace User.Dto
{
    /// <summary>
    /// Дто заказа
    /// </summary>
    public class OrderDto
    {
        /// <summary>
        /// Id
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Ссылка для оплаты заказа
        /// </summary>
        public string Url { get; set; }
        
        /// <summary>
        /// Статус заказа
        /// </summary>
        public OrderStatuses Status { get; set; }
       
        /// <summary>
        /// ISBN-коды книг заказа
        /// </summary>
        public IEnumerable<string> BookIsbnCodes { get; set; }
        
        /// <summary>
        /// Промокод пользователя
        /// </summary>
        public Guid UserPromoCode { get; set; }
    }
}