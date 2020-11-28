using System.Collections.Generic;
using User.Dto;

namespace User.IContracts
{
    /// <summary>
    /// Логика для интеграции
    /// </summary>
    public interface IIntegrationContract
    {
        /// <summary>
        /// Возвращает колекцию заказов, ожидающих оплаты
        /// </summary>
        /// <param name="numberOfReturnedOrders">Максимальное число возвращаемых заказов</param>
        IEnumerable<OrderDto> GetWaitingProcessingOrders(int numberOfReturnedOrders);
    }
}