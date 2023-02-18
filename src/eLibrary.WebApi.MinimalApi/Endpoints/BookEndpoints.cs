using eLibrary.Models;
using Microsoft.OpenApi.Any;

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
             .WithOpenApi(options =>
             {
                 options.Parameters[0].Examples.Add("id", new Microsoft.OpenApi.Models.OpenApiExample() { Value = new OpenApiInteger(1) });
                 return options;
             });
    }

    private static IResult GetBooks(BookRepository bookRepository)
    {
        var books = bookRepository.GetBooks();
        return Results.Ok(books);
    }

    private static IResult GetBook(BookRepository bookRepository, int id)
    {
        var book = bookRepository.GetBook(id);
        if (book is null)
        {
            return Results.NotFound();
        }
        return Results.Ok(book);
    }
}
