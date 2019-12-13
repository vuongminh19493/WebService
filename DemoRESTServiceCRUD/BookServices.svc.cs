using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DemoRESTServiceCRUD
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BookServices" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BookServices.svc or BookServices.svc.cs at the Solution Explorer and start debugging.
    public class BookServices : IBookServices
    {
        static  Book.IBookRespository respository = new Book.BookRespository();

        public List<Book> GetBookList()
        {
            return respository.GetAllBooks();
        }

        public Book GetBookById(string id)
        {
            return respository.GetBookById(int.Parse(id));
        }

        public string AddBook(Book book, string id)
        {
            Book newBook = respository.AddNewBook(book);
            return "id=" + newBook.BookId;
        }

        public string UpdateBook(Book book, string id)
        {
            bool updated = respository.UpdateABook(book);
            if (updated)
                return "Book with id = " + id + "updated successfully.";
            else
                return "Unable to update book with id = " + id;
        }

        public string DeleteBook(string id)
        {
            bool deleted = respository.DeleteABook(int.Parse(id));
            if (deleted)
                return "Book with id = " + id + "deleted successfully.";
            else return "Unable to delete book with id = " + id;
        }
        public void DoWork()
        {
        }
    }
}
