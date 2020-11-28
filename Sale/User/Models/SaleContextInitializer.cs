using System;
using System.Collections.Generic;
using System.Data.Entity;
using User.Enums;

namespace User.Models
{
    /// <summary>
    /// Инициализатор БД
    /// </summary>
    public class SaleContextInitializer: DropCreateDatabaseAlways<SaleContext>
    {
        protected override void Seed(SaleContext db)
        {
            var user1 = new User()
            {
                PromoCode = new Guid("f55dbce0-976a-4136-b66f-8e28ba133685")
            };
            db.Users.Add(user1);
            db.SaveChanges();
            var book1 = new Book()
            {
                Author = "Михаил Булгаков",
                Cost = 500,
                Count = 20,
                Name = "Роковые яйца",
                Picture = "https://top10a.ru/wp-content/uploads/2018/01/25048853._UY475_SS475_.jpg",
                Year = new DateTime(1970,1,1),
                IsbnCode = "2-12836-462-3"
            };
            var book2 = new Book()
            {
                Author = "Николай Чернышевский",
                Cost = 400,
                Count = 10,
                Name = "Что делать?",
                Picture = "https://cdn.eksmo.ru/v2/ASE000000000832193/COVER/cover1.jpg",
                Year = new DateTime(1950,1,1),
                IsbnCode = "6-73563-537-2"
            };
            var book3 = new Book()
            {
                Author = "Муссен Анна",
                Cost = 600,
                Count = 5,
                Name = "Ведьма с украденным именем",
                Picture = "https://www.litmir.me/data/Book/0/676000/676336/BC4_1587131735.jpg",
                Year = new DateTime(2005,1,1),
                IsbnCode = "1-12352-634-2"
            };
            var book4 = new Book()
            {
                Author = "Traum von Katrin",
                Cost = 550,
                Count = 21,
                Name = "Адвокат дьявола",
                Picture = "https://www.litmir.me/data/Book/0/676000/676335/BC4_1587130698.jpg",
                Year = new DateTime(2001,1,1),
                IsbnCode = "3-53737-236-5"
            };
            var book5 = new Book()
            {
                Author = "Пол Кэти",
                Cost = 700,
                Count = 8,
                Name = "Сон: Блуждающие во тьме",
                Picture = "https://www.litmir.me/data/Book/0/676000/676295/BC4_1587125333.jpg",
                Year = new DateTime(2012,1,1),
                IsbnCode = "2-50287-216-6"
            };
            var book6 = new Book()
            {
                Author = "Грибанов Роман Борисович",
                Cost = 485,
                Count = 26,
                Name = "Бои местного значения",
                Picture = "https://www.litmir.me/data/Book/0/676000/676204/BC4_1587042745.jpg",
                Year = new DateTime(2011,1,1),
                IsbnCode = "8-28387-356-2"
            };
            var book7 = new Book()
            {
                Author = "Москаленко Юрий",
                Cost = 426,
                Count = 3,
                Name = "Нечестный штрафной. Книга вторая. Часть первая",
                Picture = "https://www.litmir.me/data/Book/0/676000/676141/BC4_1587029423.jpg",
                Year = new DateTime(2015,1,1),
                IsbnCode = "4-25576-281-9"
            };
            var book8 = new Book()
            {
                Author = "Мур Настёна",
                Cost = 325,
                Count = 16,
                Name = "Будешь?.. Буду!",
                Picture = "https://www.litmir.me/data/Book/0/676000/676138/BC4_1587020214.jpg",
                Year = new DateTime(1989,1,1),
                IsbnCode = "0-17267-293-3"
            };
            var book9 = new Book()
            {
                Author = "Саймон Сингх",
                Cost = 357,
                Count = 15,
                Name = "Симпсоны и их математические секреты",
                Picture = "https://cv3.litres.ru/pub/c/cover/18543833.jpg",
                Year = new DateTime(2016,1,1),
                IsbnCode = "978-5-00100-034-1"
            };
            var book10 = new Book()
            {
                Author = "Ярослав Брин",
                Cost = 639,
                Count = 27,
                Name = "Меняю жир на силу воли",
                Picture = "https://knigopoisk.org/media/books/55/55d5c56de40f5.jpg",
                Year = new DateTime(2018,1,1),
                IsbnCode = "987-21887-639-4"
            };
            var book11 = new Book()
            {
                Author = "Рей Бредбери",
                Cost = 967,
                Count = 34,
                Name = "Вино из одуванчиков",
                Picture = "https://disotzov.ru/wp-content/uploads/2020/03/43851-vino-iz-oduvanchikov-e1507716523939.jpg",
                Year = new DateTime(2008,1,1),
                IsbnCode = "3-42928-231-6"
            };
            var book12 = new Book()
            {
                Author = "Миядзаки Хаяо",
                Cost = 1021,
                Count = 4,
                Name = "Мой сосед Тоторо",
                Picture = "https://img-gorod.ru/27/859/2785943_preview.jpg",
                Year = new DateTime(2019,1,1),
                IsbnCode = "8-95046-493-9"
            };
            var book13 = new Book()
            {
                Author = "Борис Васильев",
                Cost = 438,
                Count = 32,
                Name = "А зори здесь тихие...",
                Picture = "https://pbs.twimg.com/media/EQjFrdkWAAABDif.jpg",
                Year = new DateTime(2007,1,1),
                IsbnCode = "8-28462-056-4"
            };
            db.Books.AddRange(new List<Book>() {book1, book2,book3, book4,book5, book6,book7, book8,book9, book10,book11, book12,book13});
            db.SaveChanges();
            var order1 = new Order()
            {
                Books = new List<Book>() {book1, book2},
                Status = OrderStatuses.New,
                Url = null,
                User = user1,
                Id = user1.Id
            };
            db.Orders.Add(order1);
            db.SaveChanges();
        }
    }
}