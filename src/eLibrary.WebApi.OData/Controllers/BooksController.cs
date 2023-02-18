using eLibrary.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace eLibrary.WebApi.OData.Controllers
{
    public class BooksController : ODataController
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

        [HttpGet]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.None)]
        public IQueryable<Book> GetBooks() => books.AsQueryable();

        [HttpGet]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.None)]
        public SingleResult<Book> GetBook(int key) => SingleResult.Create(books.Where(x => x.Id == key).AsQueryable());
    }
}