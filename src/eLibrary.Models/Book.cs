using System.Diagnostics.CodeAnalysis;

namespace eLibrary.Models;

public record Book
{
    [SetsRequiredMembers]
    public Book(int id, string title, string author)
    {
        Id = id;
        Title = title;
        Author = author;
    }

    /// <summary>
    /// The id of a book.
    /// </summary>
    /// <example>1</example>
    public required int Id { get; init; }
    /// <summary>
    /// The title of a book.
    /// </summary>
    /// <example>My book</example>
    public required string Title { get; init; }
    /// <summary>
    /// The author of a book
    /// </summary>
    /// <example>Book Author</example>
    public required string Author { get; init; }
}
