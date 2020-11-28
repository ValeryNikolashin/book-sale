using System.Linq;
using User.Dto;
using User.Models;

namespace User.Mapping
{
    public static class Mapping
    {
        /// <summary>
        /// Мапит сущность Book в BookDto
        /// </summary>
        /// <param name="dbBook">Сущность Book</param>
        public static BookDto BookToBookDtoMapping(Book dbBook)
        {
            return new BookDto
            {
                Author = dbBook.Author,
                Cost = dbBook.Cost,
                Count = dbBook.Count,
                Id = dbBook.Id,
                Name = dbBook.Name,
                Picture = dbBook.Picture,
                Year = dbBook.Year,
                IsbnCode = dbBook.IsbnCode
            };
        }
        
        /// <summary>
        /// Мапит сущность Order в OrderDto
        /// </summary>
        /// <param name="dbOrder">Cущность Order</param>
        /// <returns></returns>
        public static OrderDto OrderToOrderDtoMapping(Order dbOrder)
        {
            using (var db = new SaleContext())
            {
                return new OrderDto()
                {
                    Id = dbOrder.Id,
                    Status = dbOrder.Status,
                    Url = dbOrder.Url,
                    BookIsbnCodes = dbOrder.Books.Select(x => x.IsbnCode),
                    UserPromoCode = dbOrder.User.PromoCode
                };
            }
        }
        
        /// <summary>
        /// Копирует поля сущности BookDto в Book
        /// </summary>
        /// <param name="book">Сущность BookDto</param>
        /// <param name="dbBook">Сущность Book</param>
        public static void BookDtoToBookMapping(BookDto book, ref Book dbBook)
        {
            dbBook.Author = book.Author;
            dbBook.Cost = book.Cost;
            dbBook.Count = book.Count;
            dbBook.Name = book.Name;
            dbBook.Picture = book.Picture;
            dbBook.Year = book.Year;
            dbBook.IsbnCode = book.IsbnCode;
        }
    }
}