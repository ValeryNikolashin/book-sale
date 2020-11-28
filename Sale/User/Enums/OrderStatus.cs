namespace User.Enums
{
    /// <summary>
    /// Статус заказа
    /// </summary>
    public enum OrderStatuses
    {
        /// <summary>
        /// Новый
        /// </summary>
        New,
        
        /// <summary>
        /// Ожидание обработки
        /// </summary>
        WaitingForProcessing,
        
        /// <summary>
        /// Ожидание оплаты
        /// </summary>
        WaitingForPayment
    }
}