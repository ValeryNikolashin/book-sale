using System.Collections.Generic;
using System.Linq;
using User.Dto;
using User.Enums;
using User.IContracts;
using User.Models;

namespace User.Processes
{
    /// <summary>
    /// Логика для интеграции
    /// </summary>
    public class IntegrationBusiness : IIntegrationContract
    {
        ///<inheritdoc/>
        public IEnumerable<OrderDto> GetWaitingProcessingOrders(int numberOfReturnedOrders)
        {
            using (var db = new SaleContext())
            {
               var dbOrders = db.Orders.Where(x => x.Status == OrderStatuses.WaitingForProcessing).Take(numberOfReturnedOrders).ToList();
               var orders = new List<OrderDto>();
               foreach (var dbOrder in dbOrders)
               {
                   orders.Add(Mapping.Mapping.OrderToOrderDtoMapping(dbOrder));
               }
               return orders;
            }
        }
    }
}