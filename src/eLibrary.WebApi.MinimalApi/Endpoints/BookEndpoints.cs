using eLibrary.Models;

namespace eLibrary.WebApi.MinimalApi.Endpoints;

public static class BookEndpoints
{
    internal static void MapBookEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/book").WithTags(nameof(Book));

        group.MapGet("/", GetBooks)
             .WithName("GetAllBooks")
             .Produces<IEnumerable<Book>>(StatusCodes.Status200OK, "application/json")
             .WithOpenApi();

        group.MapGet("/{id:int}", GetBook)
             .WithName("GetBookById")
             .Produces<Book>(StatusCodes.Status200OK, "application/json")
             .Produces(StatusCodes.Status404NotFound)
             .WithOpenApi();
    }

    /// <summary>
    /// Get a list of all the books in the library
    /// </summary>
    /// <response code="200">A list of books is returned, this list could be empty.</response>
    public static IResult GetBooks(BookRepository bookRepository)
    {
        var books = bookRepository.GetBooks();
        return Results.Ok(books);
    }

    /// <summary>
    /// Get a book with a specific id from the libray
    /// </summary>
    /// <param name="id" example="1">The id of the book</param>
    /// <response code="200">The requested book is found and returned.</response>
    /// <response code="404">Book with specified id is not found.</response>
    public static IResult GetBook(BookRepository bookRepository, int id)
    {
        var book = bookRepository.GetBook(id);
        if (book is null)
        {
            return Results.NotFound();
        }
        return Results.Ok(book);
    }
}
