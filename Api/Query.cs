namespace Api;
public class Query
{
    public Task<List<Book>> GetBooks([Service] Repository repository) =>
        repository.GetBooksAsync();

    public Task<Author?> GetAuthor(Guid authorId, [Service] Repository repository) =>
        repository.GetAuthor(authorId);
}
