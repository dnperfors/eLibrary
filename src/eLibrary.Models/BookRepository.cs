using System.Diagnostics;

namespace eLibrary.Models;

public class BookRepository
{
    private Book[] books = new[]
    {
        new Book(1, "Clean Craftsmanship", "Uncle Bob"),
        new Book(2, "The Clean Coder", "Uncle Bob"),
        new Book(3, "Clean Code", "Uncle Bob"),
        new Book(4, "The Pragmatic Programmer", "Andrew Hunt")
    };

    public IEnumerable<Book> GetBooks() => books;
    public Book? GetBook(int id) => books.SingleOrDefault(x => x.Id == id);
}
