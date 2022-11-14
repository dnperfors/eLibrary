namespace eLibrary.WebApi
{
    public class Book
    {
        public Book(int id, string title, string author)
        {
            ID = id;
            Title = title;
            Author = author;
        }
        public int ID { get; }
        public string Title { get; }
        public string Author { get; }
    }
}