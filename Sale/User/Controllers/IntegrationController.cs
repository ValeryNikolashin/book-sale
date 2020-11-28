using System.Collections.Generic;
using System.Web.Http;
using User.Dto;
using User.IContracts;

namespace User.Controllers
{
    /// <summary>
    /// API для интеграции
    /// </summary>
    public class IntegrationController : ApiController
    {
        private readonly IIntegrationContract _integrationContract;

        public IntegrationController(IIntegrationContract integrationContract)
        {
            _integrationContract = integrationContract;
        }

        /// <summary>
        /// Возвращает колекцию заказов, ожидающих оплаты
        /// </summary>
        /// <param name="numberOfReturnedOrders">Максимальное число возвращаемых заказов</param>
        [HttpGet]
        public IEnumerable<OrderDto> GetWaitingProcessingOrders(int numberOfReturnedOrders)
        {
            return _integrationContract.GetWaitingProcessingOrders(numberOfReturnedOrders);
        }
    }
}