using System.Configuration;
using System.Linq;
using Administration.IContracts;
using User.Dto;
using User.Mapping;
using User.Models;

namespace Administration.Processes
{
    /// <summary>
    /// Логика для админки
    /// </summary>
    public class AdministrationBusiness : IAdministrationContract
    {
        //Ключ логина администратора в Web.config
        private const string AdminLogin = "AdminLogin";
        //Ключ пароля администратора в Web.config
        private const string AdminPassword = "AdminPassword";
        
        ///<inheritdoc/>
        public bool TryLoginAsAdmin(string login, string password)
        {
            var adminLogin = ConfigurationManager.AppSettings["AdminLogin"];
            var adminPassword = ConfigurationManager.AppSettings["AdminPassword"];
            return adminLogin == login && adminPassword == password;
        }

        ///<inheritdoc/>
        public bool TryUpdateBook(BookDto book)
        {
            if (book == null) return false;
            
            using (var db = new SaleContext())
            {
                var dbBook = db.Books.FirstOrDefault(x => x.Id == book.Id);
                if (dbBook == null) return false;
                Mapping.BookDtoToBookMapping(book, ref dbBook);
                db.SaveChanges();
                return true;
            }
        }

        ///<inheritdoc/>
        public bool TryCreateNewBook(BookDto book)
        {
            if (book == null) return false;
            
            using (var db = new SaleContext())
            {
                var dbBook = new Book();
                Mapping.BookDtoToBookMapping(book, ref dbBook);
                db.Books.Add(dbBook);
                db.SaveChanges();
                return true;
            }
        }
    }
}