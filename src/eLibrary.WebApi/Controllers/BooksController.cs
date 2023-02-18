using Microsoft.AspNetCore.Mvc;
using eLibrary.Models;

namespace eLibrary.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly BookRepository books = new();

        public BooksController(ILogger<BooksController> logger)
        {
            _logger = logger;
        }
            
        [HttpGet("{id}")]
        public Book? GetBook(int id) => books.GetBook(id);
    }
}