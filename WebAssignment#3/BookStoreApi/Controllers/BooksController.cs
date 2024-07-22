using Microsoft.AspNetCore.Mvc;
using BookStoreApi.BusinessLayer;
using BookStoreApi.Models;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly BookBL bookBL = new BookBL();
        
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            var books = bookBL.GetBooks();
            return Ok(books);
        }
        // GET: api/books/1
        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = bookBL.GetBook(id);

            if (book == null)
            {
                return NotFound(new { Message = "Book not found" });
            }

            return Ok(book);
        }
        // GET: api/books/1
        [HttpGet("ByAuthor/{author}")]
        public ActionResult<IEnumerable<Book>> GetBookAuthor(string author)
        {
            var book = bookBL.GetBookAuthor(author);

            if (book == null)
            {
                return NotFound(new { Message = "Book not found" });
            }

            return Ok(book);
        }

        // POST: api/Book
        [HttpPost]
        public ActionResult<Book> PostProduct(Book book)
        {
            bookBL.AddBook(book);
            return Ok(book);
        }
        // DELETE: api/Books/1
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var existingBook = bookBL.GetBook(id);
            if (existingBook == null)
            {
                return NotFound(new { Message = "Book not found" });
            }

            bookBL.DeleteBook(id);
            return Ok(new { Message = "Book deleted successfully" });
        }
        [HttpPut("{id}")]
        public IActionResult PutBook(int id, Book book)
        {
            var existingBook = bookBL.GetBook(id);
            if (existingBook == null)
            {
                return NotFound(new { Message = "Book not found" });
            }

            bookBL.UpdateBook(id, book);
            return Ok(new { Message = "Book updated successfully" });
        }
    }
}
