namespace Api;
public class Repository
{
    List<Author> authors = new List<Author>();
    List<Book> books = new List<Book>();

    public Task<List<Book>> GetBooksAsync() { return Task.FromResult(books); }
    public Task<Author?> GetAuthor(Guid authorId)
    {
        return Task.FromResult(authors.FirstOrDefault(a => a.Id == authorId));
    }

    public Task AddAuthor(Author author)
    {
        authors.Add(author);
        return Task.CompletedTask;
    }

    public Task AddBook(Book book)
    {
        books.Add(book);
        return Task.CompletedTask;
    }
}
