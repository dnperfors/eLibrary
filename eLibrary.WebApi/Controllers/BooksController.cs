using Microsoft.AspNetCore.Mvc;

namespace eLibrary.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private Book[] books = new[]
        {
            new Book(1, "Clean Craftsmanship", "Uncle Bob"),
            new Book(2, "The Clean Coder", "Uncle Bob"),
            new Book(3, "Clean Code", "Uncle Bob"),
            new Book(4, "The Pragmatic Programmer", "Andrew Hunt")
        };
        private readonly ILogger<BooksController> _logger;

        public BooksController(ILogger<BooksController> logger)
        {
            _logger = logger;
        }
            
        [HttpGet("{id}")]
        public Book? GetBook(int id) => books.SingleOrDefault(x => x.ID == id);
    }
}