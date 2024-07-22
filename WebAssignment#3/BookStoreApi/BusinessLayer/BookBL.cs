using BookStoreApi.DataAccessLayer;
using BookStoreApi.Models;
namespace BookStoreApi.BusinessLayer
{
    public class BookBL
    {
        private readonly BookDAL bookDAL = new BookDAL();
        public List<Book> GetBooks()
        {
            return bookDAL.GetBooks();
        }
        public Book GetBook(int id)
        {
            return bookDAL.GetBook(id);
        }
        public List<Book> GetBookAuthor(string author)
        {
            return bookDAL.GetBookAuthor(author);
        }
        public void AddBook(Book book)
        {
            bookDAL.AddBook(book);
        }
        public void DeleteBook(int id)
        {
            bookDAL.DeleteBook(id);
        }
        public void UpdateBook(int id,Book book)
        {
            var existingBook = bookDAL.GetBook(id);
            if (existingBook != null)
            {
                book.Id = id; // ID will remain unchanged
                bookDAL.UpdateBook(book);
            }
        }
    }
}
