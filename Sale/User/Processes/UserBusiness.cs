using System;
using System.Collections.Generic;
using System.Linq;
using User.Dto;
using User.Enums;
using User.IContracts;
using User.Models;
using User.Services;

namespace User.Processes
{
    /// <summary>
    /// Логика работы приложения Sale
    /// </summary>
    public class UserBusiness: IUserContract
    {
        private readonly HubService _hubService;
        public UserBusiness(HubService hubService)
        {
            _hubService = hubService;
        }

        ///<inheritdoc/>
       public bool TryLogIn(Guid promoCode)
        {
            using (var db = new SaleContext())
            {
                return db.Users.Any(x => x.PromoCode == promoCode);
            }
        }
        
        ///<inheritdoc/>
        public Guid GetPromoCode()
        {
            using (var db = new SaleContext())
            {
                var newGuid = Guid.NewGuid();
                var user = new Models.User() {PromoCode = newGuid};
                db.Users.Add(user);
                db.Orders.Add(new Order()
                {
                    Id = user.Id,
                    Status = OrderStatuses.New,
                    User = user
                });
                db.SaveChanges();
                return newGuid;
            }
        }
        
        ///<inheritdoc/>
        public IEnumerable<BookDto> GetBooks()
        {
            using (var db = new SaleContext())
            {
                var dbBooks = db.Books.AsNoTracking().ToList();
                var books = new List<BookDto>();
                foreach (var dbBook in dbBooks)
                {
                    books.Add(Mapping.Mapping.BookToBookDtoMapping(dbBook));
                }
                return  books;
            }
        }
        
        ///<inheritdoc/>
        public IEnumerable<BookDto> GetOrderBooks(Guid promoCode)
        {
            using (var db = new SaleContext())
            {
                var dbOrderBooks = db.Orders.FirstOrDefault(x => x.User.PromoCode == promoCode)?.Books.ToList();
                var books = new List<BookDto>();
                if (dbOrderBooks != null)
                {
                    foreach (var dbBook in dbOrderBooks)
                    {
                        books.Add(Mapping.Mapping.BookToBookDtoMapping(dbBook));
                    }
                }
                return  books;
            }
        }
        
        ///<inheritdoc/>
        public bool TryToAddBookToBasket (Guid promoCode, int bookId)
        {
            using (var db = new SaleContext())
            {
                var orderId = db.Users.FirstOrDefault(x => x.PromoCode == promoCode)?.Id;
                var book = db.Books.FirstOrDefault(x => x.Id == bookId);
                var order = db.Orders.FirstOrDefault(x => x.Id == orderId);
                if (book != null && order != null && book.Count>0)
                {
                    
                    book.Count--;
                    order.Books.Add(book);
                    db.SaveChanges();
                    _hubService.ChangeCounter(book.Id,book.Count);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        
        ///<inheritdoc/>
        public void DeleteBookFromBasket (Guid promoCode, int bookId)
        {
            using (var db = new SaleContext())
            {
                var orderId = db.Users.FirstOrDefault(x => x.PromoCode == promoCode)?.Id;
                var deletedBook = db.Orders.FirstOrDefault(x => x.Id == orderId)?.Books.FirstOrDefault(y => y.Id == bookId);
                db.Orders.FirstOrDefault(x => x.Id == orderId)?.Books.Remove(deletedBook);
                var book =  db.Books.FirstOrDefault(x => x.Id == bookId);
                if (book != null)
                {
                    book.Count++;
                    db.SaveChanges();
                    _hubService.ChangeCounter(book.Id,book.Count);
                }
            }
        }
        
        ///<inheritdoc/>
        public void ToRegisterOrder(Guid promoCode)
        {
            using (var db = new SaleContext())
            {
                var orderId = db.Users.FirstOrDefault(x => x.PromoCode == promoCode)?.Id;
                var order = db.Orders.FirstOrDefault(x => x.Id == orderId);
                if (order != null)
                {
                    order.Status = OrderStatuses.WaitingForProcessing;
                    db.SaveChanges();
                }
            }
        }

        ///<inheritdoc/>
        public OrderDto GetOrder(Guid promoCode)
        {
            using (var db = new SaleContext())
            {
                var orderId = db.Users.FirstOrDefault(x => x.PromoCode == promoCode)?.Id;
                var dbOrder = db.Orders.FirstOrDefault(x => x.Id == orderId);
                return Mapping.Mapping.OrderToOrderDtoMapping(dbOrder);
            }
        }
    }
}