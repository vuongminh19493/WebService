using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace DemoRESTServiceCRUD
{
    [DataContract]
    public class Book
    {
        [DataMember] public int BookId { get; set; }
        [DataMember] public string Title { get; set; }
        [DataMember] public string ISBN { get; set; }
        public interface IBookRespository
        {
            List<Book> GetAllBooks();
            Book GetBookById(int id);
            Book AddNewBook(Book item);
            bool DeleteABook(int id);
            bool UpdateABook(Book item);
        }
        public class BookRespository: IBookRespository
        {
            private List<Book> books = new List<Book>();
            private int counter = 1;

            public BookRespository()
            {
                AddNewBook(new Book{Title = "C# Programming", ISBN = "23422342343"});
                AddNewBook(new Book { Title = "Java Programming", ISBN = "123422342343" });
                AddNewBook(new Book { Title = "WCF Programming", ISBN = "231324342343" });
            }
            //CRUD Operations
            //1. CREATE
            public Book AddNewBook(Book newBook)
            {
                if (newBook == null)
                    throw new ArgumentNullException("newBook");
                newBook.BookId = counter++;
                books.Add(newBook);
                return newBook;
            }
            //2. RETRIEVE /ALL
            public List<Book> GetAllBooks()
            {
                return books;
            }
            //3. RETRIEVE /By BookId
            public Book GetBookById(int bookId)
            {
                return books.Find(b => b.BookId == bookId);
            }
            //4. UPDATE
            public bool UpdateABook(Book updatedBook)
            {
                if (updatedBook == null)
                    throw new ArgumentNullException("updatedBook");
                int idx = books.FindIndex(b => b.BookId == updatedBook.BookId);
                if (idx == -1)
                    return false;
                books.RemoveAt(idx);
                books.Add(updatedBook);
                return true;
            }
            //5. DELETE
            public bool DeleteABook(int bookId)
            {
                int idx = books.FindIndex(b => b.BookId == bookId);
                if (idx == -1)
                    return false;
                books.RemoveAll(b => b.BookId == bookId);
                return true;
            }
        }
    }
}