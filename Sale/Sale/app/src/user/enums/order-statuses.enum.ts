//Статусы заказа
export enum OrderStatuses {

  //новый заказ
  New,

  //ожидает обработки
  WaitingForProcessing,

  //ожидает оплаты
  WaitingForPayment,
}
