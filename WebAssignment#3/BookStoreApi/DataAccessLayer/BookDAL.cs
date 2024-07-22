using BookStoreApi.Models;
namespace BookStoreApi.DataAccessLayer
{
    public class BookDAL
    {
        private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "Atomic Habits", Author = "James Clear", Description = "Non-Fiction Book", ImageUrl="https://th.bing.com/th/id/OIP.-zx-8Qg9VxHrAkTLdKG1KgHaLL?rs=1&pid=ImgDetMain"  },
            new Book { Id = 2, Title = "Harry Potter", Author = "J.K Rowling", Description = "Fiction Book", ImageUrl="https://res.cloudinary.com/bloomsbury-atlas/image/upload/w_568,c_scale/jackets/9781408855652.jpg"  },
            new Book { Id = 3, Title = "Beauty and The Beast", Author = "Gabrielle-Suzanne", Description = "Fiction Book", ImageUrl="https://images.thenile.io/r1000/9780746070604.jpg"  },
            
        };

        public List<Book> GetBooks()
        {
            return books;//returns books list
        }
        public Book GetBook(int id)
        {
            return books.FirstOrDefault(b => b.Id == id);
        }
        public List<Book> GetBookAuthor(string author)
        {
            return books.Where(b => b.Author == author).ToList();
        }
        public void AddBook(Book book)
        {
            book.Id = books.Max(b => b.Id) + 1;
            books.Add(book);
        }
        public void UpdateBook(Book book)
        {
            var existingBook = books.FirstOrDefault(b => b.Id == book.Id);

            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.Description = book.Description;
                existingBook.ImageUrl=book.ImageUrl;
               
            }
        }
        public void DeleteBook(int id)
        {
            var book = books.First(b => b.Id == id);
            if (book != null)
            {
                books.Remove(book);
            }
        }
    }
}
